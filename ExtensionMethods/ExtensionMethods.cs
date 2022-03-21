using Extensions;

namespace LinqLesson
{
    public static class ExtensionMethods
    {
        public static void Main(string[] args)
        {
            var customerExperience = CustomerExperience.Bad;
            if (customerExperience.IsPositive())
            {
                Console.WriteLine("Experience was good");
            }
            else
            {
                Console.WriteLine("Experience was bad");
            }

            customerExperience.IsExtreme();
        }
    }

    public enum CustomerExperience
    {
        Ok,
        Good,
        VeryGood,
        Perfect,
        NotSoGood,
        PrettyBad,
        Bad,
        Disastrous
    }
}