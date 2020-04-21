using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTestMPESACallbackDeserialization
{
    [TestClass]
    public class UnitTestMain
    {
        private const string ExpectedOutput = "Deserialized Data: LGH3197RIB (The service request has been accepted successfully.)\n" +
            "Result Parameters\n{Key: \"TransactionReceipt\", Value: \"LGH3197RIB\"}\n{Key: \"TransactionAmount\", Value: \"8000\"}\n" +
            "{Key: \"B2CWorkingAccountAvailableFunds\", Value: \"150000\"}\n{Key: \"B2CUtilityAccountAvailableFunds\", Value: \"133568\"}\n" +
            "{Key: \"TransactionCompletedDateTime\", Value: \"17.07.2017 10:54:57\"}\n" +
            "{Key: \"ReceiverPartyPublicName\", Value: \"254708374149 - John Doe\"}\n" +
            "{Key: \"B2CChargesPaidAccountAvailableFunds\", Value: \"0\"}\n" +
            "{Key: \"B2CRecipientIsRegisteredCustomer\", Value: \"Y\"}\n" +
            "TransactionReceipt: LGH3197RIB";

        [TestMethod]
        public void TestReadJson()
        {
            string jsonData = MPESACallbackDeserialization.Program.ReadJson();
            Assert.IsNotNull(jsonData);
        }
        
        [TestMethod]
        public void TestMain()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            MPESACallbackDeserialization.Program.Main(null);

            var result = sw.ToString().Trim();
            Assert.AreEqual(ExpectedOutput.Replace("\n", "").Replace("\r", ""), result.Replace("\n", "").Replace("\r", ""));
        }
    }
}
