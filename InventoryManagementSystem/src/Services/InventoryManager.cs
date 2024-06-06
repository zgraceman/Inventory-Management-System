using System;
namespace InventoryManagementSystem
{
    /// <summary>
    /// Manages inventory operations, including loading, adding sample products, displaying, and saving inventory.
    /// </summary>
	public class InventoryManager
	{
        private Inventory inventory;
        private InventoryDataAccess dataAccess;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryManager"/> class with the specified inventory.
        /// </summary>
        /// <param name="inventory">The inventory to manage.</param>
        public InventoryManager(Inventory inventory)
        {
            this.inventory = inventory;
            this.dataAccess = new InventoryDataAccess();
        }

        /// <summary>
        /// Loads inventory data from either a JSON or XML file based on user input.
        /// </summary>
        /// <param name="jsonPath">The file path for the JSON file.</param>
        /// <param name="xmlPath">The file path for the XML file.</param>
        public void LoadInventory(string jsonPath, string xmlPath)
        {
            // Provide option to choose between JSON or XML
            Console.Write("Load from (1) JSON or (2) XML? ");
            string loadOption = Console.ReadLine();
            if (loadOption == "1")
            {
                dataAccess.LoadFromJson(jsonPath);
                Console.WriteLine("Inventory loaded from JSON.");
            }
            else if (loadOption == "2")
            {
                dataAccess.LoadFromXml(xmlPath);
                Console.WriteLine("Inventory loaded from XML.");
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }

        /// <summary>
        /// Adds predefined sample products to the inventory.
        /// </summary>
        public void AddSampleProducts()
        {
            inventory.AddProduct(new Book("1984", "George Orwell", 9.99m));
            inventory.AddProduct(new Book("To Kill a Mockingbird", "Harper Lee", 12.99m));
            inventory.AddProduct(new Device("Zach's Smart Watch", "Garmin", "Venu 2 Plus", 200m));
            inventory.AddProduct(new Device("Zach's Phone", "Google", "Pixel 6a", 400m));
            Console.WriteLine("Sample products added.");
        }

        /// <summary>
        /// Displays the current inventory, listing all products grouped by their type.
        /// </summary>
        public void DisplayInventory()
        {
            Console.WriteLine("Current Inventory:\n");
            inventory.DisplayProducts();
        }

        /// <summary>
        /// Saves the current state of the inventory to either a JSON or XML file based on user input.
        /// </summary>
        /// <param name="jsonPath">The file path for the JSON file.</param>
        /// <param name="xmlPath">The file path for the XML file.</param>
        public void SaveInventory(string jsonPath, string xmlPath)
        {
            // Provide option to choose between JSON or XML
            Console.Write("Save as (1) JSON or (2) XML? ");
            string saveOption = Console.ReadLine();
            if (saveOption == "1")
            {
                dataAccess.SaveToJson(jsonPath);
                Console.WriteLine("Inventory saved to JSON.");
            }
            else if (saveOption == "2")
            {
                dataAccess.SaveToXml(xmlPath);
                Console.WriteLine("Inventory saved to XML.");
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }

    }
}

