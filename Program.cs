using System;
using System.Collections.Generic;
using System.Linq;

namespace linqpractice
{
    class Program
    {
        public delegate string Reverse(String s);
        public static void Main(string[] args) 
        {

        IList<Customer> customers = new List<Customer>();
        Customer c1 = new Customer() {city = "Portland", firstname = "Joe"};
        Customer c2 = new Customer() {city = "Vancouver", firstname = "Britney"};
        Customer c3 = new Customer() {city = "Seattle", firstname = "Jon"};
        Customer c4 = new Customer() {city = "Portland", firstname = "Derek"};
        Customer c5 = new Customer() {city = "Houston", firstname = "Adam"};
        Customer c6 = new Customer() {city = "Portland", firstname = "Beth"};
        customers.Add(c1);
        customers.Add(c2);
        customers.Add(c3);
        customers.Add(c4);
        customers.Add(c5);
        customers.Add(c6);
        var queryPortlandCustomers = 
            from c in customers
            where c.city == "Portland"
            orderby c.firstname ascending
            select c;

        Console.WriteLine("List of customers from Portland:");
        foreach (Customer c in queryPortlandCustomers)
            Console.Write(c.firstname + ", ");

        Console.Write("\n---------------------------\n");

        // LINQ with anon type

        var namesOnly = customers.Select(item =>
        new {
            fName = item.firstname
        });

        Console.WriteLine("List of all names:");
        foreach(var n in namesOnly)
            Console.Write(n.fName + ", ");

            
        Console.Write("\n---------------------------\n");

        // simple delegate

        String line = "This is a simple string";
        Console.WriteLine("Simple Delegate Demo");
        Reverse rev = ReverseString;
        Console.WriteLine(line);
        Console.WriteLine("Reversed ...");
        Console.WriteLine(rev(line));

        Console.Write("\n---------------------------\n");
        Console.Write("Running Anonymous Delegate Demo\n");
        AnonymousDelegateDemo();

        Console.Write("\n---------------------------\n");
        Console.Write("Running Lambda Delegate Demo\n");
        LambdaDelegateDemo();
        }

        static string ReverseString(string s)
        {
            var result = new string(s. Reverse().ToArray());
            return result;
        }

        private static void AnonymousDelegateDemo()
        {
            List<int> list = new List<int>();

            for(int i = 1; i <= 100; i++)
            {
                list.Add(i);
            }

            // Anon delegate
            List<int> result = list.FindAll(
                delegate (int num)
                {
                    return (num % 2 == 0);
                }
            );

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void LambdaDelegateDemo()
        {
            List<int> list = new List<int>();

            for (int i = 1; i <= 100; i++)
            {
                list.Add(i);
            }

            // Lambda expression (or just called Lambda)
            // Core building block of LINQ
            // First introduced to C# 3.0
            List<int> result = list.FindAll(i => i % 2 == 0);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        
    }
}
