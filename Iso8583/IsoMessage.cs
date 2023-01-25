using System.Collections;
using System.Text;
using Iso8583.MessageTypeIndicator;
using Iso8583.Packager;
using Iso8583.Packager.PackagerFieldPackager;

namespace Iso8583;

public class IsoMessage
{
    private int _length;
    private IsoHeader _header;
    private MTI? _mti = null;

    // contains bitmap
    private SortedDictionary<Int32, IsoField> _fields = new();

    private IsoPackager _packager;


    public int Direction { get; private set; }


    private WeakReference sourceRef;

    // helper fields
    private bool _isDirty, _maxFieldDirty = false;
    private int _maxField = 0;

    private byte[] packedData;
    private bool isPacked = false;

    // constants
    private const int Incoming = 1;
    private const int Outgoing = 2;


    #region constructors

    private IsoMessage()
    {
    }

    /// <summary>
    /// Creates an empty IsoMessage
    /// </summary>
    /// <returns>Initialized message</returns>
    public static IsoMessage Create()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        return new();
    }

    #endregion

    /// <summary>
    /// sets direction field to 1 
    /// </summary>
    /// <returns>changed message</returns>
    public IsoMessage SetAsIncomingMessage()
    {
        Direction = Incoming;
        return this;
    }

    /// <summary>
    /// sets direction field to 2
    /// </summary>
    /// <returns>changed message</returns>
    public IsoMessage SetAsOutgoingMessage()
    {
        Direction = Outgoing;
        return this;
    }

    public IsoMessage SetHeader(IsoHeader header)
    {
        _header = header;
        return this;
    }

    public byte[] GetHeader()
    {
        return _header?.Pack() ?? Array.Empty<byte>();
    }

    public IsoMessage SetPackager(IsoPackager packager)
    {
        _packager = packager;
        return this;
    }

    public IsoMessage Set(IsoField field)
    {
        int index = field.Key;
        _fields.Add(index, field);

        if (index > _maxField)
            _maxField = index;

        _isDirty = true;

        return this;
    }

    public IsoMessage Set(int field, string value)
    {
        Set(IsoField.Create(field, value));
        return this;
    }


    public IsoMessage WithMti(MTI mti)
    {
        _mti = mti;
        Set(IsoFieldDefault.F0_MTI.WithValue(mti.Value));
        return this;
    }

    /// <summary>
    /// Unset a field if it exists, otherwise ignore.
    /// </summary>
    /// <param name="field"></param>
    public void UnSet(int field)
    {
        if (_fields.Remove(field) == false)
            _isDirty = _maxFieldDirty = true;
    }


    public byte[] Pack()
    {
        if (!_isDirty)
            return packedData;

        packedData = _packager.Pack(this);
        _isDirty = false;
        return packedData;
    }

    public IsoField Get(int key)
    {
        return _fields.FirstOrDefault(e => e.Key == key).Value;
    }

    // todo: implement these functions
    // merge, clone, isrequest, isresponse, mti helper methods 

    public bool HasHeader()
    {
        return _header.Pack().Length > 0;
    }

    public IEnumerable<IsoField> GetFields()
    {
        return _fields.Values;
    }

    public BitArray GetPrimaryBitMap()
    {
        throw new NotImplementedException();
    }

    public BitArray GetSecondaryBitMap()
    {
        throw new NotImplementedException();
    }

    public BitArray GetTertiaryBitMap()
    {
        throw new NotImplementedException();
    }

    public void ReCalculateMaxField()
    {
        // maxKey
        
        // create bitmap using maxkey to 128 or 192
        
        foreach (var item in _fields)
        {
            if (item.Value.Value is int)
            {
                _maxField = Math.Max(_maxField, item.Value.GetValue<int>());
            }
        }
    }
    
    public IsoMessage GenerateMac(IMacGenerator generator)
    {
        if (!isPacked)
            Pack();

        byte[] mac = generator.Generate(packedData);
        Set(IsoFieldDefault.F128_MAC.WithValue(IsoCharset.ISO_8859_1.GetString(mac)));
        return this;
    }

    public IsoMessage GenerateBitmap()
    {
        BitArray primaryBitmap = new BitArray(_packager.GetBitmapPackagerSize() * 8);

        for (int i = 1; i < primaryBitmap.Count; i++)
        {
            primaryBitmap.Set(i, _fields.ContainsKey(i));            
        }
  
        // foreach (var field in _fields)
        // {
        //     primaryBitmap.Set(field.Key, !primaryBitmap.Get(field.Key));
        // }

        Set(IsoFieldDefault.F_PrimaryBitmap.WithValue(primaryBitmap));

        return this;
    }

    public bool HasMti()
    {
        return _mti != null;
    }

    public byte[] GetMti()
    {
        return IsoCharset.ISO_8859_1.GetBytes(_mti?.Value ?? throw new IsoException("MTI is null"));
    }
}