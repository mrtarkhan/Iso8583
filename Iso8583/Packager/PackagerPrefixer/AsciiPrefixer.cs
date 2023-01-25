namespace Iso8583.Packager.PackagerPrefixer;

/// <inheritdoc />
public class AsciiPrefixer : IPrefixer
{
    /// <summary>
    /// A length prefixer for up to 9 chars.
    /// The length is encoded with 1 ASCII char representing 1 decimal digit.
    /// </summary>
    public static readonly AsciiPrefixer L = new(1);


    /// <summary>
    /// A length prefixer for up to 99 chars.
    /// The length is encoded with 2 ASCII chars representing 2 decimal digits.
    /// </summary>
    /// <returns></returns>
    public static readonly AsciiPrefixer LL = new(2);


    /// <summary>
    /// A length prefixer for up to 999 chars.
    /// The length is encoded with 3 ASCII chars representing 3 decimal digits.
    /// </summary>
    /// <returns></returns>
    public static readonly AsciiPrefixer LLL = new(3);


    /// <summary>
    /// A length prefixer for up to 9999 chars.
    /// The length is encoded with 4 ASCII chars representing 4 decimal digits.
    /// </summary>
    /// <returns></returns>
    public static readonly AsciiPrefixer LLLL = new(4);


    /// <summary>
    /// A length prefixer for up to 99999 chars.
    /// The length is encoded with 5 ASCII chars representing 5 decimal digits.
    /// </summary>
    public static readonly AsciiPrefixer LLLLL = new(5);


    /// <summary>
    /// A length prefixer for up to 999999 chars.
    /// The length is encoded with 6 ASCII chars representing 6 decimal digits.
    /// </summary>
    /// <returns></returns>
    public static readonly AsciiPrefixer LLLLLL = new(6);


    private readonly int _packedLength;


    public AsciiPrefixer(int nDigits)
    {
        _packedLength = nDigits;
    }


    /// <summary>
    /// The number of digits allowed to express the length
    /// </summary>
    public int GetPackedLength()
    {
        return _packedLength;
    }

    public void EncodeLength(int length, byte[] data)
    {
        for (int i = _packedLength - 1; i >= 0; i--)
        {
            data[i] = (byte)(length % 10 + '0');
            length /= 10;
        }

        if (length != 0)
        {
            throw new IsoException("invalid len " + length + ". Prefixing digits = " + _packedLength);
        }
    }

    public int DecodeLength(byte[] data, int offset)
    {
        int len = 0;
        for (int i = 0; i < _packedLength; i++)
        {
            byte d = data[offset + i];
            if (d < '0' || d > '9')
            {
                throw new IsoException("Invalid character found. Expected digit.");
            }

            len = len * 10 + d - (byte)'0';
        }

        return len;
    }
}