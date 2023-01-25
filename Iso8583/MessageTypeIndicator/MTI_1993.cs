namespace Iso8583.MessageTypeIndicator;

public static class MTI_1993
{
    
    public static MTI? AuthorizationRequest()
    {
        return MTI.Create(IsoMessageVersion.V1993, IsoMessageClass.Authorization, IsoMessageFunction.Request, IsoMessageOrigin.Acquirer);
    }

}