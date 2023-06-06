using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace FoodMachine
{
    public class Machine
    {
        public Dictionary<Drink, int> Drinks { get; set; }
        public Dictionary<Snack, int> SnacksAndBottles { get; set; }
        private DaylyReport report { get; set; }
        public Machine()
        {
            Drinks = new Dictionary<Drink, int>()
            {
                {new Coffee() { Name=" Coffee",Price=10 },10 },
                {new Coffee() { Name="Ice Coffee",Price=10 },10 },
                {new ChocolateMilk() { Name="ChocolateMilk",Price=10},10 }
            };
            SnacksAndBottles = new Dictionary<Snack, int>() {
                {new Snack() { Name="Bamba" ,Price=10},30 },
                  {new Snack() { Name="Potato Chips",Price=4.5 },30 },
                   {new Snack() { Name="Afropo",Price=8 },30 },
                     {new Snack() { Name="Doritos",Price=4.5 },30 },
                       {new Snack() { Name="bisli" , Price = 10},30 },
                         {new Snack() { Name="FuzeTea" ,Price=6},30 },
                          {new Snack() { Name="Coca Cola" ,Price=6.5},30 },
                           {new Snack() { Name="Schweps" , Price = 5.5},30 }
            };
        }
        private void SaveReport(DaylyReport report)
        {
            this.report = report;
        }
        //public Product ChooseProduct(string name)
        //{
        //    foreach (Dictionary<Product, int> entry in SnacksAndBottles)
        //    {
        //        if (entry.Values.First == name)
        //        {
        //            Product foundProduct = entry.Key;
        //            return foundProduct;
        //        }
        //    }
        //    Console.WriteLine("Product is out of stock");
        //    return null;
        //}
        public void BagProduct(Product product)
        {
            BagDecorator bagDecorator = new BagDecorator(product);
            bagDecorator.Bag(product);
        }
        public void WrapProduct(Product product)
        {
            WrapDecorator wrapDecorator = new WrapDecorator(product);
            wrapDecorator.Wrap(product);
        }
        public double pay(Product product)
        {
            return product.Price;
        }
        //public States exit(States state)
        //{
        //    if (state == pay || state == choose)
        //    {
        //        return state = choose;

        //    }
        //    else
        //    {
        //        Console.WriteLine("Cannot exit");
        //    }
        //    return state;
        //}

        private void DecreaseQuantity(Product product)
        {
            if (product is Snack snack)
            {
                if (SnacksAndBottles.ContainsKey(snack))
                {
                    int currentQuantity = SnacksAndBottles[snack];
                    if (currentQuantity > 0)
                    {
                        SnacksAndBottles[snack] -= 1;
                        if (SnacksAndBottles[snack] < 5)
                        {
                            NotifySupplier(snack);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Product {0} is out of stock", snack.Name);
                    }
                }
                else
                {
                    MessageBox.Show("Product {0} not found in stock", snack.Name);
                }
            }
            else if (product is Drink drink)
            {
                if (Drinks.ContainsKey(drink))
                {
                    int currentQuantity = Drinks[drink];
                    if (currentQuantity > 0)
                    {
                        Drinks[drink] -= 1;
                        if (Drinks[drink] < 5)
                        {
                            NotifySupplier(drink);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Product {0} is out of stock", drink.Name);
                    }
                }
                else
                {
                    MessageBox.Show("Product {0} not found in stock", drink.Name);
                }
            }
            else
            {
                MessageBox.Show("Unsupported product type");
            }
        }

        private void NotifySupplier(Product product)
        {
            string supplier = product.Supplier;
            MessageBox.Show($"{product.Supplier} -Quantity of {product.Name} is below 5 ");
        }




        public void AddQuantity(Product product, int quantity)
        {
            if (product.GetType() == typeof(Snack))
            {
                Snack snack = (Snack)product;
                if (SnacksAndBottles.ContainsKey(snack))
                {
                    SnacksAndBottles[snack] += quantity;
                }
                else
                {
                    SnacksAndBottles[snack] = quantity;
                }
            }
            else if (product.GetType() == typeof(Drink))
            {
                Drink drink = (Drink)product;
                if (Drinks.ContainsKey(drink))
                {
                    Drinks[drink] += quantity;
                }
                else
                {
                    Drinks[drink] = quantity;
                }
            }

        }

    }
}

