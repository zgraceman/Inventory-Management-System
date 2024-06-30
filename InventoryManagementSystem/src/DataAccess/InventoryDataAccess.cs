using System;
using Newtonsoft.Json;
using System.Xml.Serialization;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.DataAccess
{

    /// <summary>
    /// Handles data access for inventory operations, providing methods to save and load inventory data.
    /// </summary>
    public class InventoryDataAccess
    {
        /// <summary>
        /// Serializes and saves a list of products to a JSON file at the specified path.
        /// </summary>
        /// <param name="filePath">The file path where the JSON data should be saved.</param>
        /// <param name="products">The list of products to serialize and save.</param>
        public void SaveToJson(string filePath, List<Product> products)
        {
            var jsonString = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
        }

        /// <summary>
        /// Loads and deserializes a list of products from a JSON file at the specified path.
        /// </summary>
        /// <param name="filePath">The file path from which to load the JSON data.</param>
        /// <returns>A list of deserialized products.</returns>
        public List<Product> LoadFromJson(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new ProductConverter() }
            };
            return JsonConvert.DeserializeObject<List<Product>>(jsonString, settings);
        }

        /// <summary>
        /// Serializes and saves a list of products to an XML file at the specified path.
        /// </summary>
        /// <param name="filePath">The file path where the XML data should be saved.</param>
        /// <param name="products">The list of products to serialize and save.</param>
        public void SaveToXml(string filePath, List<Product> products)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, products);
            }
        }

        /// <summary>
        /// Loads and deserializes a list of products from an XML file at the specified path.
        /// </summary>
        /// <param name="filePath">The file path from which to load the XML data.</param>
        /// <returns>A list of deserialized products.</returns>
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

