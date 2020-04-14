using System;
using System.Collections.Generic;
using System.Text;

namespace MPESACallbackDeserialization.Models
{
    /// <summary>
    /// The result container
    /// </summary>
    public class Result
    {
        public int ResultType { get; set; }
        public int ResultCode { get; set; }
        public string ResultDesc { get; set; }
        public string OriginatorConversationID { get; set; }
        public string ConversationID { get; set; }
        public string TransactionID { get; set; }
        public ResultParameters ResultParameters { get; set; }
        public ReferenceData ReferenceData { get; set; }
    }
}
