using Playground.Topics.Interfaces;

namespace Playground.Topics
{
    public record User(int id, string name); // record class

    public class Record : IRunner
    {
        public void Run()
        {
            var u1 = new User(1, "Alice");
            var u2 = new User(1, "Alice");
            Console.WriteLine($"value equality: {u1 == u2}"); // value equality

            var u3 = u1 with { name = "Bob" }; // with expression
            Console.WriteLine($"with expression: {u3}");

            var (id, name) = u3;
            Console.WriteLine($"destruction: {id} - {name}");
        }
    }
}
