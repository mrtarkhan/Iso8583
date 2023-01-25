namespace Iso8583.MessageTypeIndicator;

public class IsoMessageClass
{
    /// <summary>
    /// Value = 0
    /// </summary>
    public static readonly IsoMessageClass Reserved0 = new("0");

    /// <summary>
    /// Value = 1
    /// </summary>
    public static readonly IsoMessageClass Authorization = new("1");

    /// <summary>
    /// Value = 2
    /// </summary>
    public static readonly IsoMessageClass Financial = new("2");

    /// <summary>
    /// Value = 3
    /// </summary>
    public static readonly IsoMessageClass FileActions = new("3");

    /// <summary>
    /// Value = 4
    /// </summary>
    public static readonly IsoMessageClass Reversal = new("4");

    /// <summary>
    /// Value = 5
    /// </summary>
    public static readonly IsoMessageClass Reconciliation = new("5");

    /// <summary>
    /// Value = 6
    /// </summary>
    public static readonly IsoMessageClass Administrative = new("6");

    /// <summary>
    /// Value = 7
    /// </summary>
    public static readonly IsoMessageClass FeeCollection = new("7");

    /// <summary>
    /// Value = 8
    /// </summary>
    public static readonly IsoMessageClass NetworkManagement = new("8");

    /// <summary>
    /// Value = 9
    /// </summary>
    public static readonly IsoMessageClass Reserved9 = new("9");


    public string Value { get; }

    private IsoMessageClass(string value)
    {
        Value = value;
    }

    public static IsoMessageClass FromValue(string value)
    {
        return value switch
        {
            "0" => Reserved0,
            "1" => Authorization,
            "2" => Financial,
            "3" => FileActions,
            "4" => Reversal,
            "5" => Reconciliation,
            "6" => Administrative,
            "7" => FeeCollection,
            "8" => NetworkManagement,
            "9" => Reserved9,
            _ => throw new IsoException("MTI class value is incorrect")
        };
    }
}