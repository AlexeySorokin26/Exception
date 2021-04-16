using System;

namespace Interface
{
    public interface ILogger
    {
        void Event(string msg);
        void Error(string msg);
    }
    public class Logger : ILogger
    {
        public void Event(string msg)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(msg);
        }
        public void Error(string msg)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
        }
    }
    public interface ISummator
    {
        int Sum(int a, int b);
    }
    public class Summator : ISummator
    {
        public Summator(ILogger Logger)
        {
            this.Logger = Logger;
        }
        public ILogger Logger { get; }
        public int Sum(int a, int b)
        {
            Logger.Event("sum you numbers");
            return a + b;
        }
    }
    class Program
    {
        static ILogger Logger { get; set; }
        static void Main(string[] args)
        {
            Logger = new Logger();
            var summator = new Summator(Logger);
            while (true)
            {
                try
                {
                    Console.WriteLine("type two integerrs to sum them up");
                    int a = Convert.ToInt32(Console.ReadLine());
                    int b = Convert.ToInt32(Console.ReadLine());
                    int res = summator.Sum(a, b);
                    Console.WriteLine(res);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                catch (FormatException)
                {
                    Console.WriteLine("your number is not int");
                    summator.Logger.Error("wrong");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
            /* 
            while (true)
            {
                try
                {
                    Console.WriteLine("type two integer to sum up them");
                    int a = Convert.ToInt32(Console.ReadLine());
                    int b = Convert.ToInt32(Console.ReadLine());
                    int res = new Summator().Sum(a, b);
                    Console.WriteLine(res);
                }
                catch (FormatException)
                {
                    Console.WriteLine("your number is not int");
                }
            }
            */
        }
    }
}
