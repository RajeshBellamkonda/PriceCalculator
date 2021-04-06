using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Interfaces
{
    public interface IOffer
    {
        decimal CalculateDiscount(IList<IProduct> basketProducts);
    }
}
