using Playground.Topics.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace Playground.Topics
{
    public class MultiAsync : IRunner
    {
        public void Run()
        {
            //var results = WhenAll().ConfigureAwait(false).GetAwaiter().GetResult();
            var results = WhenAny().ConfigureAwait(false).GetAwaiter().GetResult();

            for (var i = 0; i < results.Length; i++) { Console.WriteLine($"Result: {results[i]?.userId} - {results[i]?.title} - {results[i]?.completed}"); }
        }

        private async Task<TodoDto?[]> WhenAll()
        {
            try
            {
                using var httpCLient = new HttpClient();

                var tasks = new Task<TodoDto?>[]
                {
                    PostAsync(httpCLient, 1, "todo one", true),
                    PostAsync(httpCLient, 2, "todo two", true),
                    PostAsync(httpCLient, 3, "todo three", true),
                    PostAsync(httpCLient, 4, "todo four", false),
                    PostAsync(httpCLient, 5, "todo five", false, throwException: true),
                };
                var results = await Task.WhenAll(tasks);

                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Array.Empty<TodoDto?>();
            }
        }

        private async Task<TodoDto?[]> WhenAny()
        {
            using var httpCLient = new HttpClient();

            var tasks = new Task<TodoDto?>[]
            {
                PostAsync(httpCLient, 1, "wait 1s", true),
                PostAsync(httpCLient, 2, "wait 2s", true),
                PostAsync(httpCLient, 3, "wait 3s", true),
                PostAsync(httpCLient, 4, "wait 4s", false),
                PostAsync(httpCLient, 5, "wait 5s", false),
            };
            Task<TodoDto?> firstCompleted = await Task.WhenAny(tasks);

            return new TodoDto?[] { await firstCompleted };
        }

        private async Task<TodoDto?> PostAsync(HttpClient httpClient, int userId, string title, bool completed, bool throwException = false)
        {
            if (throwException) { throw new Exception($"Exception at {userId} - {title}"); }
            await Task.Delay(userId * 1000);

            var httpMessage = new HttpRequestMessage(HttpMethod.Post, "https://jsonplaceholder.typicode.com/todos")
            {
                Content = JsonContent.Create(new TodoDto()
                {
                    userId = userId,
                    title = title,
                    completed = completed
                })
            };

            var response = await httpClient.SendAsync(httpMessage);

            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TodoDto>(contentString);
            }

            return null;
        }
    }

    public class TodoDto
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string? title { get; set; }
        public bool completed { get; set; }
    }
}
