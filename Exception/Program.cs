using System;
using System.IO;

namespace MyExceptionTask
{

    public class ArrException : Exception
    {
        public ArrException(string message) : base(message)
        {

        }
    }
    public class Arr
    {
        public Arr(int size) 
        {
            this.size = size;
            int[] arr = new int[this.size];
        }
        private int[] arr;
        private int size;
        public void PushBack(int val)
        {
            if(this.arr == null)
            {
                this.size = 1;
                this.arr = new int[this.size];
                this.arr[0] = val;
                return;
            }
            int[] tmp = new int[this.size + 1];
            for (int i = 0; i < this.size; ++i)
            {
                tmp[i] = this.arr[i];
            }
            tmp[this.size] = val;
            this.size++;
            this.arr = new int[this.size];
            for (int i = 0; i < this.size; ++i)
            {
                arr[i] = tmp[i];
            }
        }

        public int ShowElement(int index)
        {
            if(index < size)
            {
                return arr[index];
            }
            else
            {
                throw new ArrException("out of range");
            }
        }
   
    }

    public class ExcExamples
    {
        public static void ExceptionExamples()
        {
            try
            {

            }
            catch (ArrException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                //Console.WriteLine("input a size of arr:");
                //int size;
                //bool isCorrect = int.TryParse(Console.ReadLine(), out size);
                const int size = 5;
                Arr arr = new Arr(size);
                arr.PushBack(1);
                arr.PushBack(2);
                arr.PushBack(3);
                arr.PushBack(4);
                arr.PushBack(5);



                /*int index;
                bool isCorrect = int.TryParse(Console.ReadLine(), out index);
                if (isCorrect)
                {
                    int res = arr.ShowElement(index);
                }
                */

                FileInfo fi1 = null;
                //var tmp = fi1.Length;

                FileInfo fi2 = new FileInfo("t.txt");
                fi2.Open(FileMode.Open);

                int zero = int.Parse(Console.ReadLine());
                int a = 2 / zero;

                Console.WriteLine("input an index of arr:");
                int index = int.Parse(Console.ReadLine());
                int res = arr.ShowElement(index);

                Exception[] ex = new Exception[size]
                {
                    new ArrException("hi"),
                    new DivideByZeroException(),
                    new FileNotFoundException(),
                    new FormatException(),
                    new ArgumentNullException(),
                };
            }
            catch (ArrException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (RankException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("job is done!");
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            ExcExamples.ExceptionExamples();
        }
    }
}
