using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InventoryManagementSystem.src
{
    public class ProductConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Product));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            switch (item["Type"].ToString())
            {
                case "Book":
                    return item.ToObject<Book>(serializer);
                case "Device":
                    return item.ToObject<Device>(serializer);
                default:
                    throw new JsonSerializationException("Unknown type");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException(); // Not needed if you only deserialize
        }
    }
}

