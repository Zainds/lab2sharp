using System;

namespace lab2sharp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int n = 6;
            int min_ind = 0;
            double sr = 0; int k = 0;
            int[] arr = new int[n];
            Console.WriteLine("Enter day temperature");
            
            for (int i = 0; i < n; i ++)
            {
                arr[i] = Int32.Parse(Console.ReadLine());
                if (arr[i] < arr[min_ind]){
                    min_ind = i;
                }
            }

            for (int i = 0; i< min_ind; i++){
                sr += arr[i];
                k++;
            }
            Console.WriteLine(sr/k);
        }
    }
}