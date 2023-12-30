namespace WordCounter;

class Program
{
    static async Task Main(string[] args)
    {
        var fileContent =
            await File.ReadAllLinesAsync("C:\\Source\\WordCounter\\WordCounter\\sample-2mb-text-file.txt");
        Dictionary<string, int> occurrencesCount = new Dictionary<string, int>();
        var highestCount = 0;
        var wordWithHighestCount = "";
        foreach (var line in fileContent)
        {
            var words = line.Split(' ');
            foreach (var word in words)
            {
                var wordNoDotsAndAllSmallLetters = word.Replace(".", "").ToLower();
                if (!occurrencesCount.TryAdd(wordNoDotsAndAllSmallLetters, 1))
                {
                    occurrencesCount[wordNoDotsAndAllSmallLetters] += 1;
                }
            }
        }

        foreach (var keyValuePair in occurrencesCount)
        {
            if (highestCount < keyValuePair.Value)
            {
                wordWithHighestCount = keyValuePair.Key;
                highestCount = keyValuePair.Value;
            }
        }

        Console.WriteLine($"WordWithHighestCount Is: {wordWithHighestCount}");
        Console.WriteLine($"Highest Count Is: {highestCount}");
    }
}