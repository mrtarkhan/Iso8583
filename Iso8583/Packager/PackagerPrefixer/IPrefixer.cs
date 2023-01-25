namespace Iso8583.Packager.PackagerPrefixer;

public interface IPrefixer
{
    int GetPackedLength();
    void EncodeLength(int length, byte[] data);
    int DecodeLength(byte[] data, int offset);
}