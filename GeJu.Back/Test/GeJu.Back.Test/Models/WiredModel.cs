using System;

namespace GeJu.Back.Test.Models
{
    public class WiredModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreationDate { get; set; }
        public string FileIdentificationNumber { get; set; }
        public decimal Amount { get; set; }
        public string CustomerAccountNumber { get; set; }
        public string SenderIdentification { get; set; }
        public string BankReferenceNumber { get; set; }
        public string CustomerReferenceNumber { get; set; }
        public string TypeCode { get; set; }
        public string TypeDescription { get; set; }
        public string FundType { get; set; }
        public string Immediate { get; set; }
        public string OneDay { get; set; }
        public string TwoOrMoreDays { get; set; }
        public string SendingBank { get; set; }
        public string SendingBankAba { get; set; }
        public string ReceivingBank { get; set; }
        public string ReceivingBankAba { get; set; }
        public string Beneficiary { get; set; }
        public string BeneficiaryAccount { get; set; }
        public string BeneficiaryAddress { get; set; }
        public string PayerName { get; set; }
        public string PayerAddress { get; set; }
        public string PayerAccount { get; set; }
        public string IMAD { get; set; }
        public string OMAD { get; set; }
        public string OBI { get; set; }
        public string WireType { get; set; }
    }
}
