using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace IT481_unti6
{
    class DressingRooms
    {

        int rooms;
        Semaphore semaphore;
        long waitTimer;
        long runTimer;

        public DressingRooms()
        {
            rooms = 3;
            semaphore = new Semaphore(rooms, rooms);
        }

        public DressingRooms(int r)
        {
            rooms = r;
            semaphore = new Semaphore(rooms, rooms);
        }

        public async Task RequestRoom(Customer c)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Customer is waiting");

            stopwatch.Start();
            semaphore.WaitOne();
            stopwatch.Stop();
            waitTimer += stopwatch.ElapsedTicks;

            int roomwaitTime = GetRandomNumber(1, 3);
            stopwatch.Start();
            Thread.Sleep((roomwaitTime * c.getNumberOfItems()));
            stopwatch.Stop();
            runTimer += stopwatch.ElapsedTicks;

            Console.WriteLine("Customer finishing trying on items in room");
            semaphore.Release();

        }

        public long getWaitTime()
        {
            return waitTimer;
        }

        public long getRunTime()
        {
            return runTimer;
        }

        private static readonly Random getrandom = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom)
            {
                return getrandom.Next(min, max);
            }
        }

    }
}
