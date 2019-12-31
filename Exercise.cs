using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld
{
    class Exercise
    {
        delegate void MyDelegate();

        public static void Delegate()
        {
            var del = new MyDelegate(Method1);
            del.Invoke();

            // Take nothing, return nothing
            var action = new Action<string>(Print);
            action.Invoke("Mike");

            // Take an input, return result
            var func = new Func<string, string>(Print2);
            var x = func.Invoke("Michael");
            Console.WriteLine("Func Returned: " + x);
        }

        static void Method1()
        {
            Console.WriteLine("Hello C#");
        }

        static void Print(string name)
        {
            Console.WriteLine("[Action] Hello " + name);
        }

        static string Print2(string name)
        {
            Console.WriteLine("[Func] Hello " + name);

            return "Hello " + name;
        }

        public static void NullableInt()
        {
            int? myint = null; // Initialize myint to null, same as Integer in Java
            if (myint == null)
            {
                Console.WriteLine("myint is null");
            }
            else
            {
                Console.WriteLine("myint is " + myint);
            }
        }

        public static void List()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6 };
            var evenNumbers = list.Where(i => i % 2 == 0).ToList();

            Console.WriteLine("Even Numbers:");
            foreach (int i in evenNumbers)
            {
                Console.WriteLine(i);
            }

            var lastOdd = list.Last(i => i % 2 != 0);
            Console.WriteLine("lastOdd: {0}", lastOdd);
        }

        public static void Arr()
        {
            var arr = new int[] { 1, 2, 3, 4, 5, 6 };
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
        }
    }
}
