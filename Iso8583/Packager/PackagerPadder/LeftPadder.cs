using System.Text;

namespace Iso8583.Packager.PackagerPadder;

/// <summary>
/// Implements the Padder interface for padding strings and byte arrays on the right
/// </summary>
public class LeftPadder : IPadder
{
    /// <summary>
    /// A padder for padding zeros on the left. This is very common in numeric.
    /// </summary>
    public static readonly LeftPadder ZeroPadder = new LeftPadder('0');


    private char _padCharacter;

    public LeftPadder(char padCharacter)
    {
        _padCharacter = padCharacter;
    }

    public string Pad(string data, int maxLength)
    {
        if (data == null)
            throw new IsoException("LeftPadder: Data cannot be null");

        int len = data.Length;
        if (len < maxLength)
        {
            StringBuilder padded = new StringBuilder(maxLength);
            for (int i = maxLength - len; i > 0; i--)
            {
                padded.Append(_padCharacter);
            }

            padded.Append(data);
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
        int i = 0;
        int len = paddedData.Length;
        while (i < len)
        {
            if (paddedData[i] != _padCharacter)
            {
                return paddedData.Substring(i);
            }
            i++;
        }

        return "";
    }
}