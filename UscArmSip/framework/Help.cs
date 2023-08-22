using NUnit.Framework;

namespace UscArmSip
{
    public static class Help
    {
        public static int Randomize(int maxValue)
        {
            return TestContext.CurrentContext.Random.Next(maxValue);
        }

        public static int Randomize(int minValue, int maxValue)
        {
            return TestContext.CurrentContext.Random.Next(minValue, maxValue);
        }

        public static bool GetBoolean()
        {
            return TestContext.CurrentContext.Random.Next(0, 2) > 0;
        }
    }
}