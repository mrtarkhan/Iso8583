using System.Text;

namespace Iso8583.Packager.PackagerPadder;

/// <summary>
/// Implements the Padder interface for padding strings and byte arrays on the right
/// </summary>
public class RightPadder : IPadder
{
    /// <summary>
    /// A padder for padding spaces on the right. This is very common in alphabetic fields.
    /// </summary>
    public static readonly RightPadder SpacePadder = new RightPadder(' ');


    private char _padCharacter;

    public RightPadder(char padCharacter)
    {
        _padCharacter = padCharacter;
    }

    public string Pad(string data, int maxLength)
    {
        if (data == null)
            throw new IsoException("RightPadder: Data cannot be null");

        int len = data.Length;
        if (len < maxLength)
        {
            StringBuilder padded = new StringBuilder(maxLength);
            padded.Append(data);
            for (; len < maxLength; len++)
            {
                padded.Append(_padCharacter);
            }

            data = padded.ToString();
        }

        else if (len > maxLength)
        {
            throw new IsoException("Data is too long. Max = " + maxLength);
        }

        return data;
    }

    public String UnPad(String paddedData)
    {
        int len = paddedData.Length;
        for (int i = len; i > 0; i--)
        {
            if (paddedData[i - 1] != _padCharacter)
            {
                return paddedData.Substring(0, i);
            }
        }

        return "";
    }
}