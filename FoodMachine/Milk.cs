using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMachine
{
    public  class Milk
    {

        private Drink drink;
        public Milk(Drink drink)
        {
            this.drink = drink;
        }

        public void HotOrColdMilk( bool toWhip)
        {
            if (toWhip)
            {
                Console.WriteLine("Whipped milk");
            }
            else
            {
                Console.WriteLine("Poured milk");
            }
        }
        public void WhippedMilk( bool toWhip)
        {
            if (toWhip)
            {
                Console.WriteLine("Whipped milk");
            }
            else
            {
                Console.WriteLine("Poured milk");
            }
        }
    }
}
