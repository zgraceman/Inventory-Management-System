using System;
using System.Collections.Generic;

namespace InventoryManagementSystem.Models
{

    public class Office
	{
        public int OfficeId { get; private set; }
        public string Name { get; private set; }
        public Inventory OfficeInventory { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Office class with a specific name and ID.
        /// </summary>
        /// <param name="officeId">The unique identifier for the office.</param>
        /// <param name="name">The name of the office.</param>
        public Office(int officeId, string name)
        {
            OfficeId = officeId;
            Name = name;
            OfficeInventory = new Inventory();
        }

        /// <summary>
        /// Adds a product to the office's inventory.
        /// </summary>
        /// <param name="product">The product to add to the inventory.</param>
        public void AddProductToInventory(Product product)
        {
            OfficeInventory.AddProduct(product);
            Console.WriteLine($"Product {product.Name} added to {Name} Office Inventory.");
        }

        /// <summary>
        /// Displays all products currently held in the office's inventory.
        /// </summary>
        public void DisplayInventory()
        {
            Console.WriteLine($"Inventory for {Name} Office:");
            OfficeInventory.DisplayProducts();
        }

        /// <summary>
        /// Transfers a product from this office's inventory to another office's inventory.
        /// </summary>
        /// <param name="product">The product to transfer.</param>
        /// <param name="receivingOffice">The office receiving the product.</param>
        public void TransferProductToAnotherOffice(Product product, Office receivingOffice)
        {
            if (OfficeInventory.RemoveProduct(product))
            {
                receivingOffice.AddProductToInventory(product);
                Console.WriteLine($"Product {product.Name} transferred from {Name} to {receivingOffice.Name}.");
            }
            else
            {
                Console.WriteLine("Product transfer failed: Product not found in inventory.");
            }
        }
    }
}

