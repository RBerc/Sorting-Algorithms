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
          
        //Start of Insertion Sort
        public static void insertionSort(int[] arr)
        {

            for(int i  = 0; i < arr.Length; i++)
            {
                int j = i - 1;
                int key = arr[i];

                while(j >= 0 && key < arr[j])
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        //Start of Selection Sort
        public static void selectionSort(int[] arr)
        {
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
        }

        //Start of Bubble Sort
        public static void bubbleSort(int[] arr)
        {
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
        }

        //Start of MergeSort
        public static void merging( int[] arr, int left, int middle, int right)
        {
            int[] holder = new int[1000];
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

        public static void MergeSort( int [] arr, int left, int right)
        {
            int middle;
            if(right>left)
            {
                middle = (right + left) / 2;
                MergeSort(arr, left, middle);
                MergeSort(arr, (middle + 1), right);

                merging(arr, left, (middle + 1), right); 
            }
        }

        // Start of Quicksort
        public static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];

            while(true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                }
                if(arr[right] == pivot && arr[left]==pivot)
                {
                    left++;
                }
                if (left<right)
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

        public static void QuickSort(int[] arr, int left, int right)
        {
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
        }

        static void Main(string[] args)
        {
            string results = "";
            Stopwatch swBubble, swQuick,swMerge,swInsertion,swSelection;

            //Make Random Array of Ints from 1-100 
            Random rand = new Random();
            int[] testArray = new int[1000];
            for(int i = 0; i<testArray.Length; i++)
            {
                testArray[i] = rand.Next(1,100);
            }
            Console.WriteLine(string.Format("Original Array: {0} \n\n", string.Join(",",testArray)));
            
            //BubbleSort Test
            swBubble = Stopwatch.StartNew();
            bubbleSort(testArray);
            swBubble.Stop();
            results += string.Format("Bubble Sort Result: {0} \n  Elapsed Time: {1} \n\n", string.Join(",",testArray), swBubble.Elapsed);
            
            // InsertionSort Test
            swInsertion = Stopwatch.StartNew();
            insertionSort(testArray);
            swInsertion.Stop();
            results += string.Format("Insertion Sort Result: {0} \n  Elapsed Time: {1} \n\n", string.Join(",", testArray), swInsertion.Elapsed);
            
            // Selection Sort Test
            swSelection = Stopwatch.StartNew();
            selectionSort(testArray);
            swSelection.Stop();
            results += string.Format("Selection Sort Result: {0} \n  Elapsed Time: {1} \n\n", string.Join(",", testArray), swSelection.Elapsed);
            
            //Merge Sort Test
            swMerge = Stopwatch.StartNew();
            MergeSort(testArray, 0, testArray.Length - 1);
            swMerge.Stop();
            results += string.Format("Merge Sort Result: {0} \n  Elapsed Time: {1} \n\n", string.Join(",", testArray), swMerge.Elapsed);
            // Quicksort Test
            swQuick = Stopwatch.StartNew();
            QuickSort(testArray, 0, testArray.Length - 1);
            swQuick.Stop();
            results += string.Format("Quick Sort Result: {0} \n  Elapsed Time: {1} \n", string.Join(",", testArray), swQuick.Elapsed);
            
            // Print Results
            Console.WriteLine(results);
            Console.ReadKey();

        }
    }
}
