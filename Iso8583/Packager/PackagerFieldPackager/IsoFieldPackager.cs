namespace Iso8583.Packager.PackagerFieldPackager;

public abstract class IsoFieldPackager
{
    public int MaxLength { get; }
    public String Description { get; }
    public bool MustBePadded { get; protected set; }
    public bool MustBeTrimmed { get; protected set; }
    public bool IsRequired { get; protected set; }


    public IsoFieldPackager()
    {
        MaxLength = -1;
        Description = null;
    }

    /// <summary>
    /// sets the length and description for field packager
    /// </summary>
    /// <param name="len">maxLength The maximum length of the field in characters or bytes depending on the datatype</param>
    /// <param name="description">description The description of the field. For human readable output</param>
    public IsoFieldPackager(int len, String description)
    {
        MaxLength = len;
        Description = description;
    }


    public IsoField CreateComponent(int fieldNumber)
    {
        return IsoField.ValueOf(fieldNumber);
    }

    /// <summary>
    /// Packs the field into a byte[].
    /// </summary>
    /// <param name="field"></param>
    /// <returns>the result byte array based on specified encoding (IsoConstants.CharSet)</returns>
    /// <exception cref="IsoException"></exception>
    public abstract byte[] Pack(IsoField field);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="field">field to unpack</param>
    /// <param name="bytes">binary image</param>
    /// <param name="offset">starting offset within the binary image</param>
    /// <returns>consumed bytes</returns>
    /// <exception cref="IsoException"></exception>
    public abstract int UnPack(IsoField field, byte[] bytes, int offset);
}