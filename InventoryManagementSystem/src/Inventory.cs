using InventoryManagementSystem;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Xml.Serialization;
using InventoryManagementSystem.Models;

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

        public void SetProducts(List<Product> newProducts)
        {
            products = newProducts;
        }

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}