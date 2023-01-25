namespace Iso8583;

/// <summary>
/// imohsenb.iso8583.crypto
/// </summary>
public interface IMacGenerator
{
    byte[] Generate(byte[] data);
}