using Iso8583.MessageTypeIndicator;
using Iso8583.Packager;

namespace Iso8583;

public class Builder
{
    private IsoMessageVersion _isoVersion;
    private IsoMessageClass _isoMessageType;
    private IsoMessage _message;
    private IsoPackager _packager;
    
    public Builder(IsoMessageVersion version)
    {
        _isoVersion = version;
        _message = IsoMessage.Create();
        _isoMessageType = IsoMessageClass.Authorization;
        _packager = new CardSystemAsciiXAPackager();
    }
    
    
    
    
}