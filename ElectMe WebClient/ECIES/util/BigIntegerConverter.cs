using System;
using System.Numerics;
using Newtonsoft.Json;


namespace ElectMe_WebClient.ECIES.util
{
    public class BigIntegerConverter: JsonConverter<BigInteger>
    {
        public override void WriteJson(JsonWriter writer, BigInteger value, JsonSerializer serializer)
        {
            writer.WriteRawValue("\""+value.ToString()+"\"");
            // writer.WriteRawValue(value.ToString());
        }

        public override BigInteger ReadJson(JsonReader reader, Type objectType, BigInteger existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            String s = reader.ReadAsString();
            Console.WriteLine("!!!!!!!!!!!!!!!!!1 "+ s);
            BigInteger big = BigInteger.Parse(s);
            return big;
        }
    }
}