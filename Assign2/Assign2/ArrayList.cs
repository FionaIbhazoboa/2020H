using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign2
{

    class MyArray<T>
    {
        private T[] arraylist;
        public int currentindex = 0;
        //initialize the size of the array
        public MyArray(int size)
        {
            arraylist = new T[size + 1];
            currentindex = 0;
        }
        public void Grow(int newsize)
        {
            Array.Resize(ref arraylist, newsize);
        }
        //gets the item
        public T getItem(int index)
        {
            return arraylist[index];
        }
        //Set the items in the arraylist
        public void setItem(int index, T value)
        {
            if (index >= arraylist.Length)
                Grow(arraylist.Length * 2);

            arraylist[index] = value;
        }
        //Add item to list
        public void Append(T value)
        {
            arraylist[currentindex] = value;
            currentindex++;
        }
        //Delete last element in the list
        public void deleteLast(int index)
        {

            while (arraylist != null)
            {
                for (int i = index; i < arraylist.Length-1; i++)
                {
                    arraylist[i] = arraylist[i + 1];
                }
                Array.Resize(ref arraylist, arraylist.Length-1);

            }
        }
        //print all elements in array starting from 0 to end
        public void printallForward()
        {
            for (int i = 0; i < arraylist.Length; i++)
            {
                Console.WriteLine(arraylist[i] + " ");
            }

        }
        //print all elements in array starting from end to 0
        public void printallReverse()
        {
            for (int i = arraylist.Length-1; i >= 0; i--)
            {
                Console.WriteLine(arraylist[i] + " ");
            }
        }
        //Makes the size of the array empty
        public void deleteAll()
        {
            arraylist = new T[0];
            Console.WriteLine("Arraylist is empty");
        }
    }
}
