using Iso8583.Packager.PackagerInterpreter;
using Iso8583.Packager.PackagerPadder;
using Iso8583.Packager.PackagerPrefixer;

namespace Iso8583.Packager.PackagerFieldPackager;

/// <inheritdoc />
public class IFA_LLCHAR : IsoStringFieldPackager
{
    public IFA_LLCHAR(
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
    public IFA_LLCHAR(int len, string description) :
        base(
            len
            , description
            , NullPadder.Instance
            , AsciiInterpreter.Instance
            , AsciiPrefixer.LL
        )
    {
        CheckLength(len, 99);
    }
}