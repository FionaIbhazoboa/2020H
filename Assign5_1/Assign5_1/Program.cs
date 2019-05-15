using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// This program allows one to insert different object type into a BST tree, AVL tree, Splay tree and Redblack Tree,
/// Objects can then be printed off, searched for in the list and deleted. 
/// </summary>
namespace Assign5_1
{
    public static class Util
    {

        private static Random rnd = new Random();
        public static int GetRandom()
        {
            return rnd.Next(0, 1500);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numElements = 5000;
            Stopwatch stopWatch;
            TimeSpan ts;
            string elapsedTime;
            MyBST<MobileObject> bst = new MyBST<MobileObject>();
            MyAVL<MobileObject> avl = new MyAVL<MobileObject>();
            SplayTree<MobileObject> spt = new SplayTree<MobileObject>();
            MyRBTree<MobileObject> rbt = new MyRBTree<MobileObject>();
            for (int i = 0; i < numElements; i++)
            {
                bst.insert(new NPC(Util.GetRandom()));
                bst.insert(new Vehicle(Util.GetRandom()));
                
                avl.insert(new NPC(Util.GetRandom()));
                avl.insert(new Vehicle(Util.GetRandom()));
                rbt.insert(new NPC(Util.GetRandom()));
                rbt.insert(new Vehicle(Util.GetRandom()));
            }
            for (int i = 0; i < numElements; i++)
            {
                spt.Insert(new NPC(Util.GetRandom()));
                spt.Insert(new Vehicle(Util.GetRandom()));
            }

            

            //Begin timing
           Console.WriteLine("Bst insert:");
            stopWatch = new Stopwatch();
            stopWatch.Start();         
            Console.WriteLine(bst.inOrder());
            ts = stopWatch.Elapsed;
            Console.WriteLine();
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("BSTRunTime " + elapsedTime);


            /*stopWatch = new Stopwatch();
           stopWatch.Start();
           Console.WriteLine("\nAvl insert: ");
           Console.WriteLine(avl.inOrder());
           ts = stopWatch.Elapsed;
           Console.WriteLine();
           elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
           Console.WriteLine("AVLRunTime " + elapsedTime); 

          Console.WriteLine("\nSPT insert: ");
           stopWatch = new Stopwatch();
           stopWatch.Start();

           Console.WriteLine(spt.ToString());
           ts = stopWatch.Elapsed;
           Console.WriteLine();
           elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
           Console.WriteLine("SPTRunTime " + elapsedTime); 

           Console.WriteLine("\nRbt insert: ");
          stopWatch = new Stopwatch();
          stopWatch.Start();

          Console.WriteLine(rbt.inOrder());
          ts = stopWatch.Elapsed;
          Console.WriteLine();
          elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
          Console.WriteLine("RBTRunTime " + elapsedTime);  */


            Console.ReadKey();
        }
    }
}
