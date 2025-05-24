using Playground.Topics.Interfaces;

namespace Playground.Topics
{
    // ✅ Simple C# Example of Domain-Driven Design + Graph Traversal
    public class GraphDb : IRunner
    {
        public void Run()
        {
            var graph = new Graph();

            var einstein = new Node("Person");
            einstein.Properties["name"] = "Einstein";

            var relativity = new Node("Concept");
            relativity.Properties["name"] = "Relativity";

            var physics = new Node("Field");
            physics.Properties["name"] = "Physics";

            graph.AddNode(einstein);
            graph.AddNode(relativity);
            graph.AddNode(physics);

            var createdEdge = new Edge(einstein, relativity, "CREATED", weight: 0.95);
            createdEdge.Properties["year"] = 1905;
            graph.AddEdge(createdEdge);

            var relatedEdge = new Edge(relativity, physics, "RELATED", weight: 0.8);
            relatedEdge.Properties["confidence"] = 0.9;
            graph.AddEdge(relatedEdge);

            var relatedToRelativity = graph.DepthFirstTraversal(relativity);

            Console.WriteLine($"Traversed nodes from '{relativity.Label}: {relativity.Properties.GetValueOrDefault("name")}':");
            foreach (var node in relatedToRelativity)
            {
                Console.WriteLine($"- {node.Label}: {node.Properties.GetValueOrDefault("name")}");
            }
        }
    }

    // --- Graph Model Types ---
    public class Node
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Label { get; }
        public Dictionary<string, object> Properties { get; } = new();

        public Node(string label)
        {
            Label = label;
        }
    }

    public class Edge
    {
        public Node From { get; }
        public Node To { get; }
        public string Type { get; }
        public double Weight { get; set; } = 1.0; // Default weight
        public Dictionary<string, object> Properties { get; } = new();

        public Edge(Node from, Node to, string type, double weight = 1.0)
        {
            From = from;
            To = to;
            Type = type;
            Weight = weight;
        }
    }

    public class Graph
    {
        public List<Node> Nodes { get; } = new();
        public List<Edge> Edges { get; } = new();

        public void AddNode(Node node) => Nodes.Add(node);
        public void AddEdge(Edge edge) => Edges.Add(edge);

        public List<Node> GetRelatedNodes(Node source, string relationType)
        {
            return Edges
                .Where(e => e.From == source && e.Type == relationType)
                .Select(e => e.To)
                .ToList();
        }

        public List<Node> DepthFirstTraversal(Node start, int maxDepth = 3)
        {
            var visited = new HashSet<Node>();
            var result = new List<Node>();
            void DFS(Node node, int depth)
            {
                if (depth > maxDepth || visited.Contains(node)) return;
                visited.Add(node);
                result.Add(node);
                foreach (var neighbor in GetRelatedNodes(node, "RELATED"))
                {
                    DFS(neighbor, depth + 1);
                }
            }
            DFS(start, 0);
            return result;
        }
    }
}
