﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace linqpractice
{
    class Program
    {
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
        }

    }
}
