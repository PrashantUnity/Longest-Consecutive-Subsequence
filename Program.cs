using System;
using System.Collections.Generic;
namespace Longest_Consecutive_Subsequence
{
    class Program
    {
        static void Main()
        {
            int[] arr = { 9, 89, 5, 6, 65,5,6,5,2,5,6,2,6,5,5,2,5,464,86,8,684,84,54,8468,44,64,48 ,67, 7 };
            var maxSub = Subseq(arr, arr.Length);
            Console.WriteLine(maxSub.Length);
            foreach (var item in maxSub)
            {
                Console.Write(item + " ");
            }
        }
        static int[] Subseq(int[] arr, int n)
        {
            Array.Sort(arr);
            
            // removing duplicate items from array

            var v = new List<int>
            {
                arr[0]
            };
            for (int i = 1; i < n; i++)
            {
                if (arr[i] != arr[i - 1])
                    v.Add(arr[i]);
            }

            // getting sub array
            var fin = new int[v.Count][];
            var tempList = new List<int>();
            var j = 0;
            for (int i = 0; i < v.Count; i++)
            {
                // adding first element if satisfy
                if (i == 0 && v[i] == v[i + 1] - 1)
                {
                    tempList.Add(v[i]);
                }
                else if (i > 0 && v[i] == v[i - 1] + 1)
                {
                    tempList.Add(v[i]);
                }
                // this will execute after continuous chain is breaked
                else if (i > 0 && v[i] != v[i - 1] + 1 && v[i] == v[i - 1] + 1 && i != v.Count - 1)
                {
                    tempList.Add(v[i]);
                }
                else
                {
                    fin[j] = new int[tempList.Count];
                    int m = 0;
                    foreach (var item in tempList)
                    {
                        fin[j][m++] = item;
                    }
                    tempList.Clear();
                    j++;
                }
            }

            // finding largest array in array
            var current = fin[0];
            for (var i = 0; i < j; i++)
            {
                if (fin[i].Length > current.Length)
                {
                    current = fin[i];
                }
            }
            return current;
        }
    }
    

}
