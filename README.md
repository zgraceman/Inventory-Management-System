# Inventory Management System

## Overview

The Inventory Management System is a console-based application developed in C# to manage and track inventory across multiple office locations. It handles the storage, modification, and display of product details, including books and electronic devices. The system supports serialization for data persistence, allowing inventory data to be saved and loaded from JSON and XML formats.

## Features

- **Manage Inventory**: Add, display, and remove products from inventory.
- **Data Persistence**: Load and save inventory data in JSON and XML formats.
- **Transfer Products**: Move products between different office inventories.
- **Sample Data**: Predefined methods to add sample products to the inventory.
- **Dynamic Inventory Access**: Manage inventory specific to office locations with unique identifiers and details.

## Project Structure

- `Program.cs`: Entry point of the application, handling the user interface and flow control.
- `Inventory.cs`: Core logic for inventory management, including add, remove, display functions.
- `Product.cs`: Base class for products, including common properties like name and price.
- `Book.cs`, `Device.cs`: Derived classes from Product, representing specific types of products.
- `Office.cs`: Represents an office, managing its own inventory.
- `InventoryManager.cs`: Facilitates operations on inventories such as loading, saving, and transferring items.
- `Utility.cs`: Provides additional utility functions like currency conversion.

## Getting Started

### Prerequisites

- .NET SDK (preferably version 5.0 or later)

### Setup and Installation

1. Clone the repository to your local machine:
   ```bash
   git clone https://yourrepositorylink.com/project.git
   ```
2. Navigate to the project directory:
   ```bash
   cd InventoryManagementSystem
   ```

### Running the Application

Execute the following command in the root directory of the project:
```bash
dotnet run
```

## Usage

After starting the application, follow the on-screen menu to interact with the inventory system:
1. Load Inventory: Choose to load inventory data from JSON or XML.
2. Add Sample Products: Automatically add predefined products to the inventory.
3. Display Inventory: View all products in the current inventory.
4. Save Inventory: Save the current state of the inventory to JSON or XML.
5. Exit: Terminate the application.
