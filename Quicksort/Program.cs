using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Linq;
using System.Text;

namespace Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                
                //List<int> numbers = new List<int>(); 
                

                Random rnd = new Random();
                int tal = 1000; 


                int[] arr = new int[tal];
                for (int i = 0; i < tal; i++) {
                    arr[i] = rnd.Next(1, tal);
                }

                Quick_Sort(arr, 0, arr.Length-1);


                foreach (int a in arr){
                Console.Write(a + " ");
                }



            stopWatch.Stop();

            Console.WriteLine("");
            Console.WriteLine("Det tog " + stopWatch.ElapsedMilliseconds + " Millisekunder");

        }





        private static void Quick_Sort(int[] arr, int left, int right) 
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1) {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right) {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }
        
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true) 
            {

                while (arr[left] < pivot) 
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;


                }
                else 
                {
                    return right;
                }
            }
        }
    }
}