using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMachine
{
    public  class Drink : Product
    {

        //protected Milk milk;

        //public Drink(Milk milk)
        //{
        //    this.milk = milk;
        //}




        public int spoonsOfSugar;

        public void SpoonsOfSugar(int spoonsOfSugar)
        {
            Console.WriteLine($"Putting {spoonsOfSugar} spoons of sugar");

        }
        //  public Drink(string code, double price, string supplier)
        //: base(code, price, supplier)
        //  {
        //  }

        //public void AddSugar(int teaspoons)
        //{
        //    Console.WriteLine($"Added {teaspoons} teaspoons of sugar to the drink.");
        //}
    }
}
