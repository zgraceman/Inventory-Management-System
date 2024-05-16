using System;

namespace InventoryManagementSystem
{
    /// <summary>
    /// Represents a Book, inheriting from the Product class, with additional property Author.
    /// </summary>
	public class Book : Product
    {
        /// <summary>
        /// Gets or sets the Author of the Book.
        /// </summary>
        /// <value>
        /// The Author property holds the name of the book's author.
        /// </value>
        public string Author { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <remarks>
        /// This parameterless constructor is used for serialization and deserialization processes.
        /// </remarks>
        public Book() { Type = "Book"; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class with specified title, author, and price.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="author">The author of the book.</param>
        /// <param name="price">The price of the book.</param>
        /// <remarks>
        /// This constructor initializes a new Book with the specified details.
        /// </remarks>
        public Book(string title, string author, decimal price)
          : base(title, price)
        {
          Author = author;
            Type = "Book";
        }

        /// <summary>
        /// Returns a string that represents the current <see cref="Book"/>.
        /// </summary>
        /// <returns>
        /// A string containing the title, price, and author of the book.
        /// </returns>
        /// <remarks>
        /// Overrides the <see cref="Product.ToString"/> method to include the author's name.
        /// </remarks>
        public override string ToString()
        {
            return $"Title: {Name}, Price: {Price}, Author: {Author}";
        }
    }
}

