using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp7_Features_Example
{
    class Program
    {

        static void Main(string[] args)
        {
            //List<ValueTuple<string, int>> persons = new List<ValueTuple<string, int>>()
            //{
            //    ValueTupleExample.SetPerson("Sepehr",18),
            //    ValueTupleExample.SetPerson("Mark",21),
            //    ValueTupleExample.SetPerson("Reza", 23)
            //};

            //foreach (var person in persons)
            //{
            //    ValueTupleExample.GetPerson(person);
            //}

            //List<Tuple<string, int>> persons = new List<Tuple<string, int>>()
            //{
            //    TupleExample.SetPerson("Sepehr",18),
            //    TupleExample.SetPerson("Mark",21),
            //    TupleExample.SetPerson("Reza", 23)
            //};

            //foreach (var person in persons)
            //{
            //    TupleExample.GetPerson(person);
            //}

            //List<ValueTuple<string, int>> persons = new List<ValueTuple<string, int>>()
            //{
            //    ValueTupleExample.SetPerson("Sepehr",18),
            //    ValueTupleExample.SetPerson("Mark",21),
            //    ValueTupleExample.SetPerson("Reza", 23)
            //};

            //foreach (var person in Utilities.GetNamesByFilter(persons, "S"))
            //{
            //    ValueTupleExample.GetPerson(person);
            //}

            // ## Create Nested Tuple ##
            Tuple<int, int, int, int, int, int, Tuple<string, int>> tuple = Tuple.Create(1, 2, 3, 4, 5, 6, Tuple.Create("Sepehr", 18));

            Console.Write("Tuple: ");
            Console.WriteLine($"{tuple.Item1} {tuple.Item2} {tuple.Item3} {tuple.Item4} {tuple.Item5} {tuple.Item6}");

            Console.Write("Nested Tuple: ");
            Console.WriteLine($"{tuple.Item7.Item1} {tuple.Item7.Item2}");
        }
    }

    static class Utilities
    {
        public static IEnumerable<(string name, int age)> GetNamesByFilter(IEnumerable<(string name, int age)> persons, string filter)
        {
            foreach (var person in persons)
            {
                if (person.name.Contains(filter))
                {
                    yield return person;
                }
            }
        }
    }

    static class TupleExample
    {
        public static void GetPerson(Tuple<string, int> person)
        {
            // This is Local Function
            string Generate()
            {
                return $"Name: {person.Item1}  Age: {person.Item2}";
            }

            Console.WriteLine(Generate());
        }

        public static Tuple<string, int> SetPerson(string name, int age)
        {
            return Tuple.Create(name, age);
        }
    }

    static class ValueTupleExample
    {
        // Gets ValueTuple<string,int> as an argument...
        public static void GetPerson((string name, int age) person)
        {
            // This is Local Function
            string Generate()
            {
                return $"Name: {person.name}  #  Age: {person.age}";
            }

            Console.WriteLine(Generate());
        }

        // Returns ValueTuple<string,int> ...
        public static (string, int) SetPerson(string name, int age)
        {
            return (name, age);
        }
    }
}
