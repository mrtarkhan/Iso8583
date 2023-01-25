namespace Iso8583.MessageTypeIndicator;

public class MTI
{
    public IsoMessageClass MessageClass { get; }
    public IsoMessageVersion MessageVersion { get; }
    public IsoMessageFunction MessageFunction { get; }
    public IsoMessageOrigin MessageOrigin { get; }

    public string Value { get; }


    private MTI(
        IsoMessageVersion messageVersion,
        IsoMessageClass messageClass,
        IsoMessageFunction messageFunction,
        IsoMessageOrigin messageOrigin)
    {
        MessageClass = messageClass;
        MessageVersion = messageVersion;
        MessageFunction = messageFunction;
        MessageOrigin = messageOrigin;

        Value = $"{messageVersion.Value}{messageClass.Value}{messageFunction.Value}{messageOrigin.Value}";
    }

    public static MTI? Create(
        IsoMessageVersion isoMessageVersion,
        IsoMessageClass isoMessageClass,
        IsoMessageFunction isoMessageFunction,
        IsoMessageOrigin isoMessageOrigin)
    {
        return new MTI(isoMessageVersion, isoMessageClass, isoMessageFunction, isoMessageOrigin);
    }

    public MTI(string mtiStr)
    {
        if (string.IsNullOrEmpty(mtiStr))
            throw new IsoException("MTI is required");

        if (mtiStr.Length != 4 || int.TryParse(mtiStr, out _) == false)
            throw new IsoException("MTI contains four digit number from 0 to 9, ex: 1100");

        string versionChar = mtiStr.Substring(0, 1);
        string classChar = mtiStr.Substring(1, 1);
        string functionChar = mtiStr.Substring(2, 1);
        string originChar = mtiStr.Substring(3, 1);

        MessageVersion = IsoMessageVersion.FromValue(versionChar);
        MessageClass = IsoMessageClass.FromValue(classChar);
        MessageFunction = IsoMessageFunction.FromValue(functionChar);
        MessageOrigin = IsoMessageOrigin.FromValue(originChar);

        Value = mtiStr;
    }
}