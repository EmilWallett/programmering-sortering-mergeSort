using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Linq;
using System.Text;

namespace mergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                
                List<int> unsorted = new List<int>();
                List<int> sorted = new List<int>(); 

                Random rnd = new Random();
                int tal = 8000;

                for(int i= 0; i < tal; i++)
                    unsorted.Add(rnd.Next(1, tal));

                sorted = MergeSort(unsorted);


            foreach (int a in sorted){
                Console.Write(a + " ");
            }

            stopWatch.Stop();

            Console.WriteLine();
            Console.WriteLine("Det tog " + stopWatch.ElapsedMilliseconds + " Millisekunder");
        }





        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle;i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while(left.Count > 0 || right.Count>0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if(left.Count>0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());    
                }    
            }
            return result;
        }


    }
}
