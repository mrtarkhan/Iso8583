namespace Iso8583.Packager.PackagerInterpreter;

public class LiteralInterpreter : IInterpreter
{
    public static readonly LiteralInterpreter Instance = new();

    public void Interpret(string data, byte[] destinationArray, int offset)
    {
        byte[] rawData = IsoCharset.ISO_8859_1.GetBytes(data);
        Array.Copy(rawData, 0, destinationArray, offset, rawData.Length);
    }

    public string UnInterpret(byte[] rawData, int offset, int length)
    {
        return IsoCharset.ISO_8859_1.GetString(rawData, offset, length);
    }

    public int GetPackedLength(int nDataUnits)
    {
        return nDataUnits;
    }
}