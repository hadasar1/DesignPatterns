using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FoodMachine
{
    public abstract class ProductDecorator : Product
    {
        protected Product product;

        //public ProductDecorator(Product product):base(product.Name ,product.Supplier,product.Price)
        //{
        //    this.product = product;
        //}
       
    }
}
