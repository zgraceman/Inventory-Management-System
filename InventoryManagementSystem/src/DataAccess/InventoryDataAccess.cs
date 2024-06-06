using System;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace InventoryManagementSystem
{
	public class InventoryDataAccess
	{

        private List<Product> products;
        private Dictionary<Type, string> productTypeNames;

        public InventoryDataAccess()
		{
            products = new List<Product>();
            productTypeNames = new Dictionary<Type, string>
            {
                { typeof(Book), "Books" },
                { typeof(Device), "Devices" }
            };
        }


        /// <summary>
        /// Saves the current state of the inventory to a JSON file.
        /// </summary>
        /// <param name="filePath">The file path where the JSON file will be saved.</param>
        public void SaveToJson(string filePath)
        {
            var jsonString = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
        }

        /// <summary>
        /// Loads the inventory from a JSON file.
        /// </summary>
        /// <param name="filePath">The file path of the JSON file to be loaded.</param>
        public List<Product> LoadFromJson(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            // Create JsonSerializerSettings and use custom converter
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new ProductConverter() }
            };
            // Deserialize the JSON string using the specified settings
            return JsonConvert.DeserializeObject<List<Product>>(jsonString, settings);
        }

        /// <summary>
        /// Saves the current state of the inventory to an XML file.
        /// </summary>
        /// <param name="filePath">The file path where the XML file will be saved.</param>
        public void SaveToXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, products);
            }
        }

        /// <summary>
        /// Loads the inventory from an XML file.
        /// </summary>
        /// <param name="filePath">The file path of the XML file to be loaded.</param>
        public List<Product> LoadFromXml(string filePath)
        {
            if (File.Exists(filePath))
            {
                // Create a new XmlSerializer instance with the type of the List<Product>
                XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));

                // Open the file specified by filePath using a FileStream
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    // Deserialize the XML from the file to the products list
                    return (List<Product>)serializer.Deserialize(fileStream);
                }
            }
            return new List<Product>();
        }

    }
}

