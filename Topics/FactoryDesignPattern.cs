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
                case "TreeDS": return new TreeDS();
                case "GraphDb": return new GraphDb();
                case "RestApi": return new RestApi();
                case "MyLinq": return new MyLinq();
                case "MultiAsync": return new MultiAsync();
                default: throw new ArgumentException("in-correct class name");
            }
        }
    }
}
