using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Recorsia
{
    public class RecEx1
    {
        public static int Cacatua(int a, int b)
        {
            if (a < b)
                return (0);
            else
                return (1 + Cacatua(a - b, b));
        }
        public static int Crow(int a, int b)
        {
            if (b == 0)
                return 0;
            if (b % 2 == 0)
                return Crow(a + a, b / 2);
            return Crow(a + a, b / 2) + a;
        }

        public static int SumArr(int[] arr, int i)
        {
            if(i == 0)
            {
                return arr[0];
            }
            return SumArr(arr, i - 1) + arr[i];
        }

        public static int GetMax(int[] arr, int i)
        {
            if (i == 0)
            {
                return arr[0];
            }
            int m = GetMax(arr, i - 1);
            return Math.Max(m, arr[i]);
        }

        public static bool BinarySearchRecursive(int[] array, int numberToFind, int left, int right)
        {
            // Base case: If the search space is invalid (left > right), the number is not found
            if (left > right)
                return false;

            // Find the middle index
            int mid = left + (right - left) / 2;

            // Check if the middle element is the target number
            if (array[mid] == numberToFind)
                return true;

            // If the target is smaller than the middle element, search the left half
            if (numberToFind < array[mid])
                return BinarySearchRecursive(array, numberToFind, left, mid - 1);

            // Otherwise, search the right half
            return BinarySearchRecursive(array, numberToFind, mid + 1, right);
        }

        public static bool IsPalindrome(int[] array)
        {
            return IsPalindromeRecursive(array, 0, array.Length - 1);
        }

        // Recursive helper function
        private static bool IsPalindromeRecursive(int[] array, int left, int right)
        {
            // Base case: If the indices cross, the array is a palindrome
            if (left >= right)
                return true;

            // Check if the elements at the current indices are equal
            if (array[left] != array[right])
                return false;

            // Recursive case: Check the next pair of elements
            return IsPalindromeRecursive(array, left + 1, right - 1);
        }
    }
    public class RunRecEx1
    {
        public static void DemoMain()
        {
            int[] arr = { 1, 2, 3, 4, 5,7,20};
            int target = 17;

            bool found = RecEx1.BinarySearchRecursive(arr, target, 0, arr.Length - 1);
            Console.WriteLine($"Is {target} found in the array? {found}");
            Console.WriteLine(RecEx1.Crow(5,6));
            Console.WriteLine(RecEx1.SumArr(arr, 3));
            Console.WriteLine(RecEx1.GetMax(arr, 3));

            int[] numbers = { 1, 2, 3, 2, 1 };
            bool isPalindrome = RecEx1.IsPalindrome(numbers);
            Console.WriteLine($"Is the array a palindrome? {isPalindrome}");
        }
    }
}
