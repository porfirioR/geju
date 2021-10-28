using GeJu.Back.Test.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GeJu.Back.Test
{
    public class Tests
    {
        static readonly HttpClient httpClient = new HttpClient();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1Async()
        {
            var wireModel = new WiredModel
            {
                Amount = (decimal)53998.12,
                BankReferenceNumber = "back 123",
                Beneficiary = "beneficiary 123",
                BeneficiaryAccount = "beneficiary 123",
                BeneficiaryAddress = "address 123",
                CreationDate = DateTime.Now,
                CustomerAccountNumber = "7896523158",
                CustomerReferenceNumber = "12356985621447",
                Date = DateTime.Now,
                FileIdentificationNumber = "123569874589656",
                FundType = "new",
                Id = 1,
                IMAD = "imad123",
                Immediate = "",
                OBI = "obi 125987",
                OMAD = "123256987",
                OneDay = "1256986325",
                PayerAccount = "789563215",
                PayerAddress = "address 12345",
                PayerName = "name name",
                ReceivingBank = "back 12369",
                ReceivingBankAba = "aba back 145236",
                SenderIdentification = "identi 12365489",
                SendingBank = "sending back 123665",
                SendingBankAba = "aba 1236589",
                TwoOrMoreDays = "twoormore",
                TypeCode = "code-code",
                TypeDescription = "12364795",
                WireType = "type-type"
            };
            var request = new PdfDocumentRequest
            {
                FormData = new List<PdfFormData>
                {
                    new PdfFormData { Key = "Amount", Value = $"{wireModel.Amount:n} USD", Editable = false},
                    new PdfFormData { Key = "Date", Value = wireModel.Date.ToString("MM/dd/yyyy"), Editable = false},
                    new PdfFormData { Key = "BankReference", Value = wireModel.BankReferenceNumber, Editable = false},
                    new PdfFormData { Key = "SendingBank", Value = wireModel.SendingBank, Editable = false},
                    new PdfFormData { Key = "SendingBankABA", Value = wireModel.SendingBankAba, Editable = false},
                    new PdfFormData { Key = "PayerName", Value = wireModel.PayerName, Editable = false},
                    new PdfFormData { Key = "PayerAddress", Value = wireModel.PayerAddress, Editable = false},
                    new PdfFormData { Key = "PayerAccountNumber", Value = wireModel.PayerAccount, Editable = false},
                    new PdfFormData { Key = "PayeeName", Value = wireModel.Beneficiary, Editable = false},
                    new PdfFormData { Key = "PayeeAddress", Value = wireModel.BeneficiaryAddress, Editable = false},
                    new PdfFormData { Key = "Notes", Value = wireModel.OBI, Editable = false},
                    new PdfFormData { Key = "FedwireMessageReferenceNumber", Value = $"{wireModel.IMAD} {wireModel.OMAD}", Editable = false},
                    new PdfFormData { Key = "AccountNumber", Value = wireModel.BeneficiaryAccount, Editable = false },
                    new PdfFormData { Key = "AdministrativeContact", Value = "", Editable = true }
                },
                Template = GeJu.Back.Test.Properties.Resources.IncomingBankWiresTransfer
            };
            var createRequestJson = JsonConvert.SerializeObject(request);
            var createRequestStringContent = new StringContent(createRequestJson, Encoding.UTF8, "application/json");
            httpClient.BaseAddress = new Uri("http://localhost:5004/");
            var response = await httpClient.PostAsync("api/populate-form", createRequestStringContent);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var contentResponse = await response.Content.ReadAsByteArrayAsync();
            System.IO.File.WriteAllBytes("IncomingBankWiresTestFile.pdf", contentResponse);
        }
    }
}