using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        
        // Prints all subarrays in arr[0..n-1]
        static void subArray(int n, int a)
        {
            

            int curr_sum;
            // Pick starting point
            for (int i = 0; i < n; i++)
            {
                curr_sum = arr[i];
                // Pick ending point
                for (int j = i; j < n; j++)
                {

                    // Print subarray between current 
                    // starting and ending points
                   for (int k = i; k <= j; k++)
                      if (curr_sum < a)
                        {
                            Console.Write(arr[k] + " ");
                        }
                            
                    if (curr_sum > a || curr_sum == a)
                        break;
                    curr_sum += arr[j];
                        
                        
                    Console.WriteLine("");
                }
            }
        }

        // Driver Code
        public static void Main()
        {
            Console.Write("Input number: ");
            int a =  Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("All Non-empty Subarrays");
            subArray(arr.Length, a);

            Console.ReadKey();
        }
    }

}
