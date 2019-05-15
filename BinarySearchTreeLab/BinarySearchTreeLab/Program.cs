using System;
using System.Diagnostics;

// Flagrantly stolen from https://gist.github.com/aaronjwood/7e0fc962c5cd898b3181
// including the class file
// Significant modifications by Sri

namespace BinarySearchTreeLab
{
    


    class BinarySearch
    {
        static void Main(string[] args)
        {
            Node root = null;
            BinarySearchTree bst = new BinarySearchTree();
            //int SIZE = 10; // tested on up to 200k elements and it works fine
            //int[] testArray = new int[SIZE];
            int[] testArray = { 23, 18, 12, 20, 44, 35, 52, 10, 49, 30 };

            Random rnd = new Random();
            Console.WriteLine("Elements to be inserted into the BST");
            for (int i=0; i<10; i++)
            {
                //testArray[i] = rnd.Next(1, 100);
                Console.WriteLine(testArray[i]);
            }
            
            for (int i = 0; i < 10; i++)
            {
                root = bst.insert(root, testArray[i] );
            }
            Console.WriteLine("Elements in the Tree, preorder .  Students get to make this work ");
            // - Lab:  Make the following lines of code work. 
            // Lab: Pre-order, Post Order, In order traversals
            Console.WriteLine(bst.preOrder(root));
            Console.WriteLine("Elements in the Tree, in postorder.  Students get to make this work ");

            Console.WriteLine(bst.postOrder(root));
            Console.WriteLine("Elements in the Tree, in inorder.  Students get to make this work ");

            Console.WriteLine(bst.inOrder(root));
            Console.WriteLine("Elements in the Tree, in inorder.  Students get to make this work ");

            Console.WriteLine(bst.findsmallestbst(root).value.ToString());

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}