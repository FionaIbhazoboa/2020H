using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//This program adds object type MobileObject to a Linked list, Arraylist, 
//Circular arraylist which implements a queue and a Circular linked list which implements a stack and queue.
//Objects are added then printed off with the time taken to do the task in milliseconds.
namespace Assign3
{
    class Program
    {
        static void Main(string[] args)
        {
            //creates a linked list of mobile objects called mobile.
            MyLinkedList<MobileObject> mobile = new MyLinkedList<MobileObject>();
            NPC Gardener = new NPC("Yussef", "01", 22, 12, 5);
            NPC Maid = new NPC("Reyn", "02", 19, 16, 5);
            NPC Butler = new NPC("Chris", "03", 25, 20, 6);
            NPC Sim1 = new NPC("Sara", "04", 20, 19, 6);
            NPC Sim2 = new NPC("Roy", "05", 10, 13, 7);
            //adds from the last position into the list
            mobile.AddLast(Gardener);
            mobile.AddLast(Maid);
            mobile.AddLast(Butler);
            mobile.AddLast(Sim1);
            mobile.AddLast(Sim2);

            Vehicle vehicle1 = new Vehicle("Car", "06", 50, 30, 23);
            Vehicle vehicle2 = new Vehicle("Bike", "07", 34, 20, 12);
            Vehicle vehicle3 = new Vehicle("Bicycle", "08", 20, 17, 12);
            Vehicle vehicle4 = new Vehicle("Tricycle", "09", 17, 16, 11);
            Vehicle vehicle5 = new Vehicle("Bus", "10", 54, 38, 25);
            mobile.AddLast(vehicle1);
            mobile.AddLast(vehicle2);
            mobile.AddLast(vehicle3);
            mobile.AddLast(vehicle4);
            mobile.AddLast(vehicle5);
            //prints the list
            Console.WriteLine("------ Forward List ------\n");
            //calculates the time taken
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            mobile.printallForward();
            var elapsedMs = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("\nTime Taken to Perform Task: " + elapsedMs + "ms");
            Console.WriteLine("\n");

            


            //creates an arraylist of mobile objects called mobs.
            MyArrayList<MobileObject> mobs;
            int num = 10;
            mobs = new MyArrayList<MobileObject>(num);
            //Adds the instances to the array
            mobs.setItem(0, Gardener);
            mobs.setItem(1, Maid);
            mobs.setItem(2, Butler);
            mobs.setItem(3, Sim1);
            mobs.setItem(4, Sim2);
            mobs.setItem(5, vehicle1);
            mobs.setItem(6, vehicle2);
            mobs.setItem(7, vehicle3);
            mobs.setItem(8, vehicle4);
            mobs.setItem(9, vehicle5);
            //prints the array.
            Console.WriteLine("------ Forward Array ------\n");
            stopwatch = System.Diagnostics.Stopwatch.StartNew();
            mobs.printallForward();
            elapsedMs = stopwatch.ElapsedMilliseconds;
            Console.WriteLine( "\nTime Taken to Perform Task: "+ elapsedMs + "ms");
            Console.WriteLine("\n");

            //creates a circular linked list of mobile objects called moving.
            CircularLL<MobileObject> moving = new CircularLL<MobileObject>();
            moving.enqueue(Gardener);
            moving.enqueue(Maid);
            moving.enqueue(Butler);
            moving.enqueue(Sim1);
            moving.enqueue(Sim2);
            moving.enqueue(vehicle1);
            moving.enqueue(vehicle2);
            moving.enqueue(vehicle3);
            moving.enqueue(vehicle4);
            moving.enqueue(vehicle5);
            Console.WriteLine("------ Circular Linked List Queue ------\n");
            stopwatch = System.Diagnostics.Stopwatch.StartNew();
            moving.printallForward();
            elapsedMs = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("\nTime Taken to Perform Task: " + elapsedMs + "ms");
            //deletes last item in the list
            Console.WriteLine("\nDeleted: " + moving.dequeue());
            Console.WriteLine("\n");

            //push objects into stack
            moving.Push(Gardener);
            moving.Push(Maid);
            moving.Push(Butler);
            moving.Push(Sim1);
            moving.Push(Sim2);
            moving.Push(vehicle1);            
            moving.Push(vehicle2);
            moving.Push(vehicle3);
            moving.Push(vehicle4);
            moving.Push(vehicle5);
            Console.WriteLine("------ Circular Linked List Queue using stacks------\n");
            stopwatch = System.Diagnostics.Stopwatch.StartNew();
            moving.printallForward();
            elapsedMs = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("\nTime Taken to Perform Task: " + elapsedMs + "ms");
            //pop last item added
            Console.WriteLine("\n Object poped from list: " + moving.Pop());
            Console.WriteLine("\n");


            //creates an circular arraylist of mobile objects called move.
            CircularArray<MobileObject> move = new CircularArray<MobileObject>(num);
            move.addBack(Gardener);
            move.addBack(Maid);
            move.addBack(Butler);
            move.addBack(Sim1);
            move.addBack(Sim2);
            move.addBack(vehicle1);
            move.addBack(vehicle2);
            move.addBack(vehicle3);
            move.addBack(vehicle4);
            move.addBack(vehicle5);
            Console.WriteLine("------ Circular Array Queue ------\n");
            stopwatch = System.Diagnostics.Stopwatch.StartNew();
            move.Printall();
            elapsedMs = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("\nTime Taken to Perform Task: " + elapsedMs + "ms");
            Console.WriteLine("\n");




            Console.ReadKey();
        }
    }
}
