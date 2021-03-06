﻿using MPESACallbackDeserialization.Models;
using System;
using System.IO;
using System.Text.Json;

namespace MPESACallbackDeserialization
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string jsonData = ReadJson();
            var eventData = JsonSerializer.Deserialize<CallbackResponse>(jsonData);
            Console.WriteLine($"Deserialized Data: {eventData.ToString()}");
            Console.WriteLine($"Result Parameters");
            foreach (var item in eventData.Result.ResultParameters.ResultParameter)
            {
                Console.WriteLine($"{{Key: \"{item.Key}\", Value: \"{item.Value}\"}}");
            }
            var callbackData = eventData.FromParameters<CallbackData>();
            Console.WriteLine($"TransactionReceipt: {callbackData.TransactionReceipt}");
        }

        public static string ReadJson()
        {
            string fileName = "Files/mpesa-results.json";
            return File.ReadAllText(fileName);
        }
    }
}
