namespace Iso8583.MessageTypeIndicator;

public class IsoMessageFunction
{
    /// <summary>
    /// Value = 0
    /// </summary>
    public static readonly IsoMessageFunction Request = new("0");

    /// <summary>
    /// Value = 1
    /// </summary>
    public static readonly IsoMessageFunction RequestResponse = new("1");

    /// <summary>
    /// Value = 2
    /// </summary>
    public static readonly IsoMessageFunction Advice = new("2");

    /// <summary>
    /// Value = 3
    /// </summary>
    public static readonly IsoMessageFunction AdviceResponse = new("3");

    /// <summary>
    /// Value = 4
    /// </summary>
    public static readonly IsoMessageFunction Notification = new("4");

    /// <summary>
    /// Value = 5
    /// </summary>
    public static readonly IsoMessageFunction NotificationAcknowledgement = new("5");

    /// <summary>
    /// Value = 6
    /// </summary>
    public static readonly IsoMessageFunction Instruction = new("6");

    /// <summary>
    /// Value = 7
    /// </summary>
    public static readonly IsoMessageFunction InstructionAcknowledgement = new("7");

    /// <summary>
    /// Value = 8
    /// </summary>
    public static readonly IsoMessageFunction Reserved8 = new("8");

    /// <summary>
    /// Value = 9
    /// </summary>
    public static readonly IsoMessageFunction Reserved9 = new("9");


    public string Value { get; }

    private IsoMessageFunction(string value)
    {
        Value = value;
    }

    public static IsoMessageFunction FromValue(string value)
    {
        return value switch
        {
            "0" => Request,
            "1" => RequestResponse,
            "2" => Advice,
            "3" => AdviceResponse,
            "4" => Notification,
            "5" => NotificationAcknowledgement,
            "6" => Instruction,
            "7" => InstructionAcknowledgement,
            "8" => Reserved8,
            "9" => Reserved9,
            _ => throw new IsoException("MTI function value is incorrect")
        };
    }
}