using System.Collections;

namespace Iso8583.Packager.PackagerFieldPackager;

/// <inheritdoc />
public class IsoBitMap : IsoField
{
    public IsoBitMap(string name, int no) : base(name, no)
    {
    }
}