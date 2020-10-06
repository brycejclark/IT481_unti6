using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481_unti6
{
    class Scenario
    {
        static Customer cust;
        static int items = 0;
        static int numberOfITems;
        static int controlItemNumber;

        public Scenario(int r, int c)
        {
            Console.WriteLine(r + " dressing roms for" + c + "customers");

            controlItemNumber = 0;
            numberOfITems = 0;

        }

        static void Main(string[] args)
        {
            Console.Write("What ClothingItems value do you want? (0=random)");
            int controlItemNumber = Int32.Parse(Console.ReadLine());

            Console.Write("How many customers do you want?");
            int numberOfCustomers = Int32.Parse(Console.ReadLine());
            Console.WriteLine("There are " + numberOfCustomers + " total customers");

            Console.Write("How many dressing rooms do you want?");
            int totalRooms = Int32.Parse(Console.ReadLine());

            Scenario s = new Scenario(totalRooms, numberOfCustomers);

            DressingRooms dr = new DressingRooms(totalRooms);

            List<Task> tasks = new List<Task>();

            for(int i = 0; i<numberOfCustomers; i++)
            {
                cust = new Customer(controlItemNumber);
                numberOfITems = cust.getNumberOfItems();
                items += numberOfITems;
                tasks.Add(Task.Factory.StartNew(async () =>
                {
                    await dr.RequestRoom(cust);
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Average Run time is in milliseconds {0} ", dr.getRunTime()/numberOfCustomers);
            Console.WriteLine("Average Wait time is in milliseconds {0} ", dr.getWaitTime()/numberOfCustomers);
            Console.WriteLine("The total customers is {0} ", numberOfCustomers);

            int averageItemsPerCustomer = items / numberOfCustomers;

            Console.WriteLine("Average number of Items was "+ averageItemsPerCustomer);
            Console.Read();


        }
    }
}
