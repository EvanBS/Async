using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsyncAwait
{
    public static class CodeWars
    {
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
