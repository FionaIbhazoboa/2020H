using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeapLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialise a heap to some size
            int sizeOfHeap = 10;
            BinaryHeap<int> sampleHeap;
            sampleHeap = new BinaryHeap<int>(sizeOfHeap);

            //populate a heap
            for (int i = 0; i < sizeOfHeap; i++)
            {        
                sampleHeap.AddItem(i);
            }
            //This line shows how to use comparison, element 5 is less than element 6 and returns -1
            Console.WriteLine("Comparison test, element 5 vs Element 6");
            Console.WriteLine(sampleHeap.GetItem(5).CompareTo(sampleHeap.GetItem(6)));

            //Print each  element in the heap
            Console.Write("Useless Linear Heap: ");
            foreach (int i in sampleHeap )
            {
                Console.Write(i + " ");                
            }
            Console.WriteLine();

            Console.WriteLine("Binary Heap, note that there are a couple of bugs here, because Additem is for you to implement: ");
            BinaryHeap<int> sampleHeap2;
            sampleHeap2 = new BinaryHeap<int>(16);
            sampleHeap2.AddItem(1);
            sampleHeap2.AddItem(3);
            sampleHeap2.AddItem(36);
            sampleHeap2.AddItem(2);
            sampleHeap2.AddItem(19);
            sampleHeap2.AddItem(25);
            sampleHeap2.AddItem(100);
            sampleHeap2.AddItem(17);
            sampleHeap2.AddItem(7);
            sampleHeap2.AddItem(5);
            sampleHeap2.AddItem(21);
            sampleHeap2.AddItem(71);
            sampleHeap2.AddItem(66);
            sampleHeap2.AddItem(23);
            sampleHeap2.AddItem(9);
           // Build Min Heap will crash on certain sizes sadly
            sampleHeap2.buildMaxHeap();

            foreach (int i in sampleHeap2)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        
        }
    }
}
