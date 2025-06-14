using Playground.Topics.Interfaces;

namespace Playground.Topics
{
    public class FileSystem : IRunner
    {
        public void Run()
        {
            ReadWriteFile().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        // Combination usage of Directory, File, StreamReader, Path
        private async Task ReadWriteFile()
        {
            var startingDirectory = "D:\\My Project\\dotnet-playground\\Topics";

            // Find all text file is sub-directories
            var textFileToProcess = new List<string>();
            foreach (var subDirectory in Directory.GetDirectories(startingDirectory))
            {
                var allFiles = Directory.GetFiles(subDirectory, "*.txt");
                textFileToProcess.AddRange(allFiles);
            }

            // Create combine content
            string combinedContent = $"{DateTime.Now} \n";
            foreach (var textFile in textFileToProcess)
            {
                var fileName = Path.GetFileName(textFile);
                if (fileName == "combined_text.txt") { continue; }

                combinedContent += $"[{fileName}]: ";
                string content = await File.ReadAllTextAsync(textFile); // Buffered read
                combinedContent += $"{content} \n";
            }

            // Write combine content to a new file
            string outputFileName = $"combined_text.txt";
            string outputPath = Path.Combine($"{startingDirectory}\\Assets", outputFileName);
            await File.WriteAllTextAsync(outputPath, combinedContent); // Buffered write

            // Read new file by streaming method
            using var reader = new StreamReader(outputPath);
            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync(); // Streaming read
                Console.WriteLine(line);
            }
        }
    }
}
