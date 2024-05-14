using InventoryManagementSystem;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Xml.Serialization;
using InventoryManagementSystem.src;

namespace InventoryManagementSystem
{
    /// <summary>
    /// Manages a collection of products within the inventory, including books and devices.
    /// Provides functionality to add products, display products, and save/load the inventory to/from JSON and XML.
    /// </summary>
    public class Inventory
    {
        private List<Product> products;
        private Dictionary<Type, string> productTypeNames;

        /// <summary>
        /// Initializes a new instance of the Inventory class.
        /// </summary>
        public Inventory()
        {
            products = new List<Product>();
            productTypeNames = new Dictionary<Type, string>
            {
                { typeof(Book), "Books" },
                { typeof(Device), "Devices" }
            };
        }

        /// <summary>
        /// Adds a product to the inventory.
        /// </summary>
        /// <param name="product">The product to be added to the inventory.</param>
        /// <remarks>
        /// This method adds a new product to the internal list of products managed by the Inventory class.
        /// If the product is already in the inventory, it will still be added again, allowing duplicates unless checked prior to addition.
        /// </remarks>
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        /// <summary>
        /// Removes a product from the inventory.
        /// </summary>
        /// <param name="product">The product to be removed from the inventory.</param>
        /// <returns>
        /// True if the product was successfully removed; otherwise, false.
        /// This method returns false if the product is not found in the inventory.
        /// </returns>
        /// <remarks>
        /// This method attempts to remove the first occurrence of the specified product from the inventory.
        /// It compares instances, not product values or IDs. Ensure the correct product instance is passed when calling this method.
        /// </remarks>
        public bool RemoveProduct(Product product)
        {
            return products.Remove(product);
        }

        /// <summary>
        /// Displays the products in the inventory, grouped by type.
        /// </summary>
        public void DisplayProducts()
        {
            foreach (var pair in productTypeNames)
            {
                Console.WriteLine($"{pair.Value}:");
                foreach (var product in products)
                {
                    if (product.GetType() == pair.Key)
                    {
                        Console.WriteLine($" - {product}");
                    }
                }
                Console.WriteLine();
            }
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
        public void LoadFromJson(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            // Create JsonSerializerSettings and use custom converter
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new ProductConverter() }
            };
            // Deserialize the JSON string using the specified settings
            products = JsonConvert.DeserializeObject<List<Product>>(jsonString, settings);
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
        public void LoadFromXml(string filePath)
        {
            if (File.Exists(filePath))
            {
                // Create a new XmlSerializer instance with the type of the List<Product>
                XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));

                // Open the file specified by filePath using a FileStream
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    // Deserialize the XML from the file to the products list
                    products = (List<Product>)serializer.Deserialize(fileStream);
                }
            }
        }
    }
}