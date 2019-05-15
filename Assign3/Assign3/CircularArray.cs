using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign3
{
    class CircularArray<T>
    {
        private T[] array;
        private int queueFront;
        private int queueRear;
        public int currentindex;
        // Basic Constructor 
        // Creates an array and initializes the front and rear
        // O(1) in time O (N) in size
        public CircularArray(int size)
        {
            array = new T[size + 1];
            queueFront = 0;
            queueRear = 0;
            currentindex = 0;
        }
        // NYI fully.  
        public void addBack(T value)  //addBack is enqueue
        {
            if ((queueRear == array.Length - 1 && queueFront > 0) || (queueRear != -1 && queueRear + 1 == queueFront))
            {
                grow(array.Length * 2);
            }
            else
            {
                if (queueRear == array.Length - 1 && queueFront > 0)
                    queueRear = -1;
                queueRear += 1;
                array[queueRear] = value;

                if (queueRear == queueFront - 1 && array[queueRear] == null)
                    queueFront += 1;
            }

        } 
        public T removeFront()  //removeFront is dequeue
        {
            //Right now calling this on an empty queue will crash
            T sample = default(T);
            sample = array[queueFront];
            // Because technically T could be not nullable we need to use default(T), which is null.  
            array[queueFront] = default(T);

            if (queueFront + 1 < array.Length + 1 && array[queueFront + 1] != null)
                queueFront += 1;
            else if (array[0] != null && queueFront + 1 == array.Length)
                queueFront = 0;
            return sample;
        }

        // Just returns the front element O(1)
        public T getFront()
        {
            //Calling this on an empty queue will probably crash too
            return array[queueFront];
        }
        // Same old Grow, bit hard to know where to use it if at all though...
        // O(N)
        public void grow(int newsize)
        {
            Array.Resize(ref array, newsize);
        }
        public void Printall()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i] + " ");
            }

        }
    }
}
