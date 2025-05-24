using Playground.Topics.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace Playground.Topics
{
    public class RestApi : IRunner
    {
        public void Run()
        {
            Get().GetAwaiter().GetResult();
            Post().GetAwaiter().GetResult();
        }

        private async Task Get()
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/users") { };

                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync(); // For debug purpose
                    var users = JsonSerializer.Deserialize<List<Users>>(jsonString);

                    if (users != null)
                    {
                        foreach (var user in users)
                        {
                            Console.WriteLine($"{user.id} - {user.name} - {user.email}");
                        }
                    }
                }
            }
        }

        private async Task Post()
        {
            using (var httpClient = new HttpClient())
            {
                var newUser = new Users()
                {
                    name = "John Doe",
                    username = "johndoe",
                    email = "john@example.com",
                    phone = "123-456-7890",
                    website = "johndoe.com"
                };

                var request = new HttpRequestMessage(HttpMethod.Post, "https://jsonplaceholder.typicode.com/users")
                {
                    Content = JsonContent.Create(newUser) // This automatically set "Content-Type" header
                };
                request.Headers.Add("Authorization", "Bearer your_token_here");
                request.Headers.Add("X-Custom-Header", "CustomValue");
                request.Headers.Add("Accept", "application/json");

                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var createdUser = await response.Content.ReadFromJsonAsync<Users>();
                    Console.WriteLine($"[CREATED] {createdUser?.id} - {createdUser?.name} - {createdUser?.email}");
                }
            }
        }
    }

    public class Users
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? website { get; set; }
    }
}
