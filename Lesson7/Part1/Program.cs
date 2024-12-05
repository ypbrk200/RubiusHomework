namespace Part1
{
    class Program
    {
        // Асинхронный метод для чтения всего файла
        static async Task<int> CountWordsFileAsync(string path)
        {
            string text = await File.ReadAllTextAsync(path);
            string[] words = text.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        // Асинхронный метод для потоковой обработки
        static async Task<int> CountWordsStreamAsync(string path)
        {
            int wordCount = 0;
            using (StreamReader text = new StreamReader(path))
            {
                string line;
                while ((line = await text.ReadLineAsync()) != null)
                {
                    string[] words = line.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    wordCount += words.Length;
                }
            }
            return wordCount;
        }

        static async Task Main(string[] args)
        {
            string filePath = @"..\Part1\WarAndPiece.txt";
            int wordCountFile = await CountWordsFileAsync(filePath);
            Console.WriteLine($"Количество слов (чтение всего файла): {wordCountFile}");
            int wordCountStream = await CountWordsStreamAsync(filePath);
            Console.WriteLine($"Количество слов (потоковая обработка): {wordCountStream}");
        }
    }
}
