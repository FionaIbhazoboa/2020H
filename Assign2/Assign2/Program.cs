using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign2
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
            Console.WriteLine("--- Forward List ---\n");
            mobile.printallForward();
            Console.WriteLine("\n");

            //prints the list in reverse
            Console.WriteLine("--- Reverse List ---\n");
            mobile.printallReverse();
            Console.WriteLine("\n");

            Console.WriteLine("--- Forward List ---\n");


            //creates an arraylist of mobile objects called mobs.
            MyArray<MobileObject> mobs;
            int num = 10;
            mobs = new MyArray<MobileObject>(num);
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
            Console.WriteLine("--- Forward Array ---\n");
            mobs.printallForward();
            Console.WriteLine("\n");
            //prints the array in reverse.
            Console.WriteLine("--- Reverse Array ---\n");
            mobs.printallReverse();
            Console.WriteLine("\n");
            //deletes elements in the array.
            mobs.deleteAll();
            
            Console.ReadKey();
        }
    }
}
