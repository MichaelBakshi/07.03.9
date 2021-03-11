using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07._03._9
{
    class Program
    {
        public static void LongOperation ()
        {
            for (int i = 0; i < 1000000000; i++)
            {

            }
            Console.WriteLine("Done!");
        }
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Stopwatch sw_for_threads = new Stopwatch();

            //a
            sw.Start();
            for (int i = 0; i < 5; i++)
            {
                LongOperation();
            }
            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.Elapsed);

            //b
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 5; i++)
            {
                threads.Add(new Thread(new ThreadStart(LongOperation)));
            }
            sw_for_threads.Start();
            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].Start();
            }
            sw_for_threads.Stop();
            Console.WriteLine("Elapsed={0}", sw_for_threads.Elapsed);


            //Second option using threads is much faster: less than 1 second, as opposit to the first option where it takes over 9 seconds.
            //Because all threads are running independently.
        }
    }
}
