using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator
{
    public static class ProductFactory
    {

        public static Product CreateProduct(ProductType productType, int quantity = 1)
        {
            switch (productType)
            {
                case ProductType.Butter:
                    return new Product(ProductType.Butter.ToString(), 0.80m, quantity);
                case ProductType.Milk:
                    return new Product(ProductType.Milk.ToString(), 1.15m, quantity);
                case ProductType.Bread:
                    return new Product(ProductType.Bread.ToString(), 1.00m, quantity);
            }
            throw new Exception("Invalid Product");
        }
    }
}