using Playground.Topics.Interfaces;

namespace Playground.Topics
{
    public class Sorting : IRunner
    {
        public void Run()
        {
            var list = new List<int>() { };
            Print("Input", list);

            MergeSort(list);
            InsertionSort(list);

            Print("Sorted", list);
        }

        // O(n log n)
        private void MergeSort(List<int> input)
        {
            // input.OrderBy(x => x).ToList();
        }

        // O(n log n)
        private void InsertionSort(List<int> input)
        {
            // input.OrderBy(x => x).ToList();
        }

        private void Print(string prefix, List<int> input)
        {
            Console.Write($"{prefix}: ");
            foreach (var item in input)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}
