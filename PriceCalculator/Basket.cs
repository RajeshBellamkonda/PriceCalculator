using PriceCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculator
{
    public class Basket : IBasket
    {
        public List<IProduct> Products { get; private set; }
        public List<IOffer> Offers { get; private set; }

        public Basket(List<IOffer> offers)
        {
            Offers = offers;
        }

        public void AddProducts(List<IProduct> products)
        {
            Products = products;
        }

        public decimal TotalPrice() => Products.Sum(p => p.Total);
        public decimal TotalDiscount() => Offers.Sum(o => o.CalculateDiscount(Products));

        public decimal Total() => TotalPrice() - TotalDiscount();
    }
}
