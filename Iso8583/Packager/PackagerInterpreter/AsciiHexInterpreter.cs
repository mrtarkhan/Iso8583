namespace Iso8583.Packager.PackagerInterpreter;

public class AsciiHexInterpreter : IBinaryInterpreter
{
    /// <summary>
    /// An instance of this Interpreter. Only one needed for the whole system
    /// </summary>
    /// <returns></returns>
    public static readonly AsciiHexInterpreter Instance = new();


    private AsciiHexInterpreter()
    {
    }

    /// <summary>
    /// 0-15 to ASCII hex digit lookup table.
    /// </summary>
    private static readonly byte[] HEX_ASCII = {
        0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37,
        0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46
    };

    /// <summary>
    /// Converts the binary data into ASCII hex digits.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="dataBytes"></param>
    /// <param name="offset"></param>
    public void Interpret(byte[] data, byte[] dataBytes, int offset)
    {
        for (int i = 0; i < data.Length; i++)
        {
            dataBytes[offset + i * 2] = HEX_ASCII[(data[i] & 0xF0) >> 4];
            dataBytes[offset + i * 2 + 1] = HEX_ASCII[data[i] & 0x0F];
        }
    }

    /// <summary>
    /// Converts the ASCII hex digits into binary data.
    /// </summary>
    /// <param name="rawData"></param>
    /// <param name="offset"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public byte[] UnInterpret(byte[] rawData, int offset, int length)
    {
        byte[] result = new byte[length];

        for (int i = 0; i < length * 2; i++)
        {
            int shift = i % 2 == 1 ? 0 : 4;

            var uninterpretedRawData = Digit((char)rawData[offset + i], 16) << shift;

            result[i >> 1] = (byte)(uninterpretedRawData | result[i >> 1]);
        }

        return result;
    }

    /// <summary>
    /// Returns double nBytes because the hex representation of 1 byte needs 2 hex digits.
    /// </summary>
    /// <param name="nDataUnits">number of bytes</param>
    /// <returns></returns>
    public int GetPackedLength(int nDataUnits)
    {
        return nDataUnits * 2;
    }

    private static int Digit(char value, int radix)
    {
        if ((radix <= 0) || (radix > 36))
            return -1; // Or throw exception

        if (radix <= 10)
            if (value >= '0' && value < '0' + radix)
                return value - '0';
            else
                return -1;
        if (value >= '0' && value <= '9')
            return value - '0';
        if (value >= 'a' && value < 'a' + radix - 10)
            return value - 'a' + 10;
        if (value >= 'A' && value < 'A' + radix - 10)
            return value - 'A' + 10;

        return -1;
    }
}
