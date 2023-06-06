using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMachine
{
    public class BagDecorator : ProductDecorator
    {
        public BagDecorator(Product product)//:base(product)
        {
            this.product = product;
        }
        public void Bag(Product product)
        {
            Console.WriteLine("Added bag to purchase");
            product.Price += 0.10;
        }
    }
}
