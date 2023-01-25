using Iso8583.Packager.PackagerInterpreter;
using Iso8583.Packager.PackagerPadder;
using Iso8583.Packager.PackagerPrefixer;

namespace Iso8583.Packager.PackagerFieldPackager;

/// <inheritdoc />
public class IFA_NUMERIC : IsoStringFieldPackager
{
    public IFA_NUMERIC() : base(
        NullPadder.Instance
        , AsciiInterpreter.Instance
        , AsciiPrefixer.LL
    )
    {
    }

    public IFA_NUMERIC(int len, String description) :
        base(len
            , description
            , LeftPadder.ZeroPadder
            , AsciiInterpreter.Instance
            , NullPrefixer.Instance)
    {
    }
}