//using InventoryManagementSystem;
using System;

namespace InventoryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            InventoryManager inventoryManager = new InventoryManager(inventory);

            string filePathLoadJson = "/Users/zgraceman/Desktop/in.json";
            string filePathLoadXml = "/Users/zgraceman/Desktop/in.xml";
            string filePathSaveJson = "/Users/zgraceman/Desktop/out.json";
            string filePathSaveXml = "/Users/zgraceman/Desktop/out.xml";

            // Display menu to user
            DisplayMenu();
            bool running = true;
            while (running)
            {
                Console.Write("Select an option: ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        inventoryManager.LoadInventory(filePathLoadJson, filePathLoadXml);
                        break;
                    case "2":
                        inventoryManager.AddSampleProducts();
                        break;
                    case "3":
                        inventoryManager.DisplayInventory();
                        break;
                    case "4":
                        inventoryManager.SaveInventory(filePathSaveJson, filePathSaveXml);
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        DisplayMenu();
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nInventory Management System");
            Console.WriteLine("1. Load Inventory");
            Console.WriteLine("2. Add Sample Products");
            Console.WriteLine("3. Display Inventory");
            Console.WriteLine("4. Save Inventory");
            Console.WriteLine("5. Exit");
        }
    }
}
