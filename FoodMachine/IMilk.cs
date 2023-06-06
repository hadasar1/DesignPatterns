using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMachine
{
    public abstract class Milk
    {

        protected Drink drink;
        public Milk(Drink drink) 
        {
            this.drink = drink;
        }
        public abstract void WhippedMilk(bool toWhip);
        public abstract void HotOrColdMilk(bool hot);       
    }
}
