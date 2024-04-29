using System.Xml.Serialization;

namespace InventoryManagementSystem
{
    /// <summary>
    /// Represents the base class for products within the inventory system. This class
    /// can be extended to include specific types of products.
    /// </summary>
    /// <remarks>
    /// The Product class is designed to be a part of an inventory management system,
    /// providing base properties that are common across various types of products,
    /// such as Name and Price. It is marked with XmlInclude attributes to support
    /// XML serialization of derived types.
    /// </remarks>
    [XmlInclude(typeof(Book))]
    [XmlInclude(typeof(Device))]
    public abstract class Product
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>The name of the product.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        /// <value>The price of the product.</value>
        public decimal Price { get; set; }

        public string Type { get; protected set; }  // Discriminator

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <remarks>
        /// This parameterless constructor is used for serialization purposes
        /// and should not be removed.
        /// </remarks>
        protected Product() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with a specified name and price.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="price">The price of the product.</param>
        /// <remarks>
        /// This constructor allows for the creation of a product with predefined name and price.
        /// </remarks>
        protected Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"Type: {Type}, Name: {Name}, Price: ${Price}";
        }
    }
}