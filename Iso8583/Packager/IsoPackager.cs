namespace Iso8583.Packager;

public interface IsoPackager
{
    byte[] Pack(IsoMessage isoMessage);
    IsoMessage UnPack(byte[] inputData);
    int GetBitmapPackagerSize();
}