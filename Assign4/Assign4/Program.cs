using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//A program that prints out a sorted list of items from a binary heap.
namespace Assign4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialise a heap to some size
            MyBinaryHeap<int> Heap;
            Heap = new MyBinaryHeap<int>(16);
            Console.WriteLine("Heavily taken from the lab: ");
            //add items to the heap.
            Heap.AddItem(1);
            Heap.AddItem(3);
            Heap.AddItem(36);
            Heap.AddItem(2);
            Heap.AddItem(19);
            Heap.AddItem(25);
            Heap.AddItem(100);
            Heap.AddItem(17);
            Heap.AddItem(7);
            Heap.AddItem(5);
            Heap.AddItem(21);
            Heap.AddItem(71);
            Heap.AddItem(66);
            Heap.AddItem(23);
            Heap.AddItem(9);
            Heap.buildMinHeap();
            Console.WriteLine("Heapsort: ");
            Heap.HeapSort();
            //prints out the items in the heap 
            foreach (int i in Heap)
            {
                Console.Write("[{0}]", i);

            }
            Console.ReadLine();
        }
    }
}
