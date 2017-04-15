﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms
{
    class Program
    {
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

        static void Main(string[] args)
        {
        }
    }
}
