using Iso8583.Packager.PackagerFieldPackager;

namespace Iso8583;

public class IsoFieldDefault : IsoField
{
    public static readonly IsoField F_PrimaryBitmap = new IsoBitMap("F_PrimaryBitmap", -1);
    public static readonly IsoField F0_MTI = new IsoField("F0_MTI", 0);
    public static readonly IsoField F1_SecondaryBitmap = new IsoBitMap("F1_SecondaryBitmap", 1);
    public static readonly IsoField F2_PAN = new("F2_PAN", 2);
    public static readonly IsoField F3_ProcessCode = new("F3_ProcessCode", 3);
    public static readonly IsoField F4_Amount_Transaction = new("F4_Amount_Transaction", 4);
    public static readonly IsoField F5_Amount_Settlement = new("F5_Amount_Settlement", 5);
    public static readonly IsoField F6_Amount_Cardholder = new("F6_Amount_Fee_Cardholder", 6);
    public static readonly IsoField F7_TransmissionDataTime = new("F7_TransmissionDataTime", 7);
    public static readonly IsoField F8_AmountCardholder_BillingFee = new("F8_AmountCardholder_BillingFee", 8);
    public static readonly IsoField F9_ConversionRate_Settlement = new("F9_ConversionRate_Settlement", 9);
    public static readonly IsoField F10_ConversionRate_Cardholder = new("F10_ConversionRate_Cardholder", 10);
    public static readonly IsoField F11_STAN = new("F11_STAN", 11);
    public static readonly IsoField F12_LocalTime = new("F12_LocalTime", 12);
    public static readonly IsoField F13_LocalDate = new("F13_LocalDate", 13);
    public static readonly IsoField F14_ExpirationDate = new("F14_ExpirationDate", 14);
    public static readonly IsoField F15_SettlementDate = new("F15_SettlementDate", 15);
    public static readonly IsoField F16_CurrencyConversionDate = new("F16_CurrencyConversionDate", 16);
    public static readonly IsoField F17_CaptureDate = new("F17_CaptureDate", 17);
    public static readonly IsoField F18_MerchantType = new("F18_MerchantType", 18);
    
    /// <summary>
    /// ACQUIRE_COUNTRY_CODE
    /// </summary>
    public static readonly IsoField F19_AcquiringInstitution = new("F19_AcquiringInstitution", 19);
    public static readonly IsoField F20_PANExtended = new("F20_PANExtended", 20);
    public static readonly IsoField F21_ForwardingInstitution = new("F21_ForwardingInstitution", 21);
    
    /// <summary>
    /// POINT_OF_SERVICE_DATA_CODE | F22_EntryMode
    /// </summary>
    public static readonly IsoField F22_POS_Data = new("F22_POS_Data", 22);
    public static readonly IsoField F23_PANSequence = new("F23_PANSequence", 23);
    public static readonly IsoField F24_FunctionCode = new("F24_NII_FunctionCode", 24);
    
    /// <summary>
    /// REVERSAL_REASON_CODE
    /// </summary>
    public static readonly IsoField F25_POS_ConditionCode = new("F25_POS_ConditionCode", 25); 
    
    /// <summary>
    /// CARD_ACCEPTOR_BUSINESS_CODE
    /// </summary>
    public static readonly IsoField F26_POS_CaptureCode = new("F26_POS_CaptureCode", 26);     
    public static readonly IsoField F27_AuthIdResponseLength = new("F27_AuthIdResponseLength", 27);
    public static readonly IsoField F28_Amount_TransactionFee = new("F28_Amount_TransactionFee", 28);
    public static readonly IsoField F29_Amount_SettlementFee = new("F29_Amount_SettlementFee", 29);

    public static readonly IsoField F30_Amount_TransactionProcessingFee =
        new("F30_Amount_TransactionProcessingFee", 30); // ORIGINAL_AMOUNT

    public static readonly IsoField F31_Amount_SettlementProcessingFee = new("F31_Amount_SettlementProcessingFee", 31);

    public static readonly IsoField F32_AcquiringInstitutionIdCode = new("F32_AcquiringInstitutionIdCode", 32);

    public static readonly IsoField F33_ForwardingInstitutionIdCode = new("F33_ForwardingInstitutionIdCode", 33);

    public static readonly IsoField F34_PAN_Extended = new("F34_PAN_Extended", 34);
    public static readonly IsoField F35_Track2 = new("F35_Track2", 35);
    public static readonly IsoField F36_Track3 = new("F36_Track3", 36);
    
    /// <summary>
    /// RETRIEVAL_REFERENCE_NO
    /// </summary>
    public static readonly IsoField F37_RRN = new("F37_RRN", 37); 
    public static readonly IsoField F38_AuthIdResponse = new("F38_AuthIdResponse", 38);
    public static readonly IsoField F39_ResponseCode = new("F39_ResponseCode", 39);
    public static readonly IsoField F40_ServiceRestrictionCode = new("F40_ServiceRestrictionCode", 40);
    
    /// <summary>
    /// CARD_ACCEPT_TERMINAL_ID
    /// </summary>
    public static readonly IsoField F41_CA_TerminalID = new("F41_CA_TerminalID", 41); 
    
    /// <summary>
    /// CARD_ACCEPT_ID_CODE
    /// </summary>
    public static readonly IsoField F42_CA_ID = new("F42_CA_ID", 42); 
    
    
    /// <summary>
    /// CARD_ACCEPT_NAME_LOCATION
    /// </summary>
    public static readonly IsoField F43_CardAcceptorInfo = new("F43_CardAcceptorInfo", 43);
    
    /// <summary>
    ///  ADDITIONAL_RESPONSE_DATA
    /// </summary>
    public static readonly IsoField F44_AddResponseData = new("F44_AddResponseData", 44);
    public static readonly IsoField F45_Track1 = new("F45_Track1", 45);
    /// <summary>
    /// FEES_AMOUNT
    /// </summary>
    public static readonly IsoField F46_AddData_ISO = new("F46_AddData_ISO", 46);   
    
    public static readonly IsoField F47_AddData_National = new("F47_AddData_National", 47);
    
    /// <summary>
    /// ADDITIONAL_PRIVATE_DATA
    /// </summary>
    public static readonly IsoField F48_AddData_Private = new("F48_AddData_Private", 48);
    
    public static readonly IsoField F49_CurrencyCode_Transactoion = new("F49_CurrencyCode_Transactoion", 49);
    public static readonly IsoField F50_CurrencyCode_Settlement = new("F50_CurrencyCode_Settlement", 50);
    public static readonly IsoField F51_CurrencyCode_Cardholder = new("F51_CurrencyCode_Cardholder", 51);
    public static readonly IsoField F52_PIN = new("F52_PIN", 52);
    
    /// <summary>
    /// SECURITY_RELATED_CONTROL_INFORMATION
    /// </summary>
    public static readonly IsoField F53_SecurityControlInfo = new("F53_SecurityControlInfo", 53);
    public static readonly IsoField F54_AddAmount = new("F54_AddAmount", 54);
    public static readonly IsoField F55_ICC = new("F55_ICC", 55);
    
    /// <summary>
    /// ORIGINAL_DATA_ELEMENTS
    /// </summary>
    public static readonly IsoField F56_OriginalDataElements = new("F56_OriginalDataElements", 56);
    
    
    public static readonly IsoField F57_Reserved_National = new("F57_Reserved_National", 57);
    public static readonly IsoField F58_Reserved_National = new("F58_Reserved_National", 58);
    public static readonly IsoField F59_Reserved_National = new("F59_Reserved_National", 59);
    public static readonly IsoField F60_Reserved_National = new("F60_Reserved_National", 60);
    public static readonly IsoField F61_Reserved_Private = new("F61_Reserved_Private", 61);
    public static readonly IsoField F62_Reserved_Private = new("F62_Reserved_Private", 62);
    public static readonly IsoField F63_Reserved_Private = new("F63_Reserved_Private", 63);
    public static readonly IsoField F64_Reserved_National = new("F64_Reserved_National", 64);
    public static readonly IsoField F65_Reserved_National = new("F65_Reserved_National", 65);
    public static readonly IsoField F66_Reserved_National = new("F66_Reserved_National", 66);
    public static readonly IsoField F67_Reserved_National = new("F67_Reserved_National", 67);
    public static readonly IsoField F68_Reserved_Private = new("F68_Reserved_Private", 68);
    public static readonly IsoField F69_Reserved_Private = new("F69_Reserved_Private", 69);
    
    public static readonly IsoField F70_Network_Management_Information_Code = new("F70_Network_Management_Information_Code", 70);
    public static readonly IsoField F71_Reserved_National = new("F71_Reserved_National", 71);
    public static readonly IsoField F72_Data_Record = new("F72_Data_Record", 72);
    public static readonly IsoField F73_Data_Action = new("F73_Data_Action", 73);
    public static readonly IsoField F74_Credits_Number = new("F74_Credits_Number", 74);
    public static readonly IsoField F75_Credits_Reversal_Number = new("F75_Credits_Reversal_Number", 75);
    public static readonly IsoField F76_Debits_Number = new("F76_Debits_Number", 76);
    public static readonly IsoField F77_Debits_Reversal_Number = new("F77_Debits_Reversal_Number", 77);
    public static readonly IsoField F78_Transfer_Number = new("F78_Transfer_Number", 78);
    public static readonly IsoField F79_Transfer_Reversal_Number = new("F79_Transfer_Reversal_Number", 79);
    public static readonly IsoField F80_Inquiries_Number = new("F80_Inquiries_Number", 80);
    public static readonly IsoField F81_Authorizations_Number = new("F81_Authorizations_Number", 81);
    public static readonly IsoField F82_Reserved_Private = new("F82_Reserved_Private", 82);
    public static readonly IsoField F83_Reserved_Private = new("F83_Reserved_Private", 83);
    public static readonly IsoField F84_Reserved_Private = new("F84_Reserved_Private", 84);
    public static readonly IsoField F85_Reserved_National = new("F85_Reserved_National", 85);
    public static readonly IsoField F86_Credits_Amount = new("F86_Credits_Amount", 86);
    public static readonly IsoField F87_Credits_Reversal_Amount = new("F87_Credits_Reversal_Amount", 87);
    public static readonly IsoField F88_Debits_Amount = new("F88_Debits_Amount", 88);
    public static readonly IsoField F89_Debits_Reversal_Amount = new("F89_Debits_Reversal_Amount", 89);
    public static readonly IsoField F90_Reserved_Private = new("F90_Reserved_Private", 90);
    public static readonly IsoField F91_Reserved_Private = new("F91_Reserved_Private", 91);
    public static readonly IsoField F92_Reserved_Private = new("F92_Reserved_Private", 92);
    public static readonly IsoField F93_Transaction_Destination_InstitutionId_Code = new("F93_Transaction_Destination_InstitutionId_Code", 93);
    public static readonly IsoField F94_Transaction_Original_InstitutionId_Code = new("F94_Transaction_Original_InstitutionId_Code", 94);
    public static readonly IsoField F95_Replacement_Amounts = new("F95_Replacement_Amounts", 95);
    public static readonly IsoField F96_Key_Management_Data = new("F96_Key_Management_Data", 96);
    public static readonly IsoField F97_Net_Reconciliation_Amount = new("F97_Net_Reconciliation_Amount", 97);
    public static readonly IsoField F98_Reserved_Private = new("F98_Reserved_Private", 98);
    public static readonly IsoField F99_Reserved_Private = new("F99_Reserved_Private", 99);
    public static readonly IsoField F100_Receiving_Institution_Id_Code = new("F100_Receiving_Institution_Id_Code", 100);
    public static readonly IsoField F101_File_Name = new("F101_File_Name", 101);
    public static readonly IsoField F102_Account_Identification_1 = new("F102_Account_Identification_1", 102);
    public static readonly IsoField F103_Account_Identification_2 = new("F103_Account_Identification_2", 103);
    public static readonly IsoField F104_Transaction_Description = new("F104_Transaction_Description", 104);
    public static readonly IsoField F105_Default_Destination_Account_Number = new("F105_Default_Destination_Account_Number", 105);
    public static readonly IsoField F106_Reserved_Private = new("F106_Reserved_Private", 106);
    public static readonly IsoField F107_Reserved_Private = new("F107_Reserved_Private", 107);
    public static readonly IsoField F108_Reserved_Private = new("F108_Reserved_Private", 108);
    public static readonly IsoField F109_Reserved_Private = new("F109_Reserved_Private", 109);
    public static readonly IsoField F110_Reserved_Private = new("F110_Reserved_Private", 110);
    public static readonly IsoField F111_International_Account_Verification_Data = new("F111_International_Account_Verification_Data", 111);
    public static readonly IsoField F112_Reserved_Private = new("F112_Reserved_Private", 112);
    public static readonly IsoField F113_Reserved_Private = new("F113_Reserved_Private", 113);
    public static readonly IsoField F114_Reserved_Private = new("F114_Reserved_Private", 114);
    public static readonly IsoField F115_Additional_Response_Data = new("F115_Additional_Response_Data", 115);
    public static readonly IsoField F116_Phone_Access_Parameter = new("F116_Phone_Access_Parameter", 116);
    public static readonly IsoField F117_Mobile_Access_Parameter = new("F117_Mobile_Access_Parameter", 117);
    public static readonly IsoField F118_IP_Access_Parameter = new("F118_IP_Access_Parameter", 118);
    public static readonly IsoField F119_Reserved_Private = new("F119_Reserved_Private", 119);
    public static readonly IsoField F120_Reserved_Private = new("F120_Reserved_Private", 120);
    public static readonly IsoField F121_Reserved_Private = new("F121_Reserved_Private", 121);
    public static readonly IsoField F122_Reserved_Private = new("F122_Reserved_Private", 122);
    public static readonly IsoField F123_Reserved_Private = new("F123_Reserved_Private", 123);
    public static readonly IsoField F124_Private_Used = new("F124_Private_Used", 124);
    public static readonly IsoField F125_Reserved_Private = new("F125_Reserved_Private", 125);
    public static readonly IsoField F126_Reserved_Private = new("F126_Reserved_Private", 126);
    public static readonly IsoField F127_Reserved_Private = new("F127_Reserved_Private", 127);
    public static readonly IsoField F128_MAC = new("F128_MAC", 128);
    
    
    
    
    
    
}