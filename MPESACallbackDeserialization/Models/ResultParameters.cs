using System;
using System.Collections.Generic;
using System.Text;

namespace MPESACallbackDeserialization.Models
{
    /// <summary>
    /// Results parameters.
    /// </summary>
    public class ResultParameters
    {
#pragma warning disable CA1819 // Properties should not return arrays
        public KeyValueParameter[] ResultParameter { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays
    }
}
