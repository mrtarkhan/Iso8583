using Iso8583.Packager.PackagerInterpreter;
using Iso8583.Packager.PackagerPadder;
using Iso8583.Packager.PackagerPrefixer;

namespace Iso8583.Packager.PackagerFieldPackager;

public class IsoStringFieldPackager : IsoFieldPackager
{
    private IInterpreter _interpreter;
    private IPadder _padder;
    private IPrefixer _prefixer;

    // public IsoStringFieldPackager()
    // {
    //     this._padder = new NullPadder();
    //     this._interpreter = new LiteralInterpreter;
    //     this._prefixer = new NullPrefixer;
    // }

    public IsoStringFieldPackager(IPadder padder, IInterpreter interpreter, IPrefixer prefixer)
    {
        _padder = padder;
        _interpreter = interpreter;
        _prefixer = prefixer;
    }

    public IsoStringFieldPackager(int length, string description, IPadder padder, IInterpreter interpreter, IPrefixer prefixer)
        : base(length, description)
    {
        _padder = padder;
        _interpreter = interpreter;
        _prefixer = prefixer;

        MustBePadded = padder != null;
    }


    public override byte[] Pack(IsoField field)
    {
        try
        {
            string data = field.GetValue<string>();
            string paddedData = string.Empty;

            if (string.IsNullOrEmpty(data) && IsRequired)
            {
                throw new IsoException($"Field {field.Name} is required");
            }

            if (data.Length > MaxLength)
            {
                throw new IsoException($"Field length {data.Length} is too long. Max: {MaxLength}");
            }

            if (MustBePadded)
            {
                paddedData = _padder.Pad(data, MaxLength);
            }

            byte[] rawData = new byte[(_prefixer.GetPackedLength() + _interpreter.GetPackedLength(paddedData.Length))];
            _prefixer.EncodeLength(paddedData.Length, rawData);
            _interpreter.Interpret(paddedData, rawData, _prefixer.GetPackedLength());

            return rawData;
        }
        catch (Exception e)
        {
            throw new IsoException(MakeExceptionMessage(field, "packing"), e);
        }
    }

    private String MakeExceptionMessage(IsoField field, String operation)
    {
        return $"{GetType().FullName} Problem {operation} {field.Key}:{field.Value}";
    }


    /// <summary>
    /// Unpacks the byte array into the field.
    /// </summary>
    /// <param name="field"></param>
    /// <param name="data"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    /// <exception cref="IsoException"></exception>
    public override int UnPack(IsoField field, byte[] data, int offset)
    {
        try
        {
            int len = _prefixer.DecodeLength(data, offset);
            if ((len == -1))
            {
                //  The prefixer doesn't know how long the field is, so use maxLength instead
                len = MustBeTrimmed ? Math.Min(MaxLength, data.Length - offset) : MaxLength;
            }
            else if (MaxLength > 0 && len > MaxLength)
            {
                throw new IsoException($"Field length ({len}) is too long. Max: {MaxLength}");
            }

            String unPackedData = _interpreter.UnInterpret(data, offset + _prefixer.GetPackedLength(), len);

            field = IsoField.Create(field.Key, unPackedData);

            return _prefixer.GetPackedLength() + _interpreter.GetPackedLength(len);
        }
        catch (Exception e)
        {
            throw new IsoException(MakeExceptionMessage(field, "unpacking"), e);
        }
    }

    protected void CheckLength(int len, int maxLength)
    {
        if (len > maxLength)
        {
            throw new IsoException($"Length {{len}} is too long for {this.GetType().FullName}");
        }
    }
}