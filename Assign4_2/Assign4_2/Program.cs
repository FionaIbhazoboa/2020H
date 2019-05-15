using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//A program that allows one to insert into a tree and print them out in post, pre and inorder.
namespace Assign4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initializes my tree called bst
            MyBST<MobileObject> bst = new MyBST<MobileObject>();
            //Creates instances of NPC and Vehicle
            NPC Gardener = new NPC("01");
            NPC Maid = new NPC("02");
            NPC Butler = new NPC("03");
            NPC Sim1 = new NPC("04");
            NPC Sim2 = new NPC("05");
            NPC Sim3 = new NPC("06");
            NPC Sim4 = new NPC("07");
            NPC Sim5 = new NPC("08");
            Vehicle vehicle1 = new Vehicle("09");
            Vehicle vehicle2 = new Vehicle("10");
            Vehicle vehicle3 = new Vehicle("11");
            Vehicle vehicle4 = new Vehicle("12");
            Vehicle vehicle5 = new Vehicle("13");
            Vehicle vehicle6 = new Vehicle("14");
            Vehicle vehicle7 = new Vehicle("15");
            Vehicle vehicle8 = new Vehicle("16");
            //inserts them into the tree
            bst.insert(Gardener);
            bst.insert(Maid);
            bst.insert(Butler);
            bst.insert(Sim1);
            bst.insert(Sim2);
            bst.insert(Sim3);
            bst.insert(Sim4);
            bst.insert(Sim5);
            bst.insert(vehicle1);
            bst.insert(vehicle2);
            bst.insert(vehicle3);
            bst.insert(vehicle4);
            bst.insert(vehicle5);
            bst.insert(vehicle6);
            bst.insert(vehicle7);
            bst.insert(vehicle8);

            //Prints out in preOrder
            Console.WriteLine("------------------Prints in PreOrder-----------------");
            Console.WriteLine(bst.preOrder());
            
            //prints out inOrder
            Console.WriteLine("------------------Prints in inOrder-----------------");
            Console.WriteLine(bst.inOrder());

            //Prints out in postOrder
            Console.WriteLine("------------------Prints in PostOrder-----------------");
            Console.WriteLine(bst.postOrder());
            
            //prints out the smallest value
            Console.WriteLine("------------------Prints the smallest item in the tree-----------------");
            Console.WriteLine(bst.findsmallestbst().value.ToString());

            Console.WriteLine(); 
            Console.ReadKey();
        }
    }
}
