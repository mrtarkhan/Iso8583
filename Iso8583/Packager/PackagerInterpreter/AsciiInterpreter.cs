namespace Iso8583.Packager.PackagerInterpreter;

/// <summary>
/// Implements ASCII Interpreter. Strings are converted to and from ASCII bytes.
/// This uses the US-ASCII encoding which all JVMs must support.
/// </summary>
public class AsciiInterpreter : IInterpreter
{
    /// <summary>
    /// An instance of this Interpreter. Only one needed for the whole system
    /// </summary>
    /// <returns></returns>
    public static readonly AsciiInterpreter Instance = new();


    public void Interpret(string data, byte[] dataBytes, int offset)
    {
        Array.Copy(IsoCharset.ISO_8859_1.GetBytes(data), 0, dataBytes, offset, data.Length);
    }

    public string UnInterpret(byte[] rawData, int offset, int length)
    {
        byte[] result = new byte[length];
        try
        {
            Array.Copy(rawData, offset, result, 0, length);
            return IsoCharset.ISO_8859_1.GetString(result);
        }
        catch (Exception e)
        {
            throw new IsoException($"Required {length} but just got {rawData.Length - offset} bytes", e);
        }
    }

    public int GetPackedLength(int nDataUnits)
    {
        return nDataUnits;
    }
}