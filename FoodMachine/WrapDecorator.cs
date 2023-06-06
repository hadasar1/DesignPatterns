using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMachine
{
    public class WrapDecorator : ProductDecorator
    {
        public WrapDecorator(Product product)//:base(product)
        {
            this.product = product;
        }
        public void Wrap(Product product)
        {
            Console.WriteLine("Wraping product");
            product.Price += 2;
        }
    }
}
