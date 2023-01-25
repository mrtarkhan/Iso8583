using Iso8583.MessageTypeIndicator;

namespace Iso8583;

public class IsoHeader
{
    public MTI Mti { get; set; }
    
    public byte[] Pack()
    {
        return new byte[0];
    }
}