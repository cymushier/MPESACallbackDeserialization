using System;
using System.Collections.Generic;
using System.Text;

namespace MPESACallbackDeserialization.Models
{
    /// <summary>
    /// The actual callback data.
    /// </summary>
    public class CallbackData
    {
        public string TransactionReceipt { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal B2CWorkingAccountAvailableFunds { get; set; }
        public decimal B2CUtilityAccountAvailableFunds { get; set; }
        public string TransactionCompletedDateTime { get; set; }
        public string ReceiverPartyPublicName { get; set; }
        public decimal B2CChargesPaidAccountAvailableFunds { get; set; }
        public string B2CRecipientIsRegisteredCustomer { get; set; }
    }
}
