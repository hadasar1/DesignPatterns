using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMachine
{
    public class Coffee : Drink
    {

        


        public int teaspoonsOfCoffee;

       
        public void AddCoffee(int teaspoons)
        {
            Console.
                WriteLine($"Adding {teaspoons} teaspoons of coffee...");
            teaspoonsOfCoffee += teaspoons;

        }



    }

}
