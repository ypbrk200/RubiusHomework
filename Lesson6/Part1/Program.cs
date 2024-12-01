namespace Part1;

class Program
{
    // Метод для чтения всего файла
    static int CountWordsFile(string path)
    {
        string text = File.ReadAllText(path);
        string[] words = text.Split(new char[] { ' ' });
        return words.Length;
    }

    // Метод для потоковой обработки
    static int CountWordsStream(string path)
    {
        int wordCount = 0;
        using (StreamReader text = new StreamReader(path))
        {
            string line;
            while ((line = text.ReadLine()) != null)
            {
                string[] words = line.Split(new char[] { ' ' });
                wordCount += words.Length;
            }
        }
        return wordCount;
    }
    static void Main()
    {
        // Прикладываю текстовый файл, не смог разобраться почему получаются разные значения количества слов
        string filePath = "D:/rubius/RubiusHomework/Lesson6/Part1/WarAndPiece.txt";
        int wordCountFile = CountWordsFile(filePath);
        Console.WriteLine($"Количество слов (чтение всего файла): {wordCountFile}");
        int wordCountStream = CountWordsStream(filePath);
        Console.WriteLine($"Количество слов (потоковая обработка): {wordCountStream}");
    }
}
