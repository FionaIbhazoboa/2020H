using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Heavily inspired from https://algs4.cs.princeton.edu/33balanced/RedBlackBST.java.html
/// 
/// </summary>
namespace Assign5_1
{
    class RBNode<T>
    {
        public T value;
        public RBNode<T> left;
        public RBNode<T> right;
        public Boolean color;
        public RBNode(T v, Boolean color)
        {

            this.value = v;
            this.color = color;
            //this.size = size;
        }
    }
   
    class MyRBTree<T> where T : IComparable<T>
    {
        private static Boolean RED   = true;
        private static Boolean BLACK = false;
        private RBNode<T> root = null;
        // is node x red; false if x is null ?
        private Boolean isRed(RBNode<T> x)
        {
            if (x == null) return false;
            return x.color == RED;
        }
        private RBNode<T> min(RBNode<T> x)
        {
            // assert x != null;
            if (x.left == null) return x;
            else return min(x.left);
        }
        // make a right-leaning link lean to the left
        private RBNode<T> LeftRotate(RBNode<T> X)
        {
            RBNode<T> x = X.right;
            X.right = x.left;
            x.left = X;
            x.color = x.left.color;
            x.left.color = RED;
            return x;

        }
        // make a left-leaning link lean to the right
        private RBNode<T> RightRotate(RBNode<T> Y)
        {
            // right rotate is simply mirror code from left rotate
            RBNode<T> x = Y.left;
            Y.left = x.right;
            x.right = Y;
            x.color = x.right.color;
            x.right.color = RED;
            return x;

        }
        private void flipColors(RBNode<T> Z)
        {
            // h must have opposite color of its two children
            // assert (h != null) && (h.left != null) && (h.right != null);
            // assert (!isRed(h) &&  isRed(h.left) &&  isRed(h.right))
            //    || (isRed(h)  && !isRed(h.left) && !isRed(h.right));
            Z.color = !Z.color;
            Z.left.color = !Z.left.color;
            Z.right.color = !Z.right.color;
        }
        private RBNode<T> moveRedRight(RBNode<T> X)
        {
            // assert (h != null);
            // assert isRed(h) && !isRed(h.right) && !isRed(h.right.left);
            flipColors(X);
            if (isRed(X.left.left))
            {
                X = RightRotate(X);
                flipColors(X);
            }
            return X;
        }
        private RBNode<T> moveRedLeft(RBNode<T> Y)
        {
            // assert (h != null);
            // assert isRed(h) && !isRed(h.left) && !isRed(h.left.left);

            flipColors(Y);
            if (isRed(Y.right.left))
            {
                Y.right = RightRotate(Y.right);
                Y = LeftRotate(Y);
                flipColors(Y);
            }
            return Y;
        }
        private RBNode<T> balance(RBNode<T> h)
        {
            // assert (h != null);

            if (isRed(h.right)) h = LeftRotate(h);
            if (isRed(h.left) && isRed(h.left.left)) h = RightRotate(h);
            if (isRed(h.left) && isRed(h.right)) flipColors(h);

           // h.size = size(h.left) + size(h.right) + 1;
            return h;
        }
        public void insert(T v)
        {
            if (root == null)
            {
                root = new RBNode<T>(v, RED);
                root.value = v;
                root.color = BLACK;
            }
            else
                insertRecursive(root, v);
        }
        public RBNode<T> insertRecursive(RBNode<T> root, T v)
        {
            if (root == null)
            {
                root = new RBNode<T>(v, RED);
                root.value = v;
                //root.parent = root;
                root.color = BLACK;
            }
            // insertion logic, if the value (v )is < root, insert to the root.left
            // otherwise it's >=, so insert to the right
            else if (v.CompareTo(root.value) < 0)
            {
                root.left = insertRecursive(root.left, v);
                //InsertFixUp(root);
            }
            else
            {
                root.right = insertRecursive(root.right, v);
               // InsertFixUp(root);
            }
            //root.left = null;
            //root.right = null;
            // root.color = Color.Red;
            //InsertFixUp(root);

            // fix - up any right-leaning links
            if (isRed(root.right) && !isRed(root.left))
                root = LeftRotate(root);
            if (isRed(root.left) && isRed(root.left.left))
                root = RightRotate(root);
            if (isRed(root.left) && isRed(root.right))
                flipColors(root);


            return root;
        }
        public bool find(T v)
        {
            if (root != null && Contains(root, v) != false)
            {
                Console.WriteLine("Object exists!");
                return true;
            }
            else
            {
                Console.WriteLine("Object does not exist!");
                return false;
            }

        }
        private bool Contains(RBNode<T> root, T v)
        {
            if (root == null)
            {
                return false;
            }
            else if (root.value.CompareTo(v) == 0)
            {
                return true;
            }
            else if (root.value.CompareTo(v) < 0)
            {
                return Contains(root.right, v);
            }
            else
            {
                return Contains(root.left, v);
            }
        }
        public string inOrder()
        {
            return inOrdera(root);
        }
        private string inOrdera(RBNode<T> root)
        {
            if (root == null)
            {
                return "";
            }
            inOrdera(root.left);
            Console.WriteLine(root.value.ToString());
            inOrdera(root.right);
            return "";
        }
        public string preOrder()
        {
            return preOrdera(root);
        }
        private string preOrdera(RBNode<T> root)
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
        private RBNode<T> deleteMin(RBNode<T> h)
        {
            if (h.left == null)
                return null;

            if (!isRed(h.left) && !isRed(h.left.left))
                h = moveRedLeft(h);

            h.left = deleteMin(h.left);
            return balance(h);
        }
        public RBNode<T> delete(T v)
        {
            return delete(root, v);
        }
        private RBNode<T> delete(RBNode<T> root, T v)
        {
            // assert get(h, key) != null;

            if (v.CompareTo(root.value) < 0)
            {
                if (!isRed(root.left) && !isRed(root.left.left))
                    root = moveRedLeft(root);
                root.left = delete(root.left, v);
            }
            else
            {
                if (isRed(root.left))
                    root = RightRotate(root);
                if (v.CompareTo(root.value) == 0 && (root.right == null))
                    return null;
                if (!isRed(root.right) && !isRed(root.right.left))
                    root = moveRedRight(root);
                if (v.CompareTo(root.value) == 0)
                {
                    RBNode<T> x = min(root.right);
                    root.value = x.value;
                    //root.val = x.val;
                    // h.val = get(h.right, min(h.right).key);
                    // h.key = min(h.right).key;
                    root.right = deleteMin(root.right);
                }
                else root.right = delete(root.right, v);
            }
            return balance(root);
        }
    }
}
