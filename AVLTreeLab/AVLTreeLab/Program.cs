using System;
using System.Diagnostics;

// Flagrantly stolen from https://gist.github.com/aaronjwood/7e0fc962c5cd898b3181
// including the class file
// Significant modifications by Sri

namespace AVLTreeLab
{
    


    class AVLTreeDemo
    {
        static void Main(string[] args)
        {
            Node root = null;
            AVLTree avl = new AVLTree();
            //int SIZE = 10; // tested on up to 200k elements and it works fine
            //int[] testArray = new int[SIZE];
            int[] testArray = { 14, 17, 11, 7, 53, 4, 13, 12, 8 };
            Random rnd = new Random();
            Console.WriteLine("Elements to be inserted into the BST");
            for (int i=0; i<testArray.Length; i++)
            {
                //testArray[i] = rnd.Next(1, 100);
                Console.WriteLine(testArray[i]);
            }
            
            for (int i = 0; i < testArray.Length; i++)
            {
                root = avl.insert(root, testArray[i] );
            }
            Console.WriteLine("Elements in the Tree, in some order");
            Console.WriteLine(avl.PreOrder(root));
            Console.WriteLine("Elements in the Tree, using a level order traversal, yes, I realize the format sucks, cope");
            avl.printLevelOrder(root);

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}

