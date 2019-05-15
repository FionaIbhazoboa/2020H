using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign4
{
    class MyBinaryHeap<T> : IEnumerable where T : IComparable<T>
    {
        private T[] array;
        private int count = -1;  
        public MyBinaryHeap(int size)
        {
            array = new T[size];
            count = 0;
        }
        // Get Item should really be private (needs to be public in the lab for demo purposes
        private T GetItem(int index)
        {
            return array[index];
        }
        private void SetItem(int index, T value)
        {
            if (index >= array.Length)
                Grow(array.Length * 2);
            array[index] = value;
        }
        private void Grow(int newsize)
        {
            Array.Resize(ref array, newsize);
        }

        private int LeftChild(int pos)
        { return 2 * pos + 1; }
        private int RightChild(int pos)
        { return 2 * pos + 2; }
        private int Parent(int pos)
        { return (pos - 1) / 2; }
        //iterator so you can see how they work (sort of? It works but it's not really obvious how)
        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < array.Length; index++)
            {
                // Yield each element 
                yield return array[index];
            }
        }
        public void AddItem(T value)
        {
            // THis is part of your lab 6
            // you need to make this code actually insert in a tree like fashion, not just this crap

            if (count == array.Length)
                throw new Exception("Nah boo");
            //Insert Logic
            // If the tree is empty, insert at the bottom (it does that already)
            // if not, insert at the end, 
            // From the end you either need to swap to the root, and keep minheapify
            array[count] = value;
            count++;
            int i = count - 1;
            while (i > 0)
            {
                int j = (i - 1) / 2;
                T item = array[j];
                if (item.CompareTo(array[i]) < 0 || item.CompareTo(array[i]) == 0)
                {
                    break;
                }
                Swap(i, j);
                i = j;
            }
        }
        // Given an array index, it should keep moving it up the array until it gets to the right spot
        public void MoveUp(int position)
        {
            int pos;
            int root = position;
            if(root != 0)
            {
                //if pos is smaller that parrent, move up. + 2/ 2 -1
                pos = Parent(root);
                if ((array[pos].CompareTo(array[root])) > 0)
                {
                    T tmp = array[pos];
                    array[pos] = array[root];
                    array[root] = tmp;
                    MoveUp(pos);
                }
            }
        }
        //ExtractRoot (which is the same as extract min in our case)
        public T ExtractHead()
        {
            //check to make sure the heap isn't empty, if it is, return a 'null' or at least, default object
            if (count <= 0) 
                return default(T);
            // this should get the head
            T head = array[0];
            //then in the lab you need to implement this part yourself
            //array[0] needs to get some value (most likely it will be array[0] = array[Count-1]
            array[0] = array[count - 1];
            // then remove the data at [count-1], and make sure you don't try and use that data later (remember you can do array[x] = default(T))
            count--;
            //then Minheapify the array
            MinHeapify(0);
            return head;
        }
        //Swap method to swap to methods
        public void Swap(int position1, int position2)
        {
            T first = array[position1];
            array[position1] = array[position2];
            array[position2] = first;
        }
        //heapify should heapify the subtree for the element i that is the root of a subtree
        public void MoveDown(int position)
        {
            int root = position;
            // while the root has at least one child
            while ((2 * root + 1) <= count)
            {
                // root*2+1 points to the left child
                int child = 2 * root + 1;
                // take the highest of the left or right child
                if ((child + 1) <= count && (array[child].CompareTo(array[child + 1])) < 0)
                {
                    // then point to the right child instead
                    child = child + 1;
                }
                // out of max-heap order
                // swap the child with root if child is greater
                if ((array[root].CompareTo(array[child])) < 0)
                {
                    T tmp = array[root];
                    array[root] = array[child];
                    array[child] = tmp;

                    // return the swapped root to test against
                    //  it's new children
                    root = child;
                }
                else
                    return;   
            }
        }
        //build a minheap by calling MinHeapify()
        public void buildMinHeap()
        {
            int midPoint = array.Length / 2;
            for (int indexsOfLeaves = midPoint; indexsOfLeaves >= 0; indexsOfLeaves--)
            {
                MinHeapify(indexsOfLeaves);
            }
        }
        //MinHeapify method to keep the smallest item at the top/root.
        public void MinHeapify(int position)
        {
            int lchild = LeftChild(position);
            int rchild = RightChild(position);
            int smallest = position;
            
            if ((lchild < count) && (array[lchild].CompareTo(array[position])) < 0)  
            {
                smallest = lchild;
            }
            if ((rchild < count)  && (array[rchild].CompareTo(array[smallest])) < 0) 
            {
                smallest = rchild;
            }
            if (smallest != position)
            {
                Swap(position, smallest);
                MinHeapify(smallest);
            }
        }
        public void HeapSort()
        {
            int position = array.Length-1;
            // Build heap (rearrange array)
            buildMinHeap();
            // One by one extract n element from heap
            for (int i = position - 1; i >= 0; i--)
            {
                // Move current root to end
                T temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                count--;
                // call min heapify on the reduced heap
                MinHeapify(0);
            }
        }
        public void deleteHeap()
        {
            Array.Resize(ref array, 0);
            count = 0;
        }
    }
}
