using Iso8583.Packager.PackagerFieldPackager;

namespace Iso8583.Packager;

public class CardSystemAsciiXAPackager : IsoBasePackager
{
    public CardSystemAsciiXAPackager()
    {
        ConfigFieldMap(
            /*000*/ new IFA_NUMERIC(4, "Message Type Indicator"),
            /*001*/ new IFA_BITMAP(16, "Bitmap"),
            /*002*/ new IFA_LLNUM(19, "Primary Account number"),
            /*003*/ new IFA_NUMERIC(6, "Processing Code"),
            /*004*/ new IFA_NUMERIC(12, "Amount, Transaction"),
            /*005*/ new IFA_NUMERIC(12, "Amount, Reconciliation"),
            /*006*/ new IFA_NUMERIC(12, "Amount, Cardholder Billing"),
            /*007*/ new IFA_NUMERIC(10, "Date and time, Transmission"),
            /*008*/ new IFA_NUMERIC(8, "Amount, Cardholder billing fee"),
            /*009*/ new IFA_NUMERIC(8, "Conversion rate, Reconciliation"),
            /*010*/ new IFA_NUMERIC(8, "Conversion rate, Cardholder billing"),
            /*011*/ new IFA_NUMERIC(6, "Systems trace audit number"),
            /*012*/ new IFA_NUMERIC(12, "Date and time, Local transaction"),
            /*013*/ new IFA_NUMERIC(4, "Date, Effective"),
            /*014*/ new IFA_NUMERIC(4, "Date, Expiration"),
            /*015*/ new IFA_NUMERIC(6, "Date, Settlement"),
            /*016*/ new IFA_NUMERIC(4, "Date, Conversion"),
            /*017*/ new IFA_NUMERIC(4, "Date, Capture"),
            /*018*/ new IFA_NUMERIC(4, "Merchant type"),
            /*019*/ new IFA_NUMERIC(3, "Country code, Acquiring institution"),
            /*020*/ new IFA_NUMERIC(3, "Country code, Primary account number"),
            /*021*/ new IFA_NUMERIC(3, "Country code, Forwarding institution"),
            /*022*/ new IF_CHAR(12, "Point of service data code"),
            /*023*/ new IFA_NUMERIC(3, "Card sequence number"),
            /*024*/ new IFA_NUMERIC(3, "Function code"),
            /*025*/ new IFA_NUMERIC(4, "POS Condition Code"),
            /*026*/ new IFA_NUMERIC(4, "Card acceptor business code"),
            /*027*/ new IFA_NUMERIC(1, "Approval code length"),
            /*028*/ new IFA_NUMERIC(6, "Reconciliation Date"),
            /*029*/ new IFA_NUMERIC(3, "Reconciliation indicator"),
            /*030*/ new IFA_NUMERIC(24, "Amounts, original"),
            /*031*/ new IFA_LLCHAR(99, "Acquirer reference data"),
            /*032*/ new IFA_LLNUM(11, "Acquirer institution identification code"),
            /*033*/ new IFA_LLNUM(11, "Forwarding institution identification code"),
            /*034*/ new IFA_LLCHAR(28, "Primary account number, extended"),
            /*035*/ new IFA_LLCHAR(37, "Track 2 data"),
            /*036*/ new IFA_LLLCHAR(104, "Track 3 data"),
            /*037*/ new IF_CHAR(12, "Retrieval reference number"),
            /*038*/ new IF_CHAR(6, "Approval code"),
            /*039*/ new IFA_NUMERIC(3, "Action code"),
            /*040*/ new IF_CHAR(3, "Service code"),
            /*041*/ new IF_CHAR(8, "Card acceptor terminal identification"),
            /*042*/ new IF_CHAR(15, "Card acceptor identification code"),
            /*043*/ new IFA_LLCHAR(99, "Card acceptor name/location"),
            /*044*/ new IFA_LLCHAR(99, "Additional response data"),
            /*045*/ new IFA_LLCHAR(76, "Track 1 data"),
            /*046*/ new IFA_LLLCHAR(204, "Amounts, Fees"),
            /*047*/ new IFA_LLLCHAR(999, "Additional data - national"),
            /*048*/ new IFA_LLLCHAR(999, "Additional data - private"), //used for Visa field 48 and MasterCard field 44
            /*049*/ new IFA_NUMERIC(3, "Currency code, Transaction"),
            /*050*/ new IFA_NUMERIC(3, "Currency code, Reconciliation"),
            /*051*/ new IFA_NUMERIC(3, "Currency code, Cardholder billing"),
            /*052*/ new IF_CHAR(16, "Personal identification number (PIN) data"),
            /*053*/ new IFA_LLCHAR(99, "Security related control information"),
            /*054*/ new IFA_LLLCHAR(120, "Amounts, additional"),
            /*055*/ new IFA_LLLBINARY(255, "IC card system related data"),
            /*056*/ new IFA_LLNUM(99, "Original data elements"),
            /*057*/ new IFA_NUMERIC(3, "Authorization life cycle code"),
            /*058*/ new IFA_LLNUM(11, "Authorizing agent institution Id Code"),
            /*059*/ new IFA_LLLCHAR(999, "Transport data"),
            /*060*/ new IFA_LLLCHAR(999, "Reserved for national use"),
            /*061*/ new IFA_LLLCHAR(999, "Reserved for national use"),
            /*062*/ new IFA_LLLBINARY(999, "Reserved for private use"),
            /*063*/ new IFA_LLLCHAR(999, "Reserved for private use"),
            /*064*/ new IF_CHAR(16, "Message authentication code field"),
            /*065*/ new IFA_BINARY(8, "Reserved for ISO use"),
            /*066*/ new IFA_LLLCHAR(204, "Amounts, original fees"),
            /*067*/ new IFA_NUMERIC(2, "Extended payment data"),
            /*068*/ new IFA_NUMERIC(3, "Country code, receiving institution"),
            /*069*/ new IFA_NUMERIC(3, "Country code, settlement institution"),
            /*070*/ new IF_CHAR(3, "Country code, authorizing agent Inst."),
            /*071*/ new IFA_NUMERIC(8, "Message number"),
            /*072*/ new IFA_LLLCHAR(999, "Data record"),
            /*073*/ new IF_CHAR(6, "Date, action"),
            /*074*/ new IFA_NUMERIC(10, "Credits, number"),
            /*075*/ new IFA_NUMERIC(10, "Credits, reversal number"),
            /*076*/ new IFA_NUMERIC(10, "Debits, number"),
            /*077*/ new IFA_NUMERIC(10, "Debits, reversal number"),
            /*078*/ new IFA_NUMERIC(10, "Transfer, number"),
            /*079*/ new IFA_NUMERIC(10, "Transfer, reversal number"),
            /*080*/ new IFA_NUMERIC(10, "Inquiries, number"),
            /*081*/ new IFA_NUMERIC(10, "Authorizations, number"),
            /*082*/ new IFA_NUMERIC(10, "Inquiries, reversal number"),
            /*083*/ new IFA_NUMERIC(10, "Payments, number"),
            /*084*/ new IFA_NUMERIC(10, "Payments, reversal number"),
            /*085*/ new IFA_NUMERIC(10, "Fee collections, number"),
            /*086*/ new IFA_NUMERIC(16, "Credits, amount"),
            /*087*/ new IFA_NUMERIC(16, "Credits, reversal amount"),
            /*088*/ new IFA_NUMERIC(16, "Debits, amount"),
            /*089*/ new IFA_NUMERIC(16, "Debits, reversal amount"),
            /*090*/ new IFA_NUMERIC(10, "Original Data Elements"),
            /*091*/ new IFA_NUMERIC(3, "Country code, transaction Dest. Inst."),
            /*092*/ new IFA_NUMERIC(3, "Country code, transaction Orig. Inst."),
            /*093*/ new IFA_LLNUM(11, "Transaction Dest. Inst. Id code"),
            /*094*/ new IFA_LLNUM(11, "Transaction Orig. Inst. Id code"),
            /*095*/ new IF_CHAR(99, "Replacement Amounts"),
            /*096*/ new IFA_LLLCHAR(999, "Key management data"),
            /*097*/ new IFA_AMOUNT(1 + 16, "Amount, Net reconciliation"),
            /*098*/ new IF_CHAR(25, "Payee"),
            /*099*/ new IFA_LLNUM(11, "Settlement institution Id code"),
            /*100*/ new IFA_LLNUM(11, "Receiving institution Id code"),
            /*101*/ new IFA_LLCHAR(17, "File name"),
            /*102*/ new IFA_LLCHAR(28, "Account identification 1"),
            /*103*/ new IFA_LLCHAR(28, "Account identification 2"),
            /*104*/ new IFA_LLLCHAR(100, "Transaction description"),
            /*105*/ new IFA_NUMERIC(16, "Credits, Chargeback amount"),
            /*106*/ new IFA_NUMERIC(16, "Debits, Chargeback amount"),
            /*107*/ new IFA_NUMERIC(10, "Credits, Chargeback number"),
            /*108*/ new IFA_NUMERIC(10, "Debits, Chargeback number"),
            /*109*/ new IFA_LLCHAR(84, "Credits, Fee amounts"),
            /*110*/ new IFA_LLCHAR(84, "Debits, Fee amounts"),
            /*111*/ new IFA_LLLCHAR(999, "Reserved for ISO use"),
            /*112*/ new IFA_LLLCHAR(999, "Reserved for ISO use"),
            /*113*/ new IFA_LLLCHAR(999, "Reserved for ISO use"),
            /*114*/ new IFA_LLLCHAR(999, "Reserved for ISO use"),
            /*115*/ new IFA_LLLCHAR(999, "Reserved for ISO use"),
            /*116*/ new IFA_LLLCHAR(999, "Reserved for national use"),
            /*117*/ new IFA_LLLCHAR(999, "Reserved for national use"),
            /*118*/ new IFA_LLLCHAR(999, "Reserved for national use"),
            /*119*/ new IFA_LLLCHAR(999, "Reserved for national use"),
            /*120*/ new IFA_LLLCHAR(999, "Reserved for national use"),
            /*121*/ new IFA_LLLCHAR(999, "Reserved for national use"),
            /*122*/ new IFA_LLLCHAR(999, "Reserved for national use"),
            /*123*/ new IFA_LLLCHAR(999, "Reserved for private use"),
            /*124*/ new IFA_LLLCHAR(999, "Reserved for private use"),
            /*125*/ new IFA_LLLCHAR(999, "Reserved for private use"),
            /*126*/ new IFA_LLLCHAR(999, "Reserved for private use"),
            /*127*/ new IFA_LLLCHAR(999, "Reserved for private use"),
            /*128*/ new IF_CHAR(16, "Message authentication code field")
        );
    }


    public override int GetBitmapFieldKey()
    {
        return 1;
    }
}