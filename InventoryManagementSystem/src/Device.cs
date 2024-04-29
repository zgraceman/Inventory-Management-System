using System;

namespace InventoryManagementSystem
{
    /// <summary>
    /// Represents an electronic device in the inventory, extending the <see cref="Product"/> class
    /// with additional properties for Manufacturer and Model.
    /// </summary>
    public class Device : Product
    {
        /// <summary>
        /// Gets or sets the manufacturer of the device.
        /// </summary>
        /// <value>
        /// The manufacturer of the device.
        /// </value>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the model name or number of the device.
        /// </summary>
        /// <value>
        /// The model name or number of the device.
        /// </value>
        public string Model { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class.
        /// </summary>
        /// <remarks>
        /// This parameterless constructor is primarily used for serialization and deserialization processes
        /// that require a parameterless constructor.
        /// </remarks>
        public Device() { Type = "Device"; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class with specified name, manufacturer, model, and price.
        /// </summary>
        /// <param name="name">The name of the device.</param>
        /// <param name="manufacturer">The manufacturer of the device.</param>
        /// <param name="model">The model name or number of the device.</param>
        /// <param name="price">The price of the device.</param>
        /// <remarks>
        /// This constructor sets the device-specific properties as well as the name and price properties inherited from <see cref="Product"/>.
        /// </remarks>
        public Device(string name, string manufacturer, string model, decimal price)
            : base(name, price)
        {
            Manufacturer = manufacturer;
            Model = model;
            Type = "Device";
        }

        /// <summary>
        /// Returns a string that represents the current <see cref="Device"/>.
        /// </summary>
        /// <returns>
        /// A string that contains the name, price, manufacturer, and model of the device.
        /// </returns>
        /// <remarks>
        /// Overrides the <see cref="Product.ToString"/> method to include the manufacturer and model of the device.
        /// </remarks>
        public override string ToString()
        {
            return $"{base.ToString()}, Manufacturer: {Manufacturer}, Model: {Model}";
        }
    }
}

