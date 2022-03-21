namespace LinqLesson
{
    public static class FunctionalCSharpEvolution
    {
        public static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            string[] cars = new string[] { "audi", "tesla", "mercedes" };
            var filteredCars = cars.Filter(car => car.StartsWith("a"));

            Func<int, bool> predicate = number => number % 2 == 0;

            var evenNumbersBiggerThanFive = numbers
                .Where(predicate)
                .Filter(number => number % 6 == 0)
                .Filter(number => number > 5)
                .Filter(number => number < 100);
        }
    }

    public static class FilterExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            foreach (var number in items)
            {
                if (predicate(number))
                {
                    yield return number;
                }
            }
        }
    }
}