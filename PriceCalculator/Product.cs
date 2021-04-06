using PriceCalculator.Interfaces;
using System;

namespace PriceCalculator
{
    public class Product : IProduct
    {
        public string Name { get; }

        public int Quantity { get; private set; } = 1;

        public decimal Price { get; }

        public decimal Total => Price * Quantity;

        public Product(string name, decimal price)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name cannot be null / empty");
            Name = name;
            if (price <= 0) throw new ArgumentException("Price should be greater than 0");
            Price = price;
        }

        public Product(string name, decimal price, int quantity) : this(name, price)
        {
            if (quantity < 1) throw new ArgumentException("Quantity should be greater than 1");
            Quantity = quantity;
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }
    }
}