using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481_unti6
{
    
    class Customer
    {
        int NumberOfItems;
        public Customer()
        {
            NumberOfItems = 0;
        }

        public Customer(int items)
        {
            int ClothingItems = items;
            if (ClothingItems == 0)
            {
                NumberOfItems = GetRandomNumber(1, 20);
            }
            else
            {
                NumberOfItems = ClothingItems;
            }
        }

        public int getNumberOfItems()
        {
            return NumberOfItems;
        }


        private static readonly Random getrandom = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            lock(getrandom)
            {
                return getrandom.Next(min, max);
            }
        }
    }
}
