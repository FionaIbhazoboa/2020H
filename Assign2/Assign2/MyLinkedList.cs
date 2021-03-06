﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign2
{
    //create a node
    class Node
    {
        public Node next;
        public Node previous;
        public Object data;
    }

    class MyLinkedList<T>
    {
        private Node head;
        private Node tail;
        //Adds into the list from the front
        public void AddFirst(Object data)
        {
            Node toAdd = new Node();

            toAdd.data = data;
            toAdd.next = head;
            toAdd.previous = null;
            tail = head;
            head = toAdd;
        }
        //adds into the list from the last position
        public void AddLast(Object data)
        {
            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;
                head.previous = null;

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
                
                current.next = toAdd;
                toAdd.previous = current;
                tail = current.next;
            }
        }
        //Deletes the last item in the list
        public void DeleteLast()
        {
            Node current = head;
            if (head != null)
            {
                if (head.next == null)
                {
                    head.data = null;
                    head.next = null;
                    head.previous = null;
                }
                else
                {
                    while (current.next.next != null)
                    {
                        current = current.next;
                    }
                    current.next.data = null;
                    current.next.previous = null;
                    current.next = null;
                    tail = current.next;
                }
            }
        }
        //deletes the first item in the list
        public void DeleteFirst()
        {
            Node current = head;
            if(head != null)
            {
                if (head.next == null)
                {
                    head.data = null;
                    head.next = null;
                    head.previous = null;
                }
                else
                {
                    current.next = head;                
                    head.previous = null;
                    current.data = null;
                    current.next = null;
                }
            }
        }
        //print all elements in list starting from head to tail
        public void printallForward()
        {
            Node current = head;

            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }
        //print all elements in list starting from tail to head
        public void printallReverse()
        {
            Node current = tail;

            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.previous;
            }
        }
        //deletes all items in list
        public void deleteAll()
        {
            head = null;
            tail = null;
        }
    }
}
