namespace Iso8583.Packager.PackagerPrefixer;

/// <inheritdoc />
public class NullPrefixer : IPrefixer
{
    /// <summary>
    /// A handy instance of the null prefixer.
    /// </summary>
    public static readonly NullPrefixer Instance = new NullPrefixer();


    /// <summary>
    /// Hidden Ctor
    /// </summary>
    private NullPrefixer()
    {
    }

    public int GetPackedLength()
    {
        return 0;
    }

    public void EncodeLength(int length, byte[] data)
    {
    }


    /// <summary>
    /// Returns -1 meaning there is no length field.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    public int DecodeLength(byte[] data, int offset) => -1;
}