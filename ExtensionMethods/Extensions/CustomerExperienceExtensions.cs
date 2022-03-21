using System;
using LinqLesson;

namespace Extensions
{
    public static class CustomerExperienceExtensions
    {
        public static bool IsPositive(this CustomerExperience customerExperience)
        {
            switch (customerExperience)
            {
                case CustomerExperience.Ok:
                case CustomerExperience.Good:
                case CustomerExperience.VeryGood:
                case CustomerExperience.Perfect:
                    return true;
                case CustomerExperience.NotSoGood:
                case CustomerExperience.PrettyBad:
                case CustomerExperience.Bad:
                case CustomerExperience.Disastrous:
                    return false;
                default:
                    throw new Exception("No such case");
            }
        }

        public static bool IsExtreme(this CustomerExperience customerExperience)
        {
            return customerExperience == CustomerExperience.Perfect || customerExperience == CustomerExperience.Disastrous;
        }
    }
}
