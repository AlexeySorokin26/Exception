using System;

namespace eventsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[]
            {
                "vladimir",
                "alexey",
                "irina",
                "elena",
                "olga",
                "viktor",
            };

            try
            {
                SortNamesProcess snp = new SortNamesProcess();
                snp.SortNamesEvent += Sort;
                snp.SortWithEvent(names);
                Array.ForEach(names, name => Console.WriteLine(name));
            }
            catch (FormatException)
            {

            }

        }

        public static void Sort(string[] names, int order)
        {
            if (order == 1)
            {
                Array.Sort(names);
            }
            else
            {
                Array.Sort(names);
                Array.Reverse(names);
            }
        }
    }

    public class SortNamesProcess
    {
        public delegate void SortNamesDelegate(string[] names, int order);
        public event SortNamesDelegate SortNamesEvent;

        public void SortWithEvent(string[] names)
        {
            Console.WriteLine("input 1 to sort asc and 2 to sort desc");
            int order = Convert.ToInt32(Console.ReadLine());
            if (order != 1 && order != 2) throw new FormatException();

            SortNames(names, order);
        }

        protected virtual void SortNames(string[] names, int order)
        {
            SortNamesEvent?.Invoke(names, order);
        }

    }


}
