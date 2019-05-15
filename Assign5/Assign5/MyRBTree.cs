using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign5
{
   enum Color
   {
        Red,
        Black
   }
    class MyRBTree<T> where T : IComparable<T>
    {
        private Node<T> root = null;
        private void LeftRotate(Node<T> X)
        {
            Node<T> Y = X.right; // set Y
            X.right = Y.left;//turn Y's left subtree into X's right subtree
            if (Y.left != null)
            {
                Y.left.parent = X;
            }
            if (Y != null)
            {
                Y.parent = X.parent;//link X's parent to Y
            }
            if (X.parent == null)
            {
                root = Y;
            }
            //if (X == X.parent.left)
            //{
            //    X.parent.left = Y;
            //}
            else
            {
                X.parent.right = Y;
            }
            Y.left = X; //put X on Y's left
            if (X != null)
            {
                X.parent = Y;
            }


        }
        private void RightRotate(Node<T> Y)
        {
            // right rotate is simply mirror code from left rotate
            Node<T> X = Y.left;
            Y.left = X.right;
            if (X.right != null)
            {
                X.right.parent = Y;
            }
            if (X != null)
            {
                X.parent = Y.parent;
            }
            if (Y.parent == null)
            {
                root = X;
            }
            if (Y == Y.parent.right)
            {
                Y.parent.right = X;
            }
            if (Y == Y.parent.left)
            {
                Y.parent.left = X;
            }

            X.right = Y;//put Y on X's right
            if (Y != null)
            {
                Y.parent = X;
            }

        }
        public void insert(T v)
        {
            Node<T> newItem = new Node<T>(v);
            if (root == null)
            {
                root = newItem;
                root.colour = Color.Black;
                return;
            }
            Node<T> Y = null;
            Node<T> X = root;
            while (X != null)
            {
                Y = X;
                if (newItem.value.CompareTo(X.value) < 0)
                {
                    X = X.left;
                }
                else
                {
                    X = X.right;
                }
            }
            newItem.parent = Y;
            if (Y == null)
            {
                root = newItem;
            }
            else if (newItem.value.CompareTo(Y.value) < 0)
            {
                Y.left = newItem;
            }
            else
            {
                Y.right = newItem;
            }
            newItem.left = null;
            newItem.right = null;
            newItem.colour = Color.Red;//colour the new node red
            InsertFixUp(newItem);//call method to check for violations and fix


        }
        private void InsertFixUp(Node<T> v)
        {
            //Checks Red-Black Tree properties
            while (v != root && v.parent.colour == Color.Red)
            {
                /*We have a violation*/
                if (v.parent == v.parent.parent.left)
                {
                    Node<T> Y = v.parent.parent.right;
                    if (Y != null && Y.colour == Color.Red)//Case 1: uncle is red
                    {
                        v.parent.colour = Color.Black;
                        Y.colour = Color.Black;
                        v.parent.parent.colour = Color.Red;
                        v = v.parent.parent;
                    }
                    else //Case 2: uncle is black
                    {
                        if (v == v.parent.right)
                        {
                            v = v.parent;
                            LeftRotate(v);
                        }
                        //Case 3: recolour & rotate
                        v.parent.colour = Color.Black;
                        v.parent.parent.colour = Color.Red;
                        RightRotate(v.parent.parent);
                    }

                }
                else
                {
                    //mirror image of code above
                    Node<T> X = null;

                    X = v.parent.parent.left;
                    if (X != null && X.colour == Color.Black)//Case 1
                    {
                        v.parent.colour = Color.Red;
                        X.colour = Color.Red;
                        v.parent.parent.colour = Color.Black;
                        v = v.parent.parent;
                    }
                    else //Case 2
                    {
                        if (v == v.parent.left)
                        {
                            v = v.parent;
                            RightRotate(v);
                        }
                        //Case 3: recolour & rotate
                        v.parent.colour = Color.Black;
                        v.parent.parent.colour = Color.Red;
                        LeftRotate(v.parent.parent);

                    }

                }
                root.colour = Color.Black;//re-colour the root black as necessary
            }

        }
        public string preOrder()
        {
            return preOrdera(root);
        }
        private string preOrdera(Node<T> root)
        {
            if (root == null)
            {
                return "";
            }
            Console.WriteLine(root.value.ToString());
            preOrdera(root.left);
            preOrdera(root.right);
            return "";
        }
        public Node<T> Find(T v)
        {
            bool isFound = false;
            // Node temp = root;
            Node<T> item = null;
            while (!isFound)
            {
                if (root == null)
                {
                    break;
                }
                if (v.CompareTo(root.value) < 0)
                {
                    root = root.left;
                }
                if (v.CompareTo(root.value) > 0)
                {
                    root = root.right;
                }
                if (v.CompareTo(root.value) == 0)
                {
                    isFound = true;
                    item = root;
                }
            }
            if (isFound)
            {
                Console.WriteLine("{0} was found", v);
                return root;
            }
            else
            {
                Console.WriteLine("{0} not found", v);
                return null;
            }
        }
        public void Delete(T v)
        {
            //first find the node in the tree to delete and assign to item pointer/reference
            Node<T> item = Find(v);
            Node<T> X = null;
            Node<T> Y = null;

            if (item == null)
            {
                Console.WriteLine("Nothing to delete!");
                return;
            }
            if (item.left == null || item.right == null)
            {
                Y = item;
            }
            else
            {
                Y = TreeSuccessor(item);
            }
            if (Y.left != null)
            {
                X = Y.left;
            }
            else
            {
                X = Y.right;
            }
            if (X != null)
            {
                X.parent = Y;
            }
            if (Y.parent == null)
            {
                root = X;
            }
            else if (Y == Y.parent.left)
            {
                Y.parent.left = X;
            }
            else
            {
                Y.parent.left = X;
            }
            if (Y != item)
            {
                item.value = Y.value;
            }
            if (Y.colour == Color.Black)
            {
                DeleteFixUp(X);
            }

        }
        private void DeleteFixUp(Node<T> X)
        {

            while (X != null && X != root && X.colour == Color.Black)
            {
                if (X == X.parent.left)
                {
                    Node<T> W = X.parent.right;
                    if (W.colour == Color.Red)
                    {
                        W.colour = Color.Black; //case 1
                        X.parent.colour = Color.Red; //case 1
                        LeftRotate(X.parent); //case 1
                        W = X.parent.right; //case 1
                    }
                    if (W.left.colour == Color.Black && W.right.colour == Color.Black)
                    {
                        W.colour = Color.Red; //case 2
                        X = X.parent; //case 2
                    }
                    else if (W.right.colour == Color.Black)
                    {
                        W.left.colour = Color.Black; //case 3
                        W.colour = Color.Red; //case 3
                        RightRotate(W); //case 3
                        W = X.parent.right; //case 3
                    }
                    W.colour = X.parent.colour; //case 4
                    X.parent.colour = Color.Black; //case 4
                    W.right.colour = Color.Black; //case 4
                    LeftRotate(X.parent); //case 4
                    X = root; //case 4
                }
                else //mirror code from above with "right" & "left" exchanged
                {
                    Node<T> W = X.parent.left;
                    if (W.colour == Color.Red)
                    {
                        W.colour = Color.Black;
                        X.parent.colour = Color.Red;
                        RightRotate(X.parent);
                        W = X.parent.left;
                    }
                    if (W.right.colour == Color.Black && W.left.colour == Color.Black)
                    {
                        W.colour = Color.Black;
                        X = X.parent;
                    }
                    else if (W.left.colour == Color.Black)
                    {
                        W.right.colour = Color.Black;
                        W.colour = Color.Red;
                        LeftRotate(W);
                        W = X.parent.left;
                    }
                    W.colour = X.parent.colour;
                    X.parent.colour = Color.Black;
                    W.left.colour = Color.Black;
                    RightRotate(X.parent);
                    X = root;
                }
            }
            if (X != null)
                X.colour = Color.Black;
        }

        private Node<T> Minimum(Node<T> X)
        {
            while (X.left.left != null)
            {
                X = X.left;
            }
            if (X.left.right != null)
            {
                X = X.left.right;
            }
            return X;
        }
        private Node<T> TreeSuccessor(Node<T> X)
        {
            if (X.left != null)
            {
                return Minimum(X);
            }
            else
            {
                Node<T> Y = X.parent;
                while (Y != null && X == Y.right)
                {
                    X = Y;
                    Y = Y.parent;
                }
                return Y;
            }
        }

        
    }
} 
