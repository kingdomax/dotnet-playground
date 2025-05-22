using Playground.Topics.Models;

namespace Playground.Topics
{
    public class FizzBuzz
    {
        public void Run()
        {
            var input = CreateRoot();
            BFS(input);
        }

        // Question Here !
        private void BFS(TreeNode root)
        {
            if (root == null) return;
            Console.WriteLine("BFS Traversal: ");

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();

                Console.Write(current.Value + " "); // Process node

                if (current.Left != null) { queue.Enqueue(current.Left); }
                if (current.Right != null) { queue.Enqueue(current.Right); }
            }
        }

        private TreeNode CreateRoot()
        {
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(4);
            root.Left.Right = new TreeNode(5);
            root.Right.Right = new TreeNode(6);
            return root;
        }
    }
}
