using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class GenericArray<T>
    {
        //The actual array
        private T[] array;
        public int currentindex = 0; 

        //constructor
        public GenericArray(int size)
        {
            array = new T[size + 1];
            currentindex = 0;
        }
        public T getItem(int index)
        {
            return array[index];
        }
        public void setItem(int index, T value)
        {
            if (index >= array.Length)
                Grow(array.Length * 2);

            array[index] = value;
        }
        public void Grow(int newsize)
        {
            Array.Resize(ref array, newsize);
        }
        public void Append(T value)
        {
            array[currentindex] = value;
            currentindex++;
        }
        public void printAll()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i] + " " + i);
            }
                
        }
        public bool Find(T value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
        /*private void Insert(T value)
        {
            
              
        }*/
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*block comment with control +k+c, uncomment with ctrl+k+u
           
            int[] array1 = new int[] { 1, 3, 5, 7, 9 };

            foreach(int element in array1)
            {
                Console.WriteLine(element);
            }*/
            Random random = new Random();
            GenericArray<int>  array2;
            int numelements = random.Next(1, 1001);
            array2 = new GenericArray<int>(numelements);

            for (int i = 0; i<= numelements; i++)
            {
                array2.setItem(i, i * 2);
            }
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i<= numelements; i++)
            {
                Console.WriteLine(array2.getItem(i));
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);
            Console.WriteLine("\n");


            Console.WriteLine("Add Last: ");
            LinkedList myList2 = new LinkedList();

            for (int i = 0; i <= numelements; i++)
            {
                myList2.AddLast(random.Next(1, 100));
            }
           /* myList2.AddLast(random.Next());
            myList2.AddLast("Brian");
            myList2.AddLast("Bonnie");
            myList2.AddLast("Sabine");
            myList2.AddLast("Jamie");
            myList2.AddLast("Wenying");
            myList2.AddLast("Omar"); */
            watch = System.Diagnostics.Stopwatch.StartNew();
            myList2.printAllNodes();
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);


            Console.ReadKey();
        }
    }
}
