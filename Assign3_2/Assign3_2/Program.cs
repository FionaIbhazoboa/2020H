using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// This program allows one to enter strings into the hash table array 
//Print out all values of the array
//And efficiently search for a given string in the array
namespace Assign3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare int array key value
            int[] key = new int[50];
            //Declare string array value
            string[] value = new string[50]; 
            string a;
            // create instance of hashtable class
            HashTable hash = new HashTable();
            
            for (int n = 1; n <= 15; n++) 
            {
                key[n] = n;
                Console.Write(n + ". Enter the value: ");
                value[n] = Console.ReadLine();
                //calls insert method
                hash.quadraticHashInsert(key[n], value[n]); 
            }
            Console.WriteLine("String Values inputted: ");
            hash.print(); // Retrieve all records
            Console.WriteLine("===============================================================================");
            // For searching a string value
            Console.WriteLine("Enter one of the string values inputted : "); 
            a = Convert.ToString(Console.ReadLine());
            Console.WriteLine("===============================================================================");
            Console.WriteLine("String value data :");
            hash.findValue(a); 
            Console.ReadLine();

        }
    }
    
}
