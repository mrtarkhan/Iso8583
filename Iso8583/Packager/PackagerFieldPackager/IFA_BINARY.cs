using Iso8583.Packager.PackagerInterpreter;
using Iso8583.Packager.PackagerPrefixer;

namespace Iso8583.Packager.PackagerFieldPackager;

/// <inheritdoc />
public class IFA_BINARY : IsoBinaryFieldPackager
{
    public IFA_BINARY(int len, string description) :
        base(
            len
            , description, AsciiHexInterpreter.Instance
            , NullPrefixer.Instance)
    {
    }
}