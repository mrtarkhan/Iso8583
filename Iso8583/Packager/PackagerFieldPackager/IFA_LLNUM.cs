using Iso8583.Packager.PackagerInterpreter;
using Iso8583.Packager.PackagerPadder;
using Iso8583.Packager.PackagerPrefixer;

namespace Iso8583.Packager.PackagerFieldPackager;

/// <inheritdoc />
public class IFA_LLNUM : IsoStringFieldPackager
{
    public IFA_LLNUM() : base(
        NullPadder.Instance
        , AsciiInterpreter.Instance
        , AsciiPrefixer.LL
    )
    {
    }

    public IFA_LLNUM(int len, String description) :
        base(len
            , description
            , NullPadder.Instance
            , AsciiInterpreter.Instance
            , AsciiPrefixer.LL)
    {
        CheckLength(len, 99);
    }
}