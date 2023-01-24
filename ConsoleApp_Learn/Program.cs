using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp_Learn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int a = 123;
            var ab = a.ToString().Trim();


            GetProductofTwoArrayElement();


            //Call for Ingheritance class.

            BC b;
            b = new BC();
            b.Display();

            b = new DC();
            b.Display();

            b = new TC();
            b.Display();


            //new mthod call.

            //StringManupulations stringManupulations = new StringManupulations();

            //string url = "(contains(Name, '1012536'))";
            //stringManupulations.urlcorrection(url,"1012536");

            int[] arr1 = { 134, 1053, 1024 };
            int n = arr1.Length;

            var avg = ReturnArrayAverage(arr1, n);


            List<int> max_heap = new List<int>();

            // Stores the maximum profit
            int maxProfit = 0;
            int[] arr = new int[10];
            // Traverse the array and push
            // all the elements in max_heap
            for (int j = 0; j < 10; j++)
                max_heap.Add(arr[j]);

            max_heap.Sort();
            max_heap.Reverse();

            //IISService service = new IISService();
            //bool check = IISService.IsServiceRunning("W3SVC");

            //var result = service.IsApplicationPoolRunning("L510298", "MAIN.4252-P21 SOA");
            bool check = StringAnagram();


            string[] s = { "123", "23", "45", "67", "12" };
            //int[] max = s.Select(x => int.Parse(x)).ToArray();
            int[] max = new int[s.Length];

            int i = 0;
            foreach (var item in s)
            {
                max[i] = int.Parse(item);
                i++;
            }
            //reversing the string
            string x = "anand";
            char[] z = x.ToCharArray();
            string y = null;
            for (i = z.Length - 1; i >= 0; i--)
            {
                y = y + z[i];
                // y.Insert(i,z[i].ToString());
            }

            bool pal = y.Equals(x);
            // check the pallindrom the string. 
            for (int j = 0; j < x.Length / 2; j++)
            {
                if (x[j] != x[x.Length - 1])
                    pal = false;

                pal = true;
            }

            Stack<string> xyx = new Stack<string>();
            string card = "abc";
            string card2 = "abc";

            xyx.Push(card);
            xyx.Push(card2);


            Console.ReadLine();

        }

        public static bool StringAnagram()
        {
            string str1 = "abcanand";
            string str2 = "abc";
            //checking the string anagram using disctionary method.
            char[] arr = str1.ToCharArray();
            Array.Sort(arr);
            str1 = string.Empty;
            str1 = string.Concat(arr);
            //str1 = arr.

            // Compare sorted strings
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    return false;
                }
            }


            string a = "anand";

            Dictionary<char, int> dicA = new Dictionary<char, int>();
            foreach (char c in a)
            {
                dicA.TryGetValue(c, out int count);
                dicA[c] = count + 1;
            }

            string b = "anand";

            Dictionary<char, int> dicB = new Dictionary<char, int>();
            foreach (char c in a)
            {
                dicB.TryGetValue(c, out int count);
                dicB[c] = count + 1;
            }

            if (dicA.Count == dicB.Count)
            {
                foreach (var x in dicA)
                {
                    int value;
                    if (dicB.TryGetValue(x.Key, out value))
                    {
                        if (value != x.Value)
                        {
                            break;

                        }
                        else
                        {
                            return true;
                        }
                    }

                }
            }

            return true;
        }

        public static int ReturnArrayAverage(int[] arr, int n)
        {
            int dev;
            int count = 0;
            int sum = 0, avg;
            // let's find and remove all the square which aee deiided by 2. 
            for (int i = 0; i < n; i++)
            {
                dev = arr[i];
                while (dev > 0 && dev % 2 == 0)
                {
                    dev = (int)dev / 2;
                    if (dev == 1)
                    {
                        //we know that arr[i is a 2 square, we should remove thi s from aaaray]
                        arr[i] = 0;
                        count++;
                        break;
                    }

                }

                sum = sum + arr[i];
            }

            return avg = (int)sum / (n - count);
        }

        public static string GettheArrayElementCount(int[] arr, int n)
        {
            //int[] arr = { 1, 2, 3, 2, 4, 5, 2, 4 };

            var duplicates = arr.GroupBy(x => x)
                                .Where(g => g.Count() > 1)
                                .Select(y => new { Item = y.Key, Count = y.Count() })
                                 .ToList();

            var duplicates1 = arr.GroupBy(x => x)
                                .Where(g => g.Count() > 1)
                                .ToDictionary(x => x.Key, y => y.Count());

            Console.WriteLine(String.Join(", ", duplicates));

            Console.WriteLine(String.Join("\n", duplicates));
            foreach (var x in arr)
            {

            }
            return "a";
        }

        public static void GettheCommonElementinTwoArrays()
        {
                int[] array1 = { 1, 4, 2, 8, 7 };
                int[] array2 = { 7, 5, 9, 1, 0, 2, 6 };
        // Call Intersect extension method.  
                var intersect = array1.Intersect(array2);
    }


        public static void GetProductofTwoArrayElement()
        {
            // Find out if given number can be formed by multiplying any 2 elements from array

            // input {6,2,0,3,-1,2,5,4} and 8

            // output true or false

            // 8 = 2*4 - true

            // 9, one 3 - false

            // 12 = 6*2,3*4 - true

            int[] arr = { 6, 2, 0, 3, -1, 2, 5, 4 };
            int mul = 8;

            int number = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1; j < arr.Length; j++)
                {
                    if (i == j)
                        continue;
                    number = arr[i] * arr[j];
                    if (number == mul)
                    {
                        Console.WriteLine($"Cartesian product of {arr[i]} and {arr[j]} equals to {number} : True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                if (number != mul)
                    continue;
            }
        }



        /*
         * Complete the 'getEarliestMeetTime' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts following parameters:
         *  1. STRING_ARRAY events
         *  2. INTEGER k
         */

        //public static string getEarliestMeetTime(List<string> events, int k)
        //{
        //    //let's try to get all the meeting time in timespan format.

        //    var timespan = events
        //        var [] startTime
        //    foreach(var e in events)
        //    {
        //        startTime = e.Split(' ');
        //    }

        //    return "anand";


        //}

    }
}


