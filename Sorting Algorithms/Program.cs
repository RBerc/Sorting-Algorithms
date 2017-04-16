using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms
{
    class Program
    {
        //Start of Insertion Sort
        public void insertionSort(int[] arr)
        {
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
                Console.WriteLine("Insertion Sort Result:", arr);
            }
        }

        //Start of Selection Sort
        public void selectionSort(int[] arr)
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
            Console.WriteLine("Selection Sort Result: ", arr);
        }

        //Start of Bubble Sort
        public void bubbleSort(int[] arr)
        {

            int temp = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j<arr.Length;, j++)
                {
                    if(arr[i] < arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            Console.WriteLine("Bubble Sort Result: ", arr);
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
            int middle;
            if(right>left)
            {
                middle = (right + left) / 2;
                MergeSort(arr, left, middle);
                MergeSort(arr, (middle + 1), right);

                merging(arr, left, (middle + 1), right); 
            }
            Console.WriteLine("Mergsort Result: ", arr);
        }


        static void Main(string[] args)
        {
        }
    }
}
