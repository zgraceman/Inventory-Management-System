using System;

namespace InventoryManagementSystem
{
    /// <summary>
    /// Provides utility functions for the Inventory Management System.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Converts an amount from one currency to another using the provided exchange rate.
        /// </summary>
        /// <param name="amount">The amount to be converted.</param>
        /// <param name="exchangeRate">The exchange rate to be used for conversion.</param>
        /// <returns>The converted amount.</returns>
        public static decimal ConvertCurrency(decimal amount, decimal exchangeRate)
        {
            return amount * exchangeRate;
        }
    }
}

