using Iso8583.Packager.PackagerInterpreter;
using Iso8583.Packager.PackagerPadder;
using Iso8583.Packager.PackagerPrefixer;

namespace Iso8583.Packager.PackagerFieldPackager;

/// <inheritdoc />
public class IFA_LLLCHAR : IsoStringFieldPackager
{
        
    public IFA_LLLCHAR(
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
    public IFA_LLLCHAR(int len, string description) :
        base(
            len
            , description
            , NullPadder.Instance
            , AsciiInterpreter.Instance
            , AsciiPrefixer.LLL
        )
    {
        CheckLength(len, 999);
    }
}