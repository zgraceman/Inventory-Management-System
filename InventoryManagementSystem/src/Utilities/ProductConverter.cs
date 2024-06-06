using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InventoryManagementSystem
{
    /// <summary>
    /// Custom JSON converter for handling different types of products during deserialization.
    /// </summary>
    public class ProductConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this converter can convert the specified object type.
        /// </summary>
        /// <param name="objectType">The type of the object.</param>
        /// <returns>true if this converter can convert the specified object type; otherwise, false.</returns>
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Product));
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The JsonReader to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The deserialized object.</returns>
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

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The JsonWriter to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException(); // Not needed if you only deserialize
        }
    }
}

