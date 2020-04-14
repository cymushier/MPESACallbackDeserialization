using MPESACallbackDeserialization.Converters;
using MPESACallbackDeserialization.Models;
using System;
using System.IO;
using System.Text.Json;

namespace MPESACallbackDeserialization
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonData = ReadJson();
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                ReadCommentHandling = JsonCommentHandling.Skip,
            };
            options.Converters.Add(new KeyValueParameterConverter());
            var eventData = JsonSerializer.Deserialize<CallbackResponse>(jsonData, options);
            Console.WriteLine($"Deserialized Data: {eventData.ToString()}");
            Console.WriteLine($"Result Parameters");
            foreach (var item in eventData.Result.ResultParameters.ResultParameter)
            {
                Console.WriteLine($"{{Key: \"{item.Key}\", Value: \"{item.Value}\"}}");
            }
            var callbackData = eventData.FromParameters<CallbackData>();
            Console.WriteLine($"TransactionReceipt: {callbackData.TransactionReceipt}");
        }

        static string ReadJson()
        {
            string fileName = "Files/mpesa-results.json";
            return File.ReadAllText(fileName);
        }
    }
}
