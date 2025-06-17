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
                case "MultiTasks": return new MultiTasks();
                case "TryCatchFinally": return new TryCatchFinally();
                case "FileSystem": return new FileSystem();
                case "Factorial": return new Factorial();
                case "Record": return new Record();
                case "Sorting": return new Sorting();
                default: throw new ArgumentException("in-correct class name");
            }
        }
    }
}
