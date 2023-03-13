using System;
using System.Collections;
using System.Linq;

namespace task2
{
    
    internal class Program
    {
        
        public static void mysw(int[,] a, int indexOne, int indexTwo)
        {
            if (a == null){ throw new ArgumentNullException("a"); } 
            if (a.Rank != 2) { throw new InvalidOperationException("..."); }

            
            if (a.GetLowerBound(0) != 0) { throw new InvalidOperationException("..."); }
            if (a.GetLowerBound(1) != 0) { throw new InvalidOperationException("..."); }

            if (indexOne >= a.GetUpperBound(0)) { throw new InvalidOperationException("ss"); }
            if (indexTwo >= a.GetUpperBound(0)) { throw new InvalidOperationException(".sss"); }

            for (int i = 0; i <= a.GetUpperBound(1); ++i) {
                var t = a[indexOne, i];
                a[indexOne, i] = a[indexTwo, i];
                a[indexTwo, i] = t;
            }
            
        }
        public static void delete0rows(int[,] arr, int n, int k){
            int rows = 0;
            for (int i = 0; i<n; i++){
                int multilp = 1;
                for (int j = 0; j<k; j++){
                    multilp *= arr[i, j];
                }
                if (multilp != 0) rows +=1;
            }
            var arr2 = new int[rows, k];
            int rowback = 0;
            for (int i = 0; i<n; i++){
                int multilp = 1;
                for (int j = 0; j<k; j++){
                    multilp *= arr[i, j];
                }
                if (multilp != 0){
                    for (int j = 0; j<k; j++){
                        arr2[i + rowback, j] = arr[i, j];
                    }
                }
                else rowback -=1;
            }
            
            for (int i = 0; i < arr2.GetLength(0)-2; i++)
            {
                int summ1 = 0;
                int summ2 = 0;
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    summ1 += arr2[i, j];
                    summ2 += arr2[i + 1, j];

                }

                if (summ1 > summ2) {
                    mysw(arr2, i, i + 1);
                }
                
            }
            
            

            
            
            
            for (int i = 0; i < rows; i++){
                for (int j = 0; j < k; j++){
                    Console.Write("   " + arr2[i, j]);
                }
                Console.WriteLine();
            }


        }
        
        public static void Main(string[] args)
        {
            int n, k;
            Random rnd = new Random();
            n = Int32.Parse(Console.ReadLine());
            k = Int32.Parse(Console.ReadLine()); 
            var arr = new int[n, k]; 
            var arr2 = new int[n, k]; 
            for (int i = 0; i< n; i++){ 
                int flag = 1; 
                for (int j = 0; j< k; j++){ 
                    arr[i, j] = rnd.Next(3, 5+1); 
                    Console.Write("   " + arr[i, j]); 
                    if (arr[i, j]<4)flag = 0;
                } 
                Console.WriteLine(); 
                if (flag == 1){ 
                    for (int j = 0; j< k; j++) { 
                        arr2[i, j] = arr[i, j];
                    }
                }
            }
            Console.WriteLine();
            delete0rows(arr2, n, k);
            
        }
    }
    
}