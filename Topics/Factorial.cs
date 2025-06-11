using Playground.Topics.Interfaces;

namespace Playground.Topics
{
    public class Factorial : IRunner
    {
        public void Run()
        {
            var n = 5;
            Console.WriteLine($"{n}! = {CalculateFactorial(n)}");
        }

        private int CalculateFactorial(int n)
        {
            if (n == 0 || n == 1) // base case
            {
                return 1;
            }

            return n * CalculateFactorial(n - 1);
        }
    }
}
