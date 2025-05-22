using Playground.Topics.Models;

namespace Playground.Topics
{
    public class Comparer : IComparer<Student>
    {
        public void Run()
        {
            var studentList = new List<Student>()
            {
                new Student { Name = "Alice", Score = 90 },
                new Student { Name = "Bob", Score = 95 },
                new Student { Name = "Charlie", Score = 95 },
                new Student { Name = "Eve", Score = 100 }
            };

            studentList.Sort(Compare);

            foreach (var student in studentList)
            {
                Console.WriteLine($"{student.Name} - {student.Score}");
            }
        }

        public int Compare(Student x, Student y)
        {
            // Descending by score
            if (y.Score != x.Score)
            {
                return y.Score.CompareTo(x.Score); // -1 ascending (x come before y), 1 descending (y come before x)
            }

            // Ascending by name
            return x.Name.CompareTo(y.Name);
        }
    }
}
