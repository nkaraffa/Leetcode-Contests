using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeContest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Biweekly Contest 53
            #region CountGoodSubstrings
            //Console.WriteLine(CountGoodSubstrings("xyzzaz"));
            #endregion

            #region MinPairSum
            //int[] nums = new int[] { 3, 5, 2, 3 };
            //Console.WriteLine(MinPairSum(nums));
            #endregion

            #region GetBiggestThree
            //int[,][] grid = new int[3, 3][];
            //Console.WriteLine(GetBiggestThree(grid));
            #endregion

            #region MinimumXORSum
            int[] num1 = new int[] { 1, 2 };
            int[] num2 = new int[] { 2, 3 };
            Console.WriteLine(MinimumXORSum(num1, num2));
            #endregion

            #endregion
        }

        #region Biweekly Contest 53
        // Complete
        public static int CountGoodSubstrings(string s)
        {
            // Good substring consists of unique chars with length=3
            // Plan: Pull a substring of length 3 and examine for Distinct() chars

            List<string> count = new List<string>();    //Not necessary, but I wanted to inspect substrings
            for (int i = 0; i < s.Length; i++)
            {
                if (i + 2 < s.Length)   // Check to make sure we don't go out-of-bounds
                {
                    string y = s.Substring(i, 3);       //Used to inspect substring
                    if (s.Substring(i, 3).Distinct().Count() == 3)      //Checks for 3 unique chars within substring
                    {
                        count.Add(s.Substring(i, 3));   
                    }
                    y = null;
                }
            }

            return count.Count();   //return number of unique substrings
        }
        // Complete
        public static int MinPairSum(int[] nums)
        {
            // Minimize the maximum sum of numbers
            // Plan: Sort given array, then sum values from both side of array

            Array.Sort(nums);                       //Sort array
            int[] ans = new int[nums.Length / 2];   //Create array of size Length/2
            int len = nums.Length - 1;              //Index counter for back of array
            for(int i=0; i<(nums.Length /2); i++)
            {
                ans[i] = nums[i] + nums[len];       //Add first and last value of array
                len--;                              //Decrement index counter
            }

            return ans.Max();                       //Return max sum value
        }
        // In-Progress
        public static int[] GetBiggestThree(int[][] grid)
        {
            // Given a multidimensional grid, determine multiple rhombus area sums
            // Plan: 

            int[] ans = new int[4];     //Placeholder
            return ans;
        }
        // In-Progress
        public static int MinimumXORSum(int[] nums1, int[] nums2)
        {
            // Find the minumum XOR sum value between two arrays
            // Plan: Sort array2, then reverse. Access the index of both arrays and perform XOR logic

            int ans = 0;
            Array.Sort(nums2);              //Sorting array 2
            Array.Reverse(nums2);

            int len2 = nums2.Length-1;
            for(int i=0; i<nums1.Length; i++)
            {
                ans = ans + (nums1[i] ^ nums2[len2]);       //Performing XOR logic
                len2--;
            }
            
            return ans;     //Return min XOR sum
        }

        #endregion
    }
}
