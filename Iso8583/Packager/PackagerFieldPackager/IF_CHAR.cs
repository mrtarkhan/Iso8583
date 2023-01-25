using Iso8583.Packager.PackagerInterpreter;
using Iso8583.Packager.PackagerPadder;
using Iso8583.Packager.PackagerPrefixer;

namespace Iso8583.Packager.PackagerFieldPackager;

/// <inheritdoc />
public class IF_CHAR : IsoStringFieldPackager
{
    public IF_CHAR(
        IPadder padder,
        IInterpreter interpreter,
        IPrefixer prefixer) : base(padder, interpreter, prefixer)
    {
    }

    /// <summary>
    /// creates a new IF_CHAR FieldPackager
    /// </summary>
    /// <param name="len">field length</param>
    /// <param name="description">symbolic description</param>
    public IF_CHAR(int len, string description) :
        base(
            len
            , description
            , RightPadder.SpacePadder
            , LiteralInterpreter.Instance
            , NullPrefixer.Instance
        )
    {
    }
}