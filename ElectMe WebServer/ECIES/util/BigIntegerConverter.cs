using System;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ElectMe_WebServer.ECIES.util
{
    public class BigIntegerConverter : JsonConverter<BigInteger>
    {
        public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string s = reader.GetString();
            BigInteger big = BigInteger.Parse(s);
            return big;
        }

        public override void Write(Utf8JsonWriter writer, BigInteger value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}