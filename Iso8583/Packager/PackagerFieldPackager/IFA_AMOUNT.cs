using Iso8583.Packager.PackagerInterpreter;
using Iso8583.Packager.PackagerPadder;
using Iso8583.Packager.PackagerPrefixer;

namespace Iso8583.Packager.PackagerFieldPackager;

/// <inheritdoc />
public class IFA_AMOUNT : IsoFieldPackager
{
    private IInterpreter _interpreter;
    private IPadder _padder;
    private IPrefixer _prefixer;

    public IFA_AMOUNT(IPadder padder, IInterpreter interpreter, IPrefixer prefixer)
    {
        _padder = padder;
        _interpreter = interpreter;
        _prefixer = prefixer;
    }

    public IFA_AMOUNT(int len, string description) : base(len, description)
    {
    }

    /// <summary>
    /// creates an amount packager for amount field
    /// </summary>
    /// <param name="length">maxLength The maximum length of the field in characters or bytes depending on the datatype.</param>
    /// <param name="description">description The description of the field. For human readable output.</param>
    /// <param name="padder">padder The type of padding used.</param>
    /// <param name="interpreter">interpreter The interpreter used to encode the field.</param>
    /// <param name="prefixer">prefixer The type of length prefixer used to encode this field.</param>
    public IFA_AMOUNT(int length, string description, IPadder padder, IInterpreter interpreter, IPrefixer prefixer)
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
            string data = field.GetValue<String>();
            String sign = data.Substring(0, 1);
            String amount = data.Substring(1);

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
                paddedData = _padder.Pad(amount, MaxLength - 1);
            }

            int signLength = _interpreter.GetPackedLength(1);

            byte[] rawData = new byte[_prefixer.GetPackedLength() + signLength + _interpreter.GetPackedLength(paddedData.Length)];
            _prefixer.EncodeLength(paddedData.Length, rawData);
            _interpreter.Interpret(sign, rawData, _prefixer.GetPackedLength() + signLength);

            return rawData;
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
            int len = _prefixer.DecodeLength(data, offset);
            if (len == -1)
            {
                //  The prefixer doesn't know how long the field is, so use maxLength instead
                len = MaxLength;
            }
            else if (MaxLength > 0 && len > MaxLength)
            {
                throw new IsoException($"Field length {len} is too long. Max: {MaxLength}");
            }

            String unpacked = _interpreter.UnInterpret(data, (offset + _prefixer.GetPackedLength()), len);

            field = IsoField.Create(field.Key, unpacked);

            return _prefixer.GetPackedLength() + _interpreter.GetPackedLength(len);
        }
        catch (Exception e)
        {
            throw new IsoException(MakeExceptionMessage(field, "unpacking"), e);
        }
    }


    /// <summary>
    /// Checks the length of the data against the maximum, and throws an ArgumentException
    /// This is designed to be called from field Packager constructors and the setLength()
    /// </summary>
    /// <param name="len">The length of the data for this field packager.</param>
    /// <param name="maxLength">The maximum length allowed for this type of field packager. This depends on the prefixer that is used.</param>
    /// <exception cref="ArgumentException"></exception>
    protected void CheckLength(int len, int maxLength)
    {
        if (len > maxLength)
        {
            throw new ArgumentException($"Length {len} is too long for {GetType().FullName}");
        }
    }


    /// <summary>
    /// creates a readable exception
    /// </summary>
    /// <param name="field"></param>
    /// <param name="operation"></param>
    /// <returns></returns>
    private String MakeExceptionMessage(IsoField field, String operation)
    {
        return $"{GetType().FullName} Problem {operation} {field.Key}:{field.Value}";
    }
}