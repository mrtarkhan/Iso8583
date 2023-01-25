namespace Iso8583.Packager.PackagerInterpreter;

public interface IBinaryInterpreter
{
    /**
	 * Converts the binary data into a different interpretation or coding. Standard
	 * interpretations are ASCII Hex, EBCDIC Hex, BCD and LITERAL.
	 * 
	 * @param data
	 *            The data to be interpreted.
	 * @param b The byte array to write the interpreted data to.
     * @param offset The starting position in b.
	 */
    void Interpret(byte[] data, byte[] b, int offset);

    /**
	 * Converts the raw byte array into a uninterpreted byte array. This reverses the
     * interpret method.
	 * 
	 * @param rawData
	 *            The interpreted data.
	 * @param offset
	 *            The index in rawData to start uninterpreting at.
	 * @param length
	 *            The number of uninterpreted bytes to uninterpret. This number may be
     *            different from the number of raw bytes that are uninterpreted.
	 * @return The uninterpreted data.
	 */
    byte[] UnInterpret(byte[] rawData, int offset, int length);

    /**
	 * Returns the number of bytes required to interpret a byte array of length
	 * nBytes.
	 */
    int GetPackedLength(int nBytes);
}