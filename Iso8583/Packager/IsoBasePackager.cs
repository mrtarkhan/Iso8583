using System.Collections;
using Iso8583.Packager.PackagerFieldPackager;

namespace Iso8583.Packager;

public abstract class IsoBasePackager : IsoPackager
{
    protected List<IsoFieldPackager> FieldMap { get; private set; }

    protected void ConfigFieldMap(params IsoFieldPackager[] map)
    {
        FieldMap = map.ToList();
    }


    public abstract int GetBitmapFieldKey();

    public IsoMessage UnPack(byte[] inputData)
    {
        throw new NotImplementedException();
    }

    public int GetBitmapPackagerSize()
    {
        foreach (var item in FieldMap)
        {
            if (item is IsoBitMapPackager)
                return item.MaxLength;
        }

        // primary bitmap is 8 bytes by default and 64 bit elements
        return 8;
    }


    /// <summary>
    /// usually 2 for normal fields, 1 for bitmap-less or ANSI X9.2
    /// </summary>
    /// <returns>first valid field</returns>
    private BitmapTypeEnum GetBitmapType()
    {
        if (FieldMap.Count > 1)
            return FieldMap[1] is IsoBitMapPackager ? BitmapTypeEnum.SecondaryBitmap : BitmapTypeEnum.PrimaryBitmap;

        return BitmapTypeEnum.BitmapLess;
    }

    public byte[] Pack(IsoMessage isoMessage)
    {
        // Message Length (2 Byte - 4BCD) + Header (5 Bytes) + MTI(2 Bytes - 4BCD Pack) + Bitmap(8 to 24 Bytes) + Fields data.


        int length = 0;
        List<byte[]> packedData = new(128);

        if (isoMessage.HasHeader())
        {
            byte[] headerData = isoMessage.GetHeader();
            length += headerData.Length;
            packedData.Add(headerData);
        }

        if (isoMessage.HasMti())
        {
            byte[] mtiData = isoMessage.GetMti();
            length += mtiData.Length;
            packedData.Add(mtiData);
        }

        if (GetBitmapType() != BitmapTypeEnum.PrimaryBitmap)
        {
            // todo: remove hardcoded position
            byte[] bitmapFieldData = FieldMap[GetBitmapFieldKey()].Pack(isoMessage.Get(-1));
            packedData.Add(bitmapFieldData);
            length += FieldMap[GetBitmapFieldKey()].MaxLength;
        }

        if (GetBitmapType() != BitmapTypeEnum.SecondaryBitmap)
        {
            throw new IsoException("Packager does not support SecondaryBitmap");
        }

        for (int i = 1; i < isoMessage.GetFields().Count(); i++)
        {
            IsoField field = isoMessage.Get(i);
            byte[] packedItem = FieldMap[field.Key].Pack(field);
            length += packedItem.Length;
            packedData.Add(packedItem);
        }

        // foreach (var item in isoMessage.GetFields())
        // {
        //
        //     byte[] packedItem = FieldMap[item.Key].Pack(item);
        //     length += packedItem.Length;
        //     packedData.Add(packedItem);
        // }

        // byte[] lengthData = new byte [2];
        // lengthData = IsoCharset.ISO_8859_1.GetBytes(length.ToString().PadLeft(4, '0'));
        // packedData.Insert(0, lengthData);

        return packedData.SelectMany(e => e).ToArray();
    }
    
}