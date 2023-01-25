namespace Iso8583.MessageTypeIndicator;

public class IsoMessageOrigin
{
    public static readonly IsoMessageOrigin Acquirer = new("0");
    public static readonly IsoMessageOrigin AcquirerRepeat = new("1");
    public static readonly IsoMessageOrigin Issuer = new("2");
    public static readonly IsoMessageOrigin IssuerRepeat = new("3");
    public static readonly IsoMessageOrigin Other = new("4");
    public static readonly IsoMessageOrigin Reserved1 = new("10");
    public static readonly IsoMessageOrigin Reserved60 = new("60");
    public static readonly IsoMessageOrigin Reserved6 = new("6");
    public static readonly IsoMessageOrigin Reserved41 = new("41");

    public string Value { get; }

    private IsoMessageOrigin(string value)
    {
        Value = value;
    }

    public static IsoMessageOrigin FromValue(string value)
    {
        return value switch
        {
            "0" => Acquirer,
            "1" => AcquirerRepeat,
            "2" => Issuer,
            "3" => IssuerRepeat,
            "4" => Other,
            "10" => Reserved1,
            "60" => Reserved60,
            "6" => Reserved6,
            "41" => Reserved41,
            _ => throw new IsoException("MTI origin value is incorrect")
        };
    }
}