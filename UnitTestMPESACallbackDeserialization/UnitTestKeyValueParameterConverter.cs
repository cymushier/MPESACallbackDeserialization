using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPESACallbackDeserialization.Converters;
using MPESACallbackDeserialization.Models;
using System.IO;
using System.Text;
using System.Text.Json;

namespace UnitTestMPESACallbackDeserialization
{
    [TestClass]
    public class UnitTestKeyValueParameterConverter
    {
        [TestMethod]
        public void TestCanConvert()
        {
            Assert.IsTrue(new KeyValueParameterConverter().CanConvert(typeof(KeyValueParameter)));
        }

        [TestMethod]
        public void TestWrite()
        {
            var convertedJson = JsonSerializer.Serialize(new KeyValueParameter
            {
                Key = "TransactionReceipt",
                Value = "LGH3197RIB"
            });
            var stream = new MemoryStream();
            using (var jsonWriter = new Utf8JsonWriter(stream))
            {
                jsonWriter.WriteStartObject();
                jsonWriter.WriteString("Key", "TransactionReceipt");
                jsonWriter.WriteString("Value", "LGH3197RIB");
                jsonWriter.WriteEndObject();
            }
            string json = Encoding.UTF8.GetString(stream.ToArray());
            Assert.AreEqual(convertedJson, json);
        }
    }
}
