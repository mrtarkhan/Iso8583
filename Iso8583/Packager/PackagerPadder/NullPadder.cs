namespace Iso8583.Packager.PackagerPadder;

/// <summary>
/// Null padder do not pad data at all
/// </summary>
public class NullPadder : IPadder
{
    public static readonly NullPadder Instance = new();

    public string Pad(string data, int length)
    {
        return data;
    }

    public string UnPad(string paddedData)
    {
        return paddedData;
    }
}