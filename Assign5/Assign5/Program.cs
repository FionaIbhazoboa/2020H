using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializes my tree called bst
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
            Console.WriteLine(bst.inOrder()); 
            Console.WriteLine("Bst delete: ");
            bst.delete(Sim3);// works
            Console.WriteLine(bst.inOrder());

            MyAVL<MobileObject> avl = new MyAVL<MobileObject>();
            avl.insert(Gardener);
            avl.insert(Maid);
            avl.insert(Butler);
            avl.insert(Sim1);
            avl.insert(Sim2);
            avl.insert(Sim3);
            avl.insert(Sim4);
            avl.insert(Sim5);
            avl.insert(vehicle1);
            avl.insert(vehicle2);
            avl.insert(vehicle3);
            avl.insert(vehicle4);
            avl.insert(vehicle5);
            avl.insert(vehicle6);
            avl.insert(vehicle7);
            avl.insert(vehicle8);
            Console.WriteLine("Avl insert: ");
            Console.WriteLine(avl.inOrder()); 
            Console.WriteLine("Avl delete: ");


            avl.delete(vehicle2);  //works
            Console.WriteLine(avl.preOrder());

            MySplayTree<MobileObject> spt = new MySplayTree<MobileObject>();
            spt.insert(Gardener);
            spt.insert(Maid);
            spt.insert(Butler);
            spt.insert(Sim1);
            spt.insert(Sim2);
            spt.insert(Sim3);
            spt.insert(Sim4);
            spt.insert(Sim5);
            spt.insert(vehicle1);
            spt.insert(vehicle2);
            spt.insert(vehicle3);
            spt.insert(vehicle4);
            spt.insert(vehicle5);
            spt.insert(vehicle6);
            spt.insert(vehicle7);
            spt.insert(vehicle8);
            Console.WriteLine("SPT insert: ");
            spt.ToString();

            /* MyRBTree<MobileObject> rbt = new MyRBTree<MobileObject>();
             rbt.insert(Gardener);
             rbt.insert(Maid);
             rbt.insert(Butler);
             rbt.insert(Sim1);
             rbt.insert(Sim2);
             rbt.insert(Sim3);
             rbt.insert(Sim4);
             rbt.insert(Sim5);
             rbt.insert(vehicle1);
             rbt.insert(vehicle2);
             rbt.insert(vehicle3);
             rbt.insert(vehicle4);
             rbt.insert(vehicle5);
             rbt.insert(vehicle6);
             rbt.insert(vehicle7);
             rbt.insert(vehicle8); */
            //Console.WriteLine("RBT insert: ");
            //Console.WriteLine(rbt.preOrder());

            /* My2_3_4Tree<MobileObject> _234 = new My2_3_4Tree<MobileObject>();

             _234.insert(Gardener);
             _234.insert(Maid);
             _234.insert(Butler);
             _234.insert(Sim1);
             _234.insert(Sim2);
             _234.insert(Sim3);
             _234.insert(Sim4);
             _234.insert(Sim5);
             _234.insert(vehicle1);
             _234.insert(vehicle2);
             _234.insert(vehicle3);
             _234.insert(vehicle4);
             _234.insert(vehicle5);
             _234.insert(vehicle6);
             _234.insert(vehicle7);
             _234.insert(vehicle8); */







            Console.ReadKey();
        }
    }
}
