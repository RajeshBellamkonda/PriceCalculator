using System.Collections.Generic;

namespace PriceCalculator.Interfaces
{
    public interface IBasket
    {
        List<IProduct> Products { get; }
        List<IOffer> Offers { get; }

        void AddProducts(List<IProduct> products);
        decimal Total();
        decimal TotalDiscount();
        decimal TotalPrice();
    }
}
