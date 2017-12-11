using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Array
{
    class Arrays
    {
        public int[] Array { get; set; }
        int indexBegin;
        int indexEnd;

        public Arrays(int end, int start = 0 )
        {
            try
            {
                if (start > end || start < 0)
                    throw new ArgumentException("Wrong argument parameters!");
                Array = new int[end - start];
                indexBegin = start;
                indexEnd = end;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Costruct error" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Costruct error" + e.Message);
            }
        }
        public Arrays(int[] arr, int start=0)
        {
            try
            {
                if (start < 0)
                    throw new ArgumentException("Wrong argument parameters!");
                Array = arr;
                indexBegin = start;
                indexEnd = start + arr.Length;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Costruct error" + e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Costruct error" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Costruct error" + e.Message);
            }
        }
        /// <summary>
        /// indexer sets or returns
        /// the value with passed index
        /// </summary>
        /// <param name="i">index</param>
        /// <returns></returns>
        public int this[int i]
        {        
            get 
            {
                try
                {
                    if (i < 0 || i < indexBegin ||i > indexEnd)
                        throw new ArgumentOutOfRangeException("Oops!Index is out of range.");
                    return Array[i - indexBegin];
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Oops!Index is out of range at Getter" + ex.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oops! Getter error" + e.Message);
                }
                return 0;
            }
            set 
            { 
                try
                {
                    if (i < 0 || i < indexBegin ||i > indexEnd)
                        throw new ArgumentOutOfRangeException("Oops!Index is out of range!");
                    Array[i-indexBegin] = value;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Oops!Index is out of range in Setter" + ex.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oops! Setter error" + e.Message);
                }
            }       
        }

        public int Lenght()
        {
            return indexEnd - indexBegin;
        }
        /// <summary>
        /// Add arrays with same index
        /// </summary>
        /// <param name="array">array for add</param>
        /// <returns></returns>
        public Arrays Add(Arrays array)
        {
            try
            {
                if (array == null)
                    throw new ArgumentNullException();
                if (this.indexBegin != array.indexBegin && this.indexEnd != array.indexEnd)
                    throw new ArgumentException("Arrays have different index range");
                Arrays rezArray = new Arrays(indexEnd, indexBegin);
                for (int i = indexBegin; i < indexEnd;i++ )
                    rezArray[i] = this[i] + array[i];
                return rezArray;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Oops! Add error: " + e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Oops! Add error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! Add error: " + e.Message);
            }
            return null;
        }
        
        /// <summary>
        /// Substract arrays with same index
        /// </summary>
        /// <param name="array">array</param>
        /// <returns></returns>
        public Arrays Sub(Arrays array)
        {
            try
            {
                if (array == null)
                    throw new ArgumentNullException();
                if (this.indexBegin != array.indexBegin && this.indexEnd != array.indexEnd)
                    throw new ArgumentException("Arrays have different index range");
                Arrays rezArray = new Arrays(indexEnd, indexBegin);
                for (int i = indexBegin; i < indexEnd; i++)
                    rezArray[i] = this[i] - array[i];
                return rezArray;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Oops! Sub error: " + e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Oops! Sub error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! Sub error: " + e.Message);
            }
            return null;
        }
        /// <summary>
        /// Multiplication by number
        /// </summary>
        /// <param name="n">number</param>
        /// <returns></returns>
        public Arrays MultByNum(int n)
        {
            try
            {
                Arrays ar = new Arrays(indexEnd, indexBegin);
                for (int i = indexBegin; i < indexEnd; i++)
                {
                    ar[i] = n * this[i];
                }
                return ar;
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops!MultByNum error: " + e.Message);
                return null;
            }
        }
        /// <summary>
        /// Overloaded operator +
        /// </summary>
        /// <param name="ar1">array</param>
        /// <param name="ar2">array</param>
        /// <returns></returns>
        public static Arrays operator + (Arrays ar1, Arrays ar2)
        {
            return ar1.Add(ar2);
        }
        /// <summary>
        /// Overloaded operator -
        /// </summary>
        /// <param name="ar1">array</param>
        /// <param name="ar2">array</param>
        /// <returns></returns>
        public static Arrays operator - (Arrays ar1, Arrays ar2)
        {
            return ar1.Sub(ar2);
        }
        /// <summary>
        /// Overrided method ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str=null;
            try
            {
                for (int i = indexBegin; i < indexEnd; i++)
                {
                    str += "a["+i+"]=" + Array[i - indexBegin] + "\t";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops!!! ToString error: " + e.Message);
                str = "error";
            }
            return str;
        }
        /// <summary>
        /// Comparison of two arrays
        /// </summary>
        /// <param name="v">vector</param>
        /// <returns></returns>
        public bool isEqual(Arrays array)
        {
            try
            {
                if (array == null)
                    throw new ArgumentNullException();
                if (this.indexBegin != array.indexBegin && this.indexEnd != array.indexEnd)
                    return false;
                for (int i = indexBegin; i < indexEnd; i++)
                    if (this[i] != array[i])
                        return false;
                return true;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("IsEqual error: no array for comparison" + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("IsEqual error: "+ex.Message);
                return false;
            }
        }
    }
}
