using System.Diagnostics;
using System.Numerics;

namespace LinqLesson
{
    public static class YieldReturn
    {
        public static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            IEnumerable<int> numberCollection = CreateExpensiveSequence();

            foreach (var a in numberCollection)
            {
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
                Console.WriteLine(a);
            }

            Console.WriteLine();
        }

        private static IEnumerable<int> CreateExpensiveSequence()
        {
            int number = 0;
            while (number < 10)
            {
                Thread.Sleep(100);
                number++;
                yield return number;
            }
        }
    }
}