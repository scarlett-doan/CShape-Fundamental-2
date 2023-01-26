#pragma warning disable

using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        //Challenge 1
        int[][] arr1 =
        {
            new int[] { 1, 2, 2, 5, 3},
            new int[] {3, 2, 1, 1, 5, 4 },
            new int[] {2, 3, 5}
        };
        int[] arr1Common = CommonItems(arr1);
        var commonResult = string.Join(",", arr1Common);
        WriteLine($"\n#1 - The common elements of given jagged array: [{commonResult}]\n");
        /* Expected result: 2, 5, 3 */

        //Challenge 2
        int[][] arr2 = 
        { 
            new int[] { 1, 2, 3, 4}, 
            new int[] { 2, 4, 6, 8, 10 } 
        };
        InverseJagged(arr2);
        WriteLine("#2 - Inverse the elements of a jagged array");
        foreach (var arr in arr2)
        {
            string inverseOutput = string.Join(",", arr);
            WriteLine($"{{{inverseOutput}}}");
        }
        WriteLine();
        /* Expected result:
        {4,3,2,1}
        {5,4,3,2,1}
        */
        
        //Challenge 3
        int[][] arr3 =
        {
            new int[] { 1, 2, 4, 3, 0 }, 
            new int[] { 1, 2, 3, 6, 9, -15 }
        };
        WriteLine("#3 - Find the difference between 2 consecutive elements of an array");
        CalculateDiff(arr3);
        WriteLine();
        /* Expected result:
        {-1,-2,1,3}
        {-1,-1,-3,-3,24}
        */

        //Challenge 4
        int[,] arr4 =
        {
            { 1, 2, 3, 4 }, 
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12}
        };
        WriteLine("#4 - Inverse column/row of a rectangular array");
        int[,] arr4Inverse = InverseRec(arr4);
        for (int i = 0; i < arr4Inverse.GetLength(0); i++)
        {
            int[] result = Array.Empty<int>();
            for (int j = 0; j < arr4Inverse.GetLength(1); j++)
            {
                result = result.Append(arr4Inverse[i, j]).ToArray();
            }
            WriteLine("{" + string.Join(", ", result) + "}");
        }
        WriteLine();
        
        /* Expected result:
            {1, 5, 9}
            {2, 6, 10}
            {3, 7, 11}
            {4, 8, 12}
         */

        // //Challenge 5
        // Demo("hello", 1, 2, "world");
        //
        // //Challenge 6
        //
        // //Challenge 7
        // string firstName, middleName, lastName;
        // ParseNames("Mary Elizabeth Smith", firstName, middleName, lastName);
        // Console.WriteLine($"First name: {firstName}, middle name: {middleName}, last name: {lastName}");
        //
        // //Challenge 8
        // GuessingGame();
    }

    /*
    Challenge 1. Given a jagged array of integers (two dimensions).
    Find the common elements in the nested arrays.
    Example: int[][] arr = { new int[] {1, 2}, new int[] {2, 1, 5}}
    Expected result: int[] {1,2} since 1 and 2 are both available in sub arrays.
    */
    static int[] CommonItems(int[][] jaggedArray)
    {
        HashSet<int> allItems = new HashSet<int>();
        // Use HashSet to store all of the UNIQUE items of jagged array

        foreach (int[] arr in jaggedArray)
        {
            foreach (int item in arr)
            {
                allItems.Add(item);
            }
        }

        HashSet<int> commonItems = new HashSet<int>();
        foreach (int item in allItems)
        {
            int commonCount = 0;
            foreach (int[] arr in jaggedArray)
            {
                if (arr.Contains(item))
                {
                    commonCount += 1;
                }
            }

            if (commonCount == jaggedArray.Length)
            {
                commonItems.Add(item);
            }
        }
        return commonItems.ToArray();
    }

     /* 
     Challenge 2. Inverse the elements of a jagged array.
     For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
     Expected result: int[][] arr = {new int[]{2, 1}, new int[]{3, 2, 1}}
      */
     static void InverseJagged(int[][] jaggedArray)
     {
         foreach (var arr in jaggedArray)
         {
             for (int i = 0; i < (arr.Length/2); i++)
             {
                 int tmp = arr[i];
                 arr[i] = arr[arr.Length - i - 1];
                 arr[arr.Length - i - 1] = tmp;
             }
         }
     }

     /* 
     Challenge 3.Find the difference between 2 consecutive elements of an array.
     For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
     Expected result: int[][] arr = {new int[] {-1}, new int[]{-1, -1}}
      */
     static void CalculateDiff(int[][] jaggedArray)
     {
         foreach (var arr in jaggedArray)
         {
             int[] diffArr = Array.Empty<int>();
             int diff = 0;
             
             for(int i = 0; i < (arr.Length)-1; i++)
             {
                 diff = arr[i] - arr[i + 1];
                 diffArr = diffArr.Append(diff).ToArray();
             }
             
             var diffResult = string.Join(",", diffArr);
             WriteLine($"{{{diffResult}}}");
         }
     }

     /* 
     Challenge 4. Inverse column/row of a rectangular array.
     For example, given: int[,] arr = {{1,2,3}, {4,5,6}}
     Expected result: {{1,2},{3,4},{5,6}}
      */
     static int[,] InverseRec(int[,] recArray)
     {
         int recArrayRow = recArray.GetLength(0);
         int recArrayCol = recArray.GetLength(1);
         int[,] newRecArray = new int[recArrayCol, recArrayRow];
         
         if (recArrayRow == recArrayCol)
         {
             newRecArray = (int[,])recArray.Clone();
             
             for (int i = 1; i < recArrayRow; i++)
             {
                 for (int j = 0; j < i; j++)
                 {
                     int tmp = newRecArray[i,j];
                     newRecArray[i,j] = newRecArray[j,i];
                     newRecArray[j,i] = tmp;
                 }
             }
         }
         else
         {
             for (int col = 0; col < recArrayCol; col++)
             {
                 for (int row = 0; row < recArrayRow; row++)
                 {
                     newRecArray[col, row] = recArray[row, col];
                 }
             }
         }
         return newRecArray;
     }
//
//     /* 
//     Challenge 5. Write a function that accepts a variable number of params of any of these types: 
//     string, number. 
//     - For strings, join them in a sentence. 
//     - For numbers then sum them up. 
//     - Finally print everything out. 
//     Example: Demo("hello", 1, 2, "world") 
//     Expected result: hello world; 3 */
//     static void Demo()
//     {
//
//     }
//
//     /* Challenge 6. Write a function to swap 2 objects but only if they are of the same type 
//     and if they’re string, lengths have to be more than 5. 
//     If they’re numbers, they have to be more than 18. */
//     static void SwapTwo()
//     {
//
//     }
//
//     /* Challenge 7. Write a function to parse the first name, middle name, last name given a string. 
//     The names will be returned by using out modifier */
//     static void ParseNames(
//         string input,
//         out string firstName,
//         out string middleName,
//         out string lastName)
//     {
//
//     }
//
//     /* Challenge 8. Write a function that does the guessing game. 
//     The function will think of a random integer number (lets say within 100) 
//     and ask the user to input a guess. 
//     It’ll repeat the asking until the user puts the correct answer. */
//     static void GuessingGame()
//     {
//
//     }
}
