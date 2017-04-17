using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics.PerformanceData;
using System.Diagnostics;

namespace Sorting_Algorithms
{
    class Program
    {
        Stopwatch sw;   
        //Start of Insertion Sort
        public void insertionSort(int[] arr)
        {
            sw = Stopwatch.StartNew();
            int num = arr.Length;

            for(int i =0; i<num; i++)
            {
                int j = i - 1;
                int key = arr[i];

                while(j>= 0 && key < arr[j])
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
                sw.Stop();
                Console.WriteLine("Insertion Sort Result: %1 \n %2\n", arr, sw.Elapsed);
            }
        }

        //Start of Selection Sort
        public void selectionSort(int[] arr)
        {
            sw = Stopwatch.StartNew();
            int min, temp;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                        min = j;
                }

                if (min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
            }
            sw.Stop();
            Console.WriteLine("Selection Sort Result: %1 \n %2 \n", arr,sw.Elapsed);
        }

        //Start of Bubble Sort
        public void bubbleSort(int[] arr)
        {
            sw = Stopwatch.StartNew();
            int temp = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j<arr.Length; j++)
                {
                    if(arr[i] < arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            sw.Stop();
            Console.WriteLine("Bubble Sort Result: %1 \n %2\n ", arr, sw.Elapsed);
        }

        //Start of MergeSort
        public void merging( int[] arr, int left, int middle, int right)
        {
            int[] holder = new int[30];
            int endLeft, num, holderPos;

            endLeft = (middle - 1);
            holderPos = left;
            num = (right - left + 1);

            while((left <= endLeft) && (middle <= right))
            {
                if (arr[left] <= arr[middle])
                    holder[holderPos++] = arr[left++];
                else
                    holder[holderPos++] = arr[middle++];
            }

            while(left <= endLeft)
            {
                holder[holderPos++] = arr[left++];
            }
            while (middle <= right)
            {
                holder[holderPos++] = arr[middle++];
            }

            for(int i =0; i< num; i++)
            {
                arr[right] = holder[right];
                right--;
            }
        }

        public void MergeSort( int [] arr, int left, int right)
        {
            sw = Stopwatch.StartNew();
            int middle;
            if(right>left)
            {
                middle = (right + left) / 2;
                MergeSort(arr, left, middle);
                MergeSort(arr, (middle + 1), right);

                merging(arr, left, (middle + 1), right); 
            }
            sw.Stop();
            Console.WriteLine("Mergsort Result: %1 \n %2 \n", arr, sw.Elapsed);
        }

        // Start of Quicksort
        public int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];

            while(true)
            {
                while(arr[right]> pivot)
                {
                    right++;
                }
                while (arr[left] > pivot)
                {
                    left++;
                }
                if(left<right)
                {
                    int holder = arr[right];
                    arr[right] = arr[left];
                    arr[left] = holder;
                }
                else
                {
                    return right;
                }
            }
        }

        public void QuickSort(int[] arr, int left, int right)
        {
            sw = Stopwatch.StartNew();
            if (left< right)
            {
                int pivot = Partition(arr, left, right);

                if(pivot>1)
                {
                    QuickSort(arr, left, pivot - 1);
                }
                if(pivot+1 < right)
                {
                    QuickSort(arr, pivot + 1, right);
                }
            }
            sw.Stop();
            Console.WriteLine("QuickSort Result: %1 \n %2 \n", arr, sw.Elapsed);
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] testArray = new int[100];
            for(int i = 0; i<testArray.Length; i++)
            {
                testArray[i] = rand.Next(10);
            }




        }
    }
}
