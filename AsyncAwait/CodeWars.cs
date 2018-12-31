using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsyncAwait
{
    public static class CodeWars
    {
        // Common Denominators
        public static string convertFrac(long[,] lst)
        {
            if (lst.Length == 0)
            {
                return string.Empty;
            }
            long rows = lst.GetUpperBound(0) + 1;
            long columns = lst.Length / rows;


            List<long> denominators = new List<long>();

            for (int i = 0; i < rows; i++)
            {
                denominators.Add(lst[i, 1]);
            }

            long MaxDenom = denominators.Max();
            long iMul = 1;

            for (long i = 0; i < rows; i++)
            {
                // not an integer
                if ((decimal)MaxDenom / lst[i, 1] % 1 != 0)
                {
                    iMul++;
                    MaxDenom = denominators.Max() * iMul;
                    i = -1;
                }
            }

            string result = null;

            for (int i = 0; i < rows; i++)
            {
                lst[i, 0] *= MaxDenom / lst[i, 1];
                lst[i, 1] = MaxDenom;
                result += string.Format($"({lst[i, 0]},{lst[i, 1]})");
            }

            return result;
        }

        public static bool Scramble(string str1, string str2)
        {
            foreach (var letter in str2)
            {
                if (!str1.Contains(letter))
                {
                    return false;
                }

                str1 = str1.Remove(str1.IndexOf(letter), 1);
            }

            return true;
        }


        public static string[] GetNames(Person[] data)
        {
            return data.Select(d => d.Name).ToArray();
        }


    }

    public class Person
    {
        public int Age;
        public string Name;

        public Person(string name = "John", int age = 21)
        {
            Age = age;
            Name = name;
        }

    }

}
