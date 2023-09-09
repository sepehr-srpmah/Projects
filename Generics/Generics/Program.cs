using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace Generics
{
    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        // where T : IComparable => objects can be compare and this interface has CompareTo() method
        // where T : Product => T should be Product  or its subclasses ... 
        // where T : class => T should be reference type
        // where T : struct => T Should be value-type

        static void Main(string[] args)
        {
            #region List<>

            // Creating List
            System.Collections.Generic.List<int> primeNumbers = new System.Collections.Generic.List<int>();
            primeNumbers.Add(1);
            primeNumbers.Add(3);
            primeNumbers.Add(5);
            primeNumbers.Add(7);

            var cities = new System.Collections.Generic.List<string>();
            cities.Add("Tehran");
            cities.Add("New York");
            cities.Add("Chicago");
            cities.Add("London");
            cities.Add(null); // nulls allowed for reference types

            var bigCities = new System.Collections.Generic.List<string>();
            cities.Add("Tehran");
            cities.Add("New York");
            cities.Add("Chicago");
            cities.Add("London");

            var students = new System.Collections.Generic.List<Student>()
            {
                new Student(){ ID=1, Name = "Bill"},
                new Student(){ ID = 2, Name = "Steve"},
                new Student(){ ID = 3, Name = "Sam"},
                new Student(){ID = 4, Name = "Sepehr"}
            };

            string[] excitingCities = new string[3] { "Toronto", "Paris", "Rome" };

            var popularCities = new System.Collections.Generic.List<string>();

            // adding an array in a List
            popularCities.AddRange(excitingCities);

            var favoriteCities = new System.Collections.Generic.List<string>();

            // adding a List
            favoriteCities.AddRange(popularCities);

            // Accessing List

            // * 1 *
            //Console.WriteLine(primeNumbers[0]);
            //Console.WriteLine(primeNumbers[1]);
            //Console.WriteLine(primeNumbers[2]);
            //Console.WriteLine(primeNumbers[3]);

            // 2 * using foreach LINQ method *
            //primeNumbers.ForEach(num => Console.Write(num + "; "));
            //Console.WriteLine();

            // 3 * using for loop *
            //for(int i=0; i<primeNumbers.Count; i++)
            //    Console.WriteLine(primeNumbers[i]);

            // get all students whose name is Sepehr
            //var result = from student in students
            //             where student.Name == "Sepehr"
            //             select student;

            //foreach (var student in result)
            //{
            //    Console.WriteLine("{0} , {1}", student.ID, student.Name);
            //}

            //primeNumbers.Insert(0,11);
            //primeNumbers.ForEach(n=>Console.WriteLine(n));

            // primeNumbers.Remove(1);

            // primeNumbers.RemoveAt(2);

            //primeNumbers.RemoveAt(10); // Throws ArgumentOutOfRangeException

            //foreach (var primeNumber in primeNumbers)
            //{
            //    Console.WriteLine(primeNumber);
            //}

            // Console.WriteLine(primeNumbers.Contains(1)); // return True
            // Console.WriteLine(primeNumbers.Contains(11)); // return False
            // Console.WriteLine(primeNumbers.Contains(2)); // return False


            #endregion

            #region Dictionary<>

            // dictionary : is a generic collection
            //              that stores key-value pairs
            //              in no particular order

            // dictionary implements IDictionary<TKey, TValue>

            // Keys must be unique and cannot be null

            // Values can be null or duplicate

            // Values can be accessed by passing associated key in the indexer
            //      like : cities[key]

            // Elements are stored as KeyValuePair<TKey, TValue> objects

            // 1 * Creating Dictionaries
            IDictionary<int, string> numberNames = new Dictionary<int, string>();
            numberNames.Add(1, "One");
            numberNames.Add(2, "Two");
            numberNames.Add(3, "Three");
            numberNames.Add(4, "Four");

            // throws runtime exception: key already added
            //numberNames.Add(3, "Three");

            //foreach (KeyValuePair<int, string> kvp in numberNames)
            //{
            //    Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
            //}

            // Create Dictionary Using Collection-Initializer Syntax
            var citiesOfDictionary = new Dictionary<string, string>()
            {
                {"UK", "London, Manchester"},
                {"USA", "New York, Chicago"},
            };

            //foreach (var kvp in citiesOfDictionary)
            //{
            //    Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
            //}

            // Access Dictionary Elements
            //Console.WriteLine(citiesOfDictionary["UK"]);
            //Console.WriteLine(citiesOfDictionary["USA"]);

            //Console.WriteLine(citiesOfDictionary["IR"]); // Throws =>  KeyNotFoundException

            //if (citiesOfDictionary.ContainsKey("IR"))
            //{
            //    Console.WriteLine(citiesOfDictionary["IR"]);
            //}

            // Use TryGetValue() to get a value of unknown key
            //string result;

            //if (citiesOfDictionary.TryGetValue("IR", out result))
            //{
            //    Console.WriteLine(result);
            //}

            //// use ElementAt() to retrieve key-value pair using index
            //for (int i = 0; i < citiesOfDictionary.Count; i++)
            //{
            //    Console.WriteLine("Key: {0}, Value: {1}",
            //        citiesOfDictionary.ElementAt(i).Key,
            //        citiesOfDictionary.ElementAt(i).Value);
            //}

            //citiesOfDictionary["UK"] = "Liverpool, Bristol"; // update value of UK key
            //citiesOfDictionary["USA"] = "Texas, San Francisco"; // update value of USA key
            // citiesOfDictionary["France"] = "Paris"; // Throws run-time exception: KeyNotFoundException

            // Use ContainsKey() method before accessing unknown keys
            //if (citiesOfDictionary.ContainsKey("France"))
            //{
            //    citiesOfDictionary["France"] = "Paris";
            //}

            citiesOfDictionary.Remove("UK"); // removes the existing key-value pair from a dictionary
            // citiesOfDictionary.Remove("France"); // Throws run-time exception: KeyNotFoundException

            // Check key before removing it
            if (citiesOfDictionary.ContainsKey("France"))
            {
                citiesOfDictionary.Remove("France");
            }

            citiesOfDictionary.Clear(); // remove all elements

            #endregion

            #region SortedList<>

            // SortedList<Tkey, TValue> : collection classes
            //                            that can store key-value paris
            //                            that are stored by the keys
            //                            based on the associated IComparer implementation .  

            // Features like dictionary ...
            #endregion

            #region Queue<>

            // Queue<T>: is a special type of collection
            //     that stores the elements in FIFO style (First In First Out),
            //     Exactly opposite of the Stack<T> collection.
            //     It contains the elements in the order they were added.

            // Elements can be added using Enqueue() method.
            // can not use collection-initializer syntax.
            // Elements can be retrieved using the Dequeue() and the Peek() methods.
            // It does not support an Indexer.

            // Creating and Add Elements in the Queue
            Queue<int> callerIds = new Queue<int>();
            callerIds.Enqueue(1);
            callerIds.Enqueue(2);
            callerIds.Enqueue(3);
            callerIds.Enqueue(4);

            //foreach (var id in callerIds)
            //{
            //    Console.Write(id);
            //}

            // Reading Elements from a Queue

            // The Dequeue() and the Peek() method
            //      is used to retrieve the first element
            //      in a queue collection.

            // The Dequeue() removes and returns the first element from a Queue
            //      Because the queue stores elements in FIFO order

            // Calling the Dequeue() method
            //    on an empty queue will throw the InvalidOperationException

            Queue<string> stringQueue = new Queue<string>();
            stringQueue.Enqueue("H");
            stringQueue.Enqueue("e");
            stringQueue.Enqueue("l");
            stringQueue.Enqueue("l");
            stringQueue.Enqueue("o");

            //Console.WriteLine("Total Elements: {0}", stringQueue.Count);

            //while (stringQueue.Count > 0)
            //{
            //    Console.WriteLine(stringQueue.Dequeue());
            //}

            //Console.WriteLine("Total Elements: {0}", stringQueue.Count);

            // The Peek() method always returns the first item from a queue collection
            //      without removing it from the queue. 

            // Calling the Peek() method on an empty queue will throw a run-time exception => InvalidOperationException

            //Console.WriteLine("Total Elements: {0}", stringQueue.Count); // Prints 5

            //if (stringQueue.Count > 0)
            //{
            //    Console.WriteLine(stringQueue.Peek());
            //    Console.WriteLine(stringQueue.Peek());
            //}

            //Console.WriteLine("Total Elements: {0}", stringQueue.Count); // Prints 5

            // Infinite Loop: Please don't run this !
            //while (stringQueue.Count>0)
            //{
            //    Console.WriteLine(stringQueue.Peek());
            //}

            // The Contains() method checks whether an item exists in a queue or not.
            //    It returns true if the specified item exists,
            //    otherwise return false.

            //Console.WriteLine(stringQueue.Contains("H")); // Prints True
            //Console.WriteLine(stringQueue.Contains("B")); // Prints False

            #endregion

            #region Stack<>

            // Stack is a special type of collection
            //     that stores elements in LIFO style ( Last In First Out ) .

            // Stack is useful to store temporary data in LIFO style,
            //      and you might want to delete an element
            //      after retrieving its value .

            // Stack<T> can contain elements of the specified type.
            //      It provides compile-time checking
            //      and doesn't perform boxing-unboxing because it is generic .

            // elements can be added using the Push() method.
            // Cannot use collection-initializer syntax.

            // Elements can be retrieved using the Pop() and the Peek() methods.
            // It does not support an Indexer.

            // Creating Stack and Add Elements
            // Stack allows null( for reference types ) and duplicate values.

            //Stack<int> myStack = new Stack<int>();
            //myStack.Push(1);
            //myStack.Push(2);
            //myStack.Push(3);
            //myStack.Push(4);

            //foreach (var item in myStack)
            //{
            //    Console.Write(item + ",");
            //}

            //Console.WriteLine();

            // You can also create a Stack from an array
            //int[] arr = new[] { 1, 2, 3, 4 };
            //Stack<int> myStack = new Stack<int>(arr);

            //foreach (var item in myStack)
            //{
            //    Console.Write(item + ";");
            //}

            //Console.WriteLine();

            // Access Stack using Pop()
            // The Pop method returns the last element and removes it from a Stack.
            //    If a stack is empty,
            //    then it will throw the InvalidOperationException

            //Console.WriteLine("Number of elements in Stack: {0}", myStack.Count);

            //while (myStack.Count>0)
            //{
            //    Console.Write(myStack.Pop()+";");
            //}

            //Console.WriteLine("\nnumber of elements in Stack: {0}", myStack.Count);

            // Retrieve Elements using Peek()

            // The Peek() method returns the lastly added value from the stack
            //    but does not remove it.
            //    Calling the Peek() method on an empty stack
            //    will throw the InvalidOperationException. 

            //Console.WriteLine("Number of elements in Stack: {0}", myStack.Count);

            //if (myStack.Count > 0)
            //{
            //    Console.WriteLine(myStack.Peek()); // Prints 4
            //    Console.WriteLine(myStack.Peek()); // Prints 4
            //}

            //Console.WriteLine("Number of elements in Stack: {0}", myStack.Count);

            // Contains()
            // The Contains() method checks whether the specified element exists in a Stack collection or not. It returns True if it exists, otherwise false.

            // Console.WriteLine(myStack.Contains(1)); // prints True
            // Console.WriteLine(myStack.Contains(5)); // prints False

            #endregion
        }
    }
}
