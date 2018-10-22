using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        // TaskScheduler?
        static async Task<Int32?> Factorial(Int32? val)
        {
            await Task.Factory.StartNew(() => 
            {
                Int32? result = 1;
                while (val != 0)
                {
                    result *= val;
                    val--;
                }
                Thread.Sleep(5000); // resource intensive taks imitatoin

                Console.WriteLine($"Factorial is {result}");

                return result;

            });

            return null;
        }
        
        static void Main(string[] args)
        {
            var factorial = Factorial(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Further process...");
            Console.Read();
        }
    }
}