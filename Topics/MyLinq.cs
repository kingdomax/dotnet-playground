using Playground.Topics.Interfaces;

namespace Playground.Topics
{
    public class MyLinq : IRunner
    {
        public void Run()
        {
            var tasks = new List<TaskItem>
            {
                new TaskItem { Id = 1, Title = "Fix bug", AssignedTo = "Alice", Priority = 3, IsCompleted = false },
                new TaskItem { Id = 2, Title = "Write tests", AssignedTo = "Bob", Priority = 3, IsCompleted = true },
                new TaskItem { Id = 3, Title = "Deploy app", AssignedTo = "Alice", Priority = 2, IsCompleted = false },
                new TaskItem { Id = 4, Title = "Code review", AssignedTo = "Charlie",  Priority = 2, IsCompleted = true },
                new TaskItem { Id = 5, Title = "Rollback", AssignedTo = "Charlie",  Priority = 1, IsCompleted = false }
            };

            // .Select()
            var selectNewTasks = tasks.Select(t => new TaskItem() { Title = "(modified)" + t.Title }).ToList();
            Print(".Select()", selectNewTasks);
            var selectTitles = tasks.Select(t => t.Title).ToList();
            Print(".Select()", selectTitles);

            // .Where()
            var incompleteTasks = tasks.Where(t => !t.IsCompleted).ToList();
            Print(".Where()", incompleteTasks);

            // .First()
            var firstTask = tasks.First();
            Print(".First()", new List<TaskItem> { firstTask });
            // .FirstOrDefault()
            var firstMatchTask = tasks.FirstOrDefault(t => t.AssignedTo == "Charlie");
            Print(".FirstOrDefault()", new List<TaskItem> { firstMatchTask });

            // .RemoveAll(T)
            tasks.Remove(firstTask);
            Print(".Remove(T)", tasks);
            // .RemoveAll(predicate) 
            tasks.RemoveAll(t => t.Id == 2);
            Print(".RemoveAll(predicate)", tasks);

            // .OrderBy()
            var orderTasks = tasks.OrderBy(t => t.Priority).ThenBy(t => t.Id).ToList();
            Print(".OrderBy()", orderTasks);

            // .GroupBy()
            var groupTasks = tasks.GroupBy(t => t.AssignedTo).ToList();
            Print(".GroupBy()", groupTasks);

            // .Any()
            var hasUrgentTask = tasks.Any(t => t.Priority == 1);
            Print(".Any(hasUrgentTask)", hasUrgentTask.ToString());
            // .All()
            var allCompleted = tasks.All(t => t.IsCompleted);
            Print(".All(allCompleted)", allCompleted.ToString());
            // .Count()
            var completedCount = tasks.Count(t => t.IsCompleted);
            Print(".Count(completedCount)", completedCount.ToString());
        }

        public void Print(string method, List<TaskItem> tasks)
        {
            Console.WriteLine($"\n{method}");
            foreach (var task in tasks)
            {
                Console.WriteLine($"Id='{task.Id}' Title='{task.Title}' AssignedTo='{task.AssignedTo}' Priority='{task.Priority}' IsCompleted='{task.IsCompleted}'");
            }
        }

        public void Print(string method, List<string> tasks)
        {
            Console.WriteLine($"\n{method}");
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }

        public void Print(string method, List<IGrouping<string, TaskItem>> tasks)
        {
            Console.WriteLine($"\n{method}");

            foreach (var group in tasks)
            {
                Console.WriteLine($"Key={group.Key}");
                foreach (var task in group)
                {
                    Console.WriteLine($"- {task.Title}");
                }
            }
        }

        public void Print(string method, string result)
        {
            Console.WriteLine($"\n{method}");
            Console.WriteLine(result);
        }
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public string AssignedTo { get; set; }
        public int Priority { get; set; }
    }
}
