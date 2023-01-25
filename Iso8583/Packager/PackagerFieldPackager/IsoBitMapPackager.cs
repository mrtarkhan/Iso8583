using System.Collections;

namespace Iso8583.Packager.PackagerFieldPackager;

public abstract class IsoBitMapPackager : IsoFieldPackager
{
    public IsoBitMapPackager(int len, String description) : base(len, description)
    {
    }

    public override byte[] Pack(IsoField field)
    {
        BitArray data = field.GetValue<BitArray>();
        
        // change the length of bits to bytes
        // int len = MaxLength >= 8 ? data.Length + 62 >> 6 << 3 : MaxLength;

        var resultSigned = BitArray2ByteArray(data);
        byte[] result = new byte[resultSigned.Length];

        for (int i = 0; i < resultSigned.Length; i++)
        {
            result[i] = (byte)resultSigned[i];
        }

        return result;
    }


    // public static String HexString(byte[] dataBytes)
    // {
    //     StringBuilder result = new StringBuilder(dataBytes.Length * 2);
    //
    //     foreach (var item in dataBytes)
    //     {
    //         result.Append(item);
    //     }
    //
    //     for (byte item in dataBytes) {
    //         result.Append(HexStrings[(int)aB & 0xFF]);
    //     }
    //
    //     return d.toString();
    // }

    public static sbyte[] BitArray2ByteArray(BitArray arr)
    {
        // +62 because we don't use bit 0 in the BitSet
        int numberOfBits = arr.Length + 62 >> 6 << 6;

        sbyte[] result = new sbyte[numberOfBits >> 3];

        for (int i = 0; i < numberOfBits; ++i)
        {
            // +1 because we don't use bit 0 of the BitArray
            if (i + 1 < numberOfBits && arr.Get(i + 1))
            {
                result[i >> 3] |= (sbyte)(0x80 >> i % 8);
            }
        }

        if (numberOfBits > 64)
        {
            result[0] |= unchecked((sbyte)0x80);
        }

        if (numberOfBits > 128)
        {
            result[8] |= unchecked((sbyte)0x80);
        }

        return result;
    }

    public static BitArray ByteArray2BitArray(byte[] arr, int offset, int len)
    {
        return null;
    }

    public override int UnPack(IsoField field, byte[] dataBytes, int offset)
    {
        int length;
        BitArray bitMap = ByteArray2BitArray(dataBytes, offset, MaxLength << 3);

        // field = IsoField.Create(field.Key, dataBytes);

        length = bitMap.Get(1) ? 128 : 64;
        if (MaxLength > 16 && bitMap.Get(65))
        {
            length = 192;
            bitMap.Set(65, false);
        }

        return Math.Min(MaxLength << 1, length >> 2);
    }
}