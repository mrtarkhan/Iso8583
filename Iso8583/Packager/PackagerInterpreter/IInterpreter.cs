namespace Iso8583.Packager.PackagerInterpreter;

public interface IInterpreter
{
    /// <summary>
    /// Converts the string data into a different interpretation.
    /// Standard interpretations are ASCII, EBCDIC, BCD and LITERAL.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="streamData"></param>
    /// <param name="offset"></param>
    /// <exception cref="IsoException"></exception>
    void Interpret(string data, byte[] streamData, int offset);

    /// <summary>
    /// Converts the byte array into a String. This reverses the interpret method.
    /// </summary>
    /// <param name="rawData">The interpreted data.</param>
    /// <param name="offset">The index in rawData to start interpreting at.</param>
    /// <param name="length">The number of data units to interpret.</param>
    /// <exception cref="IsoException"></exception>
    /// <returns>The uninterpreted data.</returns>
    String UnInterpret(byte[] rawData, int offset, int length);

    /// <summary>
    /// Returns the number of bytes required to interpret a String of length nDataUnits.
    /// </summary>
    /// <param name="nDataUnits"></param>
    /// <returns></returns>
    int GetPackedLength(int nDataUnits);
}