using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign3_2
{
    class HashTable
    {
        class HashArray
        {
            public int key;
            public string value;
            //constructor
            public HashArray(int key, string value)
            {
                this.key = key;
                this.value = value;
            }
            //get method
            public int getkey()
            {
                return key;
            }
            //get method
            public string getvalue()
            {
                return value;
            }
        }
        //our hash size
        int maxSize = 50; 
        HashArray[] hash;
        //creates empty hashtable
        public HashTable()
        {
            hash = new HashArray[maxSize];
            for (int i = 0; i < maxSize; i++)
            {
                hash[i] = null;
            }
        }
        //Search method to find value in table
        public void findValue(string value)
        {
            for (int i = 1; i <= hash.Length; i++)
            {
                 try
                 {
                     if (hash[i].getvalue().Contains(value) && hash[i] != null && i <= maxSize)//if we have null entries
                          Console.WriteLine("Key: " + hash[i].getkey() + "  String: " + hash[i].getvalue() 
                              + "  Length of value: " + hash[i].getvalue().Length + "\n");
                     else
                          continue;             
                 }
                 catch { } //throws null exception. 

            }
        }
        //checks for open spaces in the hash for insertion
        private bool checkOpenSpace()
        {
            bool isOpen = false;
            for (int i = 0; i < maxSize; i++)
            {
                if ( hash[i] == null)
                {
                    isOpen = true;
                }
            }
            return isOpen;
        }
        public void print()
        {
            for (int i = 0; i < hash.Length; i++)
            {
                 if (hash[i] == null && i <= maxSize)//if we have null entries
                     continue;// continue the looping, skips the null
                 else                
                     Console.WriteLine("Key: " + hash[i].getkey() + "  String: " + hash[i].getvalue() 
                         + "  Length of value: " + hash[i].getvalue().Length);
            }
        }
        //quadratic probing method
        //inserts into the table 
        public void quadraticHashInsert(int key, string value)
        {

           
            if (!checkOpenSpace())//if no open spaces available
            {
                Console.WriteLine("Table is full");
                return;
            }

            int j;
            int index = key % maxSize;
            for (j = 0; j > maxSize && hash[index] != null && hash[index].getkey() != key; j++)
            {
               index = (index + j * j) % maxSize;
            }
            
            if (hash[index] == null)
            {
                hash[index] = new HashArray(key, value);
                return;
            }
        }
    }
}
