using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace SortingLab
{
    
        private static Random rnd = new Random();
        public static int GetRandom()
        {
            return rnd.Next();
        }
   
    class Program
    {
        static void Main(string[] args)
        {
            // Use 10 elements for testing, but then run with 10 000 to see how long it takes.  
            int numElements = 20000;  // Use 10 for testing, but this number cannot exceed about 11000 as the program will use more than 2GB of memory
           
            // On a fast computer the following takes about 0.5 seconds to run (object generation is not trivially fast) with 10 000 elements
            SortableObject[] ArrayofSortables = new SortableObject[numElements];
            for (int i = 0; i < numElements; i++)
            {
                ArrayofSortables[i] = new SortableObject(Util.GetRandom());
            }

            // This just shows you that the keys and the first data element are unique (ish).  
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(ArrayofSortables[i].key + " " + ArrayofSortables[i].Data[1]);
            }


            //Begin timing
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

    
            //Sample from Sri for a simple Insertion Sort
            // make sure to comment this out when you actually do something here.  
           /* for (int i = 0; i < ArrayofSortables.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (ArrayofSortables[j - 1].CompareTo( ArrayofSortables[j]) > 0)
                    {
                        SortableObject temp = ArrayofSortables[j - 1];
                        ArrayofSortables[j - 1] = ArrayofSortables[j];
                        ArrayofSortables[j] = temp;
                    }
                }
            }*/
            //Student code goes here.
            // Possible sorts
            //Bubble Sort
            //Selection Sort
            //Shell Sort
            //QuickSort
            //MergeSort
          
            int gap = ArrayofSortables.Length / 2;
            SortableObject temp;
            while (gap > 0)
            {
                for (int i = 0; i + gap < ArrayofSortables.Length; i++ )
                {
                    int j = i + gap;
                    temp = ArrayofSortables[j];
                    while (j - gap >= 0 && ArrayofSortables[j - gap].CompareTo(temp) > 0)
                    {
                        ArrayofSortables[j] = ArrayofSortables[j - gap];
                        j = j - gap;
                    }
                    ArrayofSortables[j] = temp;
                     

                }
                gap = gap / 2;
            }
           



                stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine();
            Console.WriteLine("The Sorted Version, well, the first 10 elements to show it works");
            Console.WriteLine("The output here is the key in the left column and the first element of the actual data itself");
            Console.WriteLine();
            // Show the first 10 elements as being sorted, to prove that, well, it sorted correctly (the data part is irrelevant).  
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(ArrayofSortables[i].key.ToString("D10") + " " + ArrayofSortables[i].Data[1]);
            }
            // That goofy .key.ToSTring("D10") is what formats it with the leading zero's so all ints are the same length


            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadLine();

        }
    }
}



