using System.Diagnostics.Metrics;

namespace Synchronization
{
    internal class Program
    {
        public static int counter = 0;

        public static void Incrementer()
        {
                try
                {
                    while (counter < 1000)
                    {
                        lock (this)
                        { // lock bắt đầu có hiệu lực
                            int temp = counter;
                            temp++;
                            Thread.Sleep(1);
                            counter = temp;
                        } // lock hết hiệu lực -> bị gỡ bỏ
                          // assign the decremented value and display the results
                        Console.WriteLine("Thread {0}. Incrementer: {1}",
                        Thread.CurrentThread.Name, counter);
                    }
                }
                finally
                {
                    Console.WriteLine("[{0}] Exiting...",
                        Thread.CurrentThread.Name);
                } 
        }


        static void Main(string[] args)
        {
            Incrementer();
        }

        
    } 
}