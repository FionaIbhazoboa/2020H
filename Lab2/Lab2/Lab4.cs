using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Node
    {
        public Node next;
        //publc Node previous;
        public Object data;
    }

    class LinkedList
    {
        private Node head;
        //private Node tail;
        public void printAllNodes()
        {
            Node current = head;

            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }

        }
        public void AddFirst(Object data)
        {
            Node toAdd = new Node();

            toAdd.data = data;
            toAdd.next = head;
            //tail = head;
            head = toAdd;


        }
        public void AddLast(Object data)
        {
            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;

            }
            else
            {
                Node toAdd = new Node();
                toAdd.data = data;

                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                //tail = current.next;
                current.next = toAdd;
            }
        }
        public void DeleteLast()
        {
            Node current = head;
            if (head != null)
            {
                if (head.next == null)
                {
                    head.data = null;
                    head.next = null;
                }
                else
                {
                    while (current.next.next != null)
                    {
                        current = current.next;
                    }
                    current.next.data = null;
                    current.next = null;
                    //tail = current.next;
                }
            }
        }

    }

   
       /* static void Main(string[] args)
        {
            Console.WriteLine("Add Last: ");
            LinkedList myList2 = new LinkedList();
            myList2.AddLast("Richard");
            myList2.AddLast("Brian");
            myList2.AddLast("Bonnie");
            myList2.AddLast("Sabine");
            myList2.AddLast("Jamie");
            myList2.AddLast("Wenying");
            myList2.AddLast("Omar");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            myList2.printAllNodes();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);

           // Console.WriteLine();

            Console.WriteLine("Add First: ");
            LinkedList myList1 = new LinkedList();
            myList1.AddFirst("Richard");
            myList1.AddFirst("Brian");
            myList1.AddFirst("Bonnie");
            myList1.AddFirst("Sabine");
            myList1.AddFirst("Jamie");
            myList1.AddFirst("Wenying");
            myList1.AddFirst("Omar");
            myList1.printAllNodes();
            Console.WriteLine();

            Console.ReadKey();
        
        } */
}
