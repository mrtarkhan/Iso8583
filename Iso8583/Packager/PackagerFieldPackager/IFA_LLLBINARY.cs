using Iso8583.Packager.PackagerInterpreter;
using Iso8583.Packager.PackagerPrefixer;

namespace Iso8583.Packager.PackagerFieldPackager;

/// <inheritdoc />
public class IFA_LLLBINARY : IsoBinaryFieldPackager
{
    public IFA_LLLBINARY(int len, string description) :
        base(len
            , description, LiteralBinaryInterpreter.Instance
            , AsciiPrefixer.LLL
        )
    {
        CheckLength(len, 999);
    }
}