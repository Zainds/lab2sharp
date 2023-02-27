using System;
using System.Collections;

namespace task2
{
    internal class Program
    {
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
                
            for (int i = 0; i < arr2.GetLength(0); i++) {
                for (int j = 0; j < arr2.GetLength(1)-i-1; j++) {
                    int sumArr1 = 0;
                    int sumArr2 = 0;

                    for(int a = 0; a < arr2.GetLength(1); a++) {
                        sumArr1 += arr2[j, a];
                    }

                    for(int b = 0; b < arr2.GetLength(1); b++) {
                        sumArr2 += arr2[j+1, b];
                    }

                    if (sumArr1 < sumArr2) {
                        
                        int temp = arr2[j];
                        arr2[j] = arr2[j+1];
                        arr2[j+1] = temp;
                    }
                }
            }
            
            for (int i = 0; i < arr2.GetLength(0); i++) // Array Sorting
            {
                for (int j = arr2.GetLength(1) - 1; j > 0; j--)
                {

                    for (int z = 0; z < j; z++)
                    {
                        if (arr2[i, z] > arr2[i, z + 1])
                        {
                            int temp = arr2[i, z];
                            arr2[i, z] = arr2[i, z + 1];
                            arr2[i, z + 1] = temp;
                        }
                    }
                }
                Console.WriteLine();
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