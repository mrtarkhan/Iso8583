namespace Iso8583.Packager.PackagerInterpreter;

/// <summary>
/// This interpreter does no conversion and leaves the input the same as the output.
/// </summary>
public class LiteralBinaryInterpreter : IBinaryInterpreter
{
    public static readonly LiteralBinaryInterpreter Instance = new();

    private LiteralBinaryInterpreter()
    {
    }

    public void Interpret(byte[] rawData, byte[] streamData, int offset)
    {
        Array.Copy(rawData, 0, streamData, offset, rawData.Length);
    }

    public byte[] UnInterpret(byte[] rawData, int offset, int length)
    {
        byte[] result = new byte[length];
        Array.Copy(rawData, offset, result, 0, length);
        return result;
    }

    public int GetPackedLength(int nDataUnits)
    {
        return nDataUnits;
    }
}