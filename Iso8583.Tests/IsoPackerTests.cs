using System.Text;
using Iso8583.MessageTypeIndicator;
using Iso8583.Packager;

namespace Iso8583.Tests;

public class UnitTest1
{
    public UnitTest1()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    
    
    /*
     * TCP keep alive
     * SendTcpNoDelay = true
     * RemoteSync = true
     * ConcurrentTransaction
     * Buffer = 8192
     * g-c-x
     */
    

    [Fact]
    public void pack_iso_message_to_string()
    {
        var expectedResultInString =
            "";

        var macGenerator =
            new Ansi99MacGenerator(IsoCharset.ASCII.GetBytes("1C1C1C1C"));

        DateTime now = DateTime.Now;

        IsoMessage isoMsg =
                IsoMessage
                    .Create()
                    .WithMti(MTI_1993.AuthorizationRequest())
                    .SetAsIncomingMessage()
                    .SetHeader(new IsoHeader())
                    .SetPackager(new CardSystemBinaryXAPackager())
                    .Set(IsoFieldDefault.F2_PAN.WithValue("5894631100004444"))
                    .Set(IsoFieldDefault.F3_ProcessCode.WithValue("330000"))
                    .Set(IsoFieldDefault.F4_Amount_Transaction.WithValue("000000010000"))
                    .Set(IsoFieldDefault.F6_Amount_Cardholder.WithValue("000000010000"))
                    .Set(IsoFieldDefault.F7_TransmissionDataTime.WithValue("0814131426"))
                    .Set(IsoFieldDefault.F11_STAN.WithValue("123456"))
                    .Set(IsoFieldDefault.F12_LocalTime.WithValue("220814131426"))
                    .Set(IsoFieldDefault.F13_LocalDate.WithValue("0000"))
                    .Set(IsoFieldDefault.F14_ExpirationDate.WithValue("0000"))
                    .Set(IsoFieldDefault.F17_CaptureDate.WithValue("0000"))
                    .Set(IsoFieldDefault.F18_MerchantType.WithValue("0000"))
                    .Set(IsoFieldDefault.F19_AcquiringInstitution.WithValue("000"))
                    .Set(IsoFieldDefault.F21_ForwardingInstitution.WithValue("000"))
                    .Set(IsoFieldDefault.F22_POS_Data.WithValue("000000000000"))
                    .Set(IsoFieldDefault.F24_FunctionCode.WithValue("702"))
                    .Set(IsoFieldDefault.F32_AcquiringInstitutionIdCode.WithValue("000013"))
                    .Set(IsoFieldDefault.F33_ForwardingInstitutionIdCode.WithValue("000013"))
                    .Set(IsoFieldDefault.F37_RRN.WithValue("0000000000"))
                    .Set(IsoFieldDefault.F41_CA_TerminalID.WithValue("00000000"))
                    .Set(IsoFieldDefault.F42_CA_ID.WithValue("00000000000   "))
                    .Set(IsoFieldDefault.F43_CardAcceptorInfo.WithValue("Bank Tehran THRIR----------------"))
                    .Set(IsoFieldDefault.F48_AddData_Private.WithValue("P010"))
                    .Set(IsoFieldDefault.F49_CurrencyCode_Transactoion.WithValue("364"))
                    .Set(IsoFieldDefault.F50_CurrencyCode_Settlement.WithValue("364"))
                    .Set(IsoFieldDefault.F51_CurrencyCode_Cardholder.WithValue("364"))
                    .Set(
                        IsoFieldDefault.F53_SecurityControlInfo.WithValue("security-things"))
                    .Set(
                        IsoFieldDefault.F60_Reserved_National.WithValue("somthing"))
                    .Set(IsoFieldDefault.F72_Data_Record.WithValue("BTI"))
                    .Set(IsoFieldDefault.F102_Account_Identification_1.WithValue("11111111"))
                    .Set(IsoFieldDefault.F103_Account_Identification_2.WithValue("11111111"))
                    .GenerateBitmap()
            ;

        
        //49,49,48,48 | -10,60,-19,1,-120,-31,-24,16,1,0,0

        string ISO_MESSAGE_HEADER = "ISO51000000";
        var packedData = isoMsg.Pack();
        string length = $"{packedData.Length + 11}".PadLeft(4, '0') + ISO_MESSAGE_HEADER;
        byte[] header = IsoCharset.ISO_8859_1.GetBytes(length);
        byte[] finalData = new byte[header.Length + packedData.Length];
        Array.Copy(header, 0, finalData, 0, header.Length);
        Array.Copy(packedData, 0, finalData, header.Length, packedData.Length);

        var resultInString = IsoCharset.UTF8.GetString(finalData);

        Assert.Equal(expectedResultInString, resultInString);
    }


    [Fact]
    public void platform_has_ascii()
    {
        var encoder = Encoding.GetEncoding("Windows-1252");

        var bytes = encoder.GetBytes("ascii");
        var result = encoder.GetString(bytes);

        Assert.Equal("ascii", result);
    }
}