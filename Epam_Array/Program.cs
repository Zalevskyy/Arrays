using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add arrays
            Console.WriteLine("\nAdd arrays:");
            Console.WriteLine("array1: +\tarray2:");
            int startIndex = 1;
            int endIndex = 5;
            Arrays ar1 = new Arrays(endIndex, startIndex);
            Arrays ar2 = new Arrays(endIndex, startIndex);
            for (int i = startIndex; i < endIndex; i++)
            {
                ar1[i] = i + 20;
                Console.Write("a[{0}]="+ar1[i] + "  \t",i);
                ar2[i] = i + 5;
                Console.WriteLine("a[{0}]=" + ar2[i] + "\t",i);
            }
            
            Console.WriteLine("=summary:\n{0}",ar1.Add(ar2).ToString());  
          
            //add arrays in another way
            Console.WriteLine("\nAdd arrays 2 way: \n{0} \n+\n {1} \n=\n{2}", ar1.ToString(), ar2.ToString(), (ar1+ar2).ToString());

            //add arrays with different index (Exception case)
            Arrays ar3 = new Arrays(new int[] { 1, 2, 3, 4}, 3);
            Console.WriteLine("\nAdd diferent arrays: \n{0} \n+\n {1}",ar1.ToString(),ar3.ToString());
            Arrays arRez = ar1.Add(ar3);
            if (arRez != null)
                Console.WriteLine(arRez.ToString());
            else
                Console.WriteLine("=summary:null");

            //Substraction
            Console.WriteLine("\nSubstract arrays: \n{0} \n-\n{1} \n=\n{2}", ar1.ToString(), ar2.ToString(), ar1.Sub(ar2));
            //another way substraction
            Console.WriteLine("\nSubstract arrays: \n{0} \n-\n{1} \n=\n{2}", ar1.ToString(), ar2.ToString(), (ar1-ar2).ToString());

            //Multiplication by number
            int n = 5;
            Console.WriteLine("\nMultiplication by number \n{0} \n*\n{1} \n=\n{2}", n, ar1.ToString(), ar1.MultByNum(n).ToString());

            //Comparison of two arrays
            Console.WriteLine("\nComparison array \n{0} \n with\n{1} \n= {2}", ar1.ToString(), ar2.ToString(), ar1.isEqual(ar2));
        }
    }
}
