using System;

namespace DateDiff.Models.BloodBank
{
    public static class A 
    {
        private const int bloodCapacity = 1000;
        private static int tank = 0;

        public static bool test = false;
        

        public static void Model()
        {
            if (tank < bloodCapacity)
            {
                tank += 200;
            }
            else
            {
                Console.WriteLine($"Blood {typeof(A).Name} Bank is full");
                test = true;
            }
        }
    }
}