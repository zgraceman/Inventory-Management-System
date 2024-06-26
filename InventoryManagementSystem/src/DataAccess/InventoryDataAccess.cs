using System;
using Newtonsoft.Json;
using System.Xml.Serialization;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.DataAccess
{
    public class InventoryDataAccess
    {
        public void SaveToJson(string filePath, List<Product> products)
        {
            var jsonString = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
        }

        public List<Product> LoadFromJson(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new ProductConverter() }
            };
            return JsonConvert.DeserializeObject<List<Product>>(jsonString, settings);
        }

        public void SaveToXml(string filePath, List<Product> products)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, products);
            }
        }

        public List<Product> LoadFromXml(string filePath)
        {
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    return (List<Product>)serializer.Deserialize(fileStream);
                }
            }
            return new List<Product>();
        }
    }
}

