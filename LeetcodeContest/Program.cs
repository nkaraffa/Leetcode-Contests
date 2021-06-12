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
            //int[] num1 = new int[] { 1, 2 };
            //int[] num2 = new int[] { 2, 3 };
            //Console.WriteLine(MinimumXORSum(num1, num2));
            #endregion

            #endregion

            #region Biweekly Contest 54
            // https://leetcode.com/contest/biweekly-contest-54/

            #region IsCovered
            // Determine if all values in range are in 2D array
            //int[,] ranges = new int[,] { { 1, 2 },{ 3, 4 },{ 5, 6 } };
            //int[][] range = new int[3][] { 
            //    new int[] { 1, 2 }, 
            //    new int[] { 3, 4 }, 
            //    new int[] { 5, 6 } 
            //};
            //Console.WriteLine(IsCovered(range, 2, 5));
            #endregion

            #region ChalkReplacer
            // Determine which student will replace the chalk
            //int[] chalk = new int[] { 3, 4, 1, 2};
            //Console.WriteLine(ChalkReplacer(chalk, 25));
            #endregion

            #region LargestMagicSquare
            // Determine size of largest 'magic square'
            //int[][] grid = new int[3][] { 
            //    new int[] { 7,1,4,5,6}, 
            //    new int[] {2,5,1,6,4}, 
            //    new int[] {1,5,4,3,2},
            //    new int[] {1,2,7,3,4}
            //};
            //Console.WriteLine(LargestMagicSquare(grid));
            #endregion

            #region MinOperationsToFlip
            // Determine how many operators need to be changed to change the value of the string
            //string expression = "1&(0|1)"
            //Console.WriteLine(MinOperationsToFlip(expression));
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

        #region Biweekly Contest 54
        //Complete
        public static bool IsCovered(int[][] ranges, int left, int right)
        {
            Console.WriteLine(ranges[0][0]);
            Console.WriteLine(ranges.Length);
            Console.WriteLine(ranges.Rank);
            int len = (ranges.Length / ranges.Rank);

            List<int> check = new List<int>();
            for (int i = left; i <= right; i++)
            {
                check.Add(i);
            }

            int index1 = 0;
            int index2 = 0;
            while (index1 < len)
            {
                int range1 = ranges[index1][index2];

                index2++;
                int range2 = ranges[index1][index2];
                if (check.Contains(range1))
                {
                    check.Remove(range1);
                } else if (check.Contains(range2))
                {
                    check.Remove(range2);
                }

                for(int j=range1; j<=range2; j++)
                {
                    if(check.Contains(j))
                    {
                        check.Remove(j);
                    }
                }

                if(index1 < len)
                {
                    index1++;
                    index2 = 0;
                }
            }
            if(check.Count == 0)
            {
                return true;
            }
            return false;
        }

        //Complete
        public static int ChalkReplacer(int[] chalk, int k)
        {
            int n = chalk.Length;       // # of students
            int cIndex = 0;             // Current student and chalk usage
            long sum = 0;
            foreach(int i in chalk)
            {
                sum += i;
            }
            long kLeft = (long)k % (long)sum;       // Sum chalk on-hand and determine how much extra is needed.

            while (0 <= kLeft)
            {
                if (kLeft < chalk[cIndex])      //If chalk uasge is greater than chalk then end
                {
                    return cIndex;          //Student that will replace chalk
                }
                kLeft -= chalk[cIndex];      //Decrement chalk
                cIndex++;
                if (cIndex >= n)         //Determine how much chalk to use; If chalk limit reached, revert to 0 index
                {
                    cIndex = 0;
                }
            }
            
            return 0;
        }

        //In-Progress
        public static int LargestMagicSquare(int[][] grid)
        {
            return 0;
        }

        //In-Progress
        public static int MinOperationsToFlip(string expression)
        {
            return 0;
        }
        #endregion
    }
}
