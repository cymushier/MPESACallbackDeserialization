using MPESACallbackDeserialization.Converters;
using System.Text.Json.Serialization;

namespace MPESACallbackDeserialization.Models
{
    /// <summary>
    /// Key value pairs of data
    /// </summary>
    [JsonConverter(typeof(KeyValueParameterConverter))]
    public class KeyValueParameter
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
