using System;

namespace FUNTEST
{
    internal class Program
    {   
        public static void mysw(int[,] a, int indexOne, int indexTwo)
        {
            if (a == null){ throw new ArgumentNullException("a"); } 
            if (a.Rank != 2) { throw new InvalidOperationException("..."); }

            // Only support zero based:
            if (a.GetLowerBound(0) != 0) { throw new InvalidOperationException("..."); }
            if (a.GetLowerBound(1) != 0) { throw new InvalidOperationException("..."); }

            if (indexOne >= a.GetUpperBound(0)) { throw new InvalidOperationException("..."); }
            if (indexTwo >= a.GetUpperBound(0)) { throw new InvalidOperationException("..."); }

            for (int i = 0; i <= a.GetUpperBound(1); ++i) {
                var t = a[indexOne, i];
                a[indexOne, i] = a[indexTwo, i];
                a[indexTwo, i] = t;
            }
            
        }
        
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            var arr = new int[4,4];
            for (int i = 0; i< 4; i++){ 
                int flag = 1; 
                for (int j = 0; j< 4; j++){ 
                    arr[i, j] = rnd.Next(3, 5+1); 
                    Console.Write("   " + arr[i, j]); 
                    if (arr[i, j]<4)flag = 0;
                } 
                Console.WriteLine(); 
                
            }
            mysw(arr, 1, 2);
            Console.WriteLine();
            for (int i = 0; i< 4; i++){
                for (int j = 0; j< 4; j++){
                    Console.Write("   " + arr[i, j]);
                } 
                Console.WriteLine(); 
                
            }
        }
        
    }
}

