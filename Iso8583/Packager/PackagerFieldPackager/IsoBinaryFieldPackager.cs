using Iso8583.Packager.PackagerInterpreter;
using Iso8583.Packager.PackagerPrefixer;

namespace Iso8583.Packager.PackagerFieldPackager;

/// <inheritdoc />
public class IsoBinaryFieldPackager : IsoFieldPackager
{
    private IBinaryInterpreter _interpreter;
    private IPrefixer _prefixer;


    public IsoBinaryFieldPackager(int len, string description, IBinaryInterpreter interpreter, IPrefixer prefixer) : base(len,
        description)
    {
        _interpreter = interpreter;
        _prefixer = prefixer;
    }


    public override byte[] Pack(IsoField field)
    {
        try
        {
            byte[] data = field.Value is string ? IsoCharset.ISO_8859_1.GetBytes(field.GetValue<String>()) : field.GetValue<byte[]>();

            int packedLength = _prefixer.GetPackedLength();
            if (packedLength == 0 && data.Length != MaxLength)
            {
                throw new IsoException("Binary data length not the same as the packager length (" + data.Length + "/" + MaxLength + ")");
            }

            byte[] result = new byte[_interpreter.GetPackedLength(data.Length) + packedLength];
            _prefixer.EncodeLength(data.Length, result);
            _interpreter.Interpret(data, result, packedLength);
            return result;
        }
        catch (Exception e)
        {
            throw new IsoException(MakeExceptionMessage(field, "packing"), e);
        }
    }


    public override int UnPack(IsoField field, byte[] data, int offset)
    {
        try
        {
            int lenLen = _prefixer.GetPackedLength();
            int len;
            if (lenLen == 0)
            {
                len = MaxLength;
            }
            else
            {
                len = _prefixer.DecodeLength(data, 0);
                if (MaxLength > 0 && len > 0 && len > MaxLength)
                    throw new IsoException($"Field length {len} is too long. Max: {MaxLength}");
            }

            byte[] unPackedData = _interpreter.UnInterpret(data, offset + _prefixer.GetPackedLength(), len);

            field = IsoField.Create(field.Key, unPackedData);

            return _prefixer.GetPackedLength() + _interpreter.GetPackedLength(len);
        }
        catch (IsoException e)
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

    private String MakeExceptionMessage(IsoField field, String operation)
    {
        return $"{GetType().FullName} Problem {operation} {field.Key}";
    }
}