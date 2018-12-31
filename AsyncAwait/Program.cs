using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace AsyncAwait
{
    struct Str
    {
        public int A;
        public int B;

        public void Sum()
        {
            A = B = 0;
        }
    }

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

        static void ShowCollection(IEnumerable t)
        {
            foreach (var item in t)
            {
                Console.WriteLine(item);
            }
        }

        delegate bool isEmpty(string s);

        static void Main(string[] args)
        {

            //var factorial = Factorial(Convert.ToInt32(Console.ReadLine()));
            //Console.WriteLine("Further process...");
            //Console.Read();

            int[] nums = new int[] { 6, 2, 7, 1, 9, 3 };
            IEnumerable<int> numsLessThanFour = nums
               .Where(i => i < 4)
               .OrderBy(i => i);


            isEmpty isEmpty = s => s.Length > 0;

            string[] names = new string[] { "das", "dvawd" };
            var notNull = names
                .Where(s => isEmpty(s));


            #region CW
            Console.WriteLine(CodeWars.Scramble("javscripts", "javascript"));

            // person`s name
            Person[] data = new Person[]
            {
              new Person("Joe", 20),
              new Person("Vasily", 30),
              new Person("Kate", 23)
            };

            var res = CodeWars.GetNames(data);
            foreach (var s in res)
            {
                Console.WriteLine(s);
            }
            #endregion

            #region CommonDenominators
            long[,] lst = new long[,] { { 1, 2 }, { 1, 3 }, { 1, 4 }, { 69, 130 }, { 87, 1310 }, { 3, 4 } };
            Console.WriteLine(CodeWars.convertFrac(lst));

            #endregion

            #region events

            Account account = new Account(1000, "Vasily");
            
            account.RegisterAdded(States.ShowMessage);
            account.RegisterWithdrawn(States.ShowMessage);

            account.Withdraw(10);
            account.Withdraw(50);

            account.Addval(10);
            account.Addval(50);

            #endregion
        }
    }
}