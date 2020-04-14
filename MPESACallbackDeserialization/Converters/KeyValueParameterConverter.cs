using MPESACallbackDeserialization.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MPESACallbackDeserialization.Converters
{
    public class KeyValueParameterConverter : JsonConverter<KeyValueParameter>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(KeyValueParameter).IsAssignableFrom(typeToConvert);

        public override KeyValueParameter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            KeyValueParameter keyValueParameter = new KeyValueParameter();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return keyValueParameter;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName)
                    {
                        case "Value":
                            try
                            {
                                string value = reader.GetString();
                                keyValueParameter.Value = value;
                            }
                            catch (Exception)
                            {
                                var value = reader.GetDecimal();
                                keyValueParameter.Value = value.ToString();
                            }
                            break;
                        case "Key":
                            try
                            {
                                string value = reader.GetString();
                                keyValueParameter.Key = value;
                            }
                            catch (Exception)
                            {
                                var value = reader.GetDecimal();
                                keyValueParameter.Key = value.ToString();
                            }
                            break;
                    }
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, KeyValueParameter value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteString("Key", value.Key);
            writer.WriteString("Value", value.Value);

            writer.WriteEndObject();
        }
    }
}
