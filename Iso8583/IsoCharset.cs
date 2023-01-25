using System.Text;

namespace Iso8583;

public static class IsoCharset
{
    /// <summary>
    /// ASCII-Based ISO_8859_1 | Windows-1252
    /// </summary>
    public static readonly Encoding ISO_8859_1 = Encoding.GetEncoding("Windows-1252");

    //public static readonly Encoding EBCDIC = Encoding.GetEncoding("IBM1047");
    public static readonly Encoding ASCII = Encoding.ASCII;
    public static readonly Encoding UTF8 = Encoding.UTF8;
}