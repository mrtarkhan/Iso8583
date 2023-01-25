namespace Iso8583.MessageTypeIndicator;

public class IsoMessageVersion
{
    /// <summary>
    /// Version 1987 | Value = 0
    /// </summary>
    public static readonly IsoMessageVersion V1987 = new("0");

    /// <summary>
    /// Version 1993 | Value = 1
    /// </summary>
    public static readonly IsoMessageVersion V1993 = new("1");

    /// <summary>
    /// Version 2003 | Value = 2
    /// </summary>
    public static readonly IsoMessageVersion V2003 = new("2");


    public string Value { get; }

    private IsoMessageVersion(string value)
    {
        Value = value;
    }
    
    
    public static IsoMessageVersion FromValue(string value)
    {
        return value switch
        {
            "0" => V1987,
            "1" => V1993,
            "2" => V2003,
            _ => throw new IsoException("MTI version value is incorrect")
        };
    }
}