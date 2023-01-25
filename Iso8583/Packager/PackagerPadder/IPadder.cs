namespace Iso8583.Packager.PackagerPadder;

public interface IPadder
{
    string Pad(string data, int length);
    string UnPad(string paddedData);
}