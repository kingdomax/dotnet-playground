using Playground.Topics.Interfaces;

namespace Playground.Topics
{
    public static class FactoryDesignPattern
    {
        public static IRunner Create(string name)
        {
            switch (name)
            {
                case "Comparer": return new Comparer();
                case "FizzBuzz": return new FizzBuzz();
                case "GraphDb": return new GraphDb();
                case "RestApi": return new RestApi();
                default: throw new ArgumentException("in-correct class name");
            }
        }
    }
}
