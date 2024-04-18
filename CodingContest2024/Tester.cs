using System.Text;

namespace CodingContest2024; 

public class Tester
{
    public static string InputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Test_Input");
    public static string ExpectedFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Test_Expected");
    
    private static string GetFilePath(bool input, string fileName = "")
    {
        string path = input ? InputFilePath : ExpectedFilePath;
        
        if (fileName == "")
        {
            return path;
        }
        
        return Path.Combine(path, fileName);
    }

    public static void Process(Func<Parser, List<string>> solution, Parser parser)
    {
        string inputPath = GetFilePath(true);
        string outputPath = GetFilePath(false);
        
        foreach (string filePath in Directory.GetFiles(inputPath))
        {
            List<string> lines = solution.Invoke(parser);
            string fileName = filePath.Split(Path.DirectorySeparatorChar)[^1];

            List<string> expectedLines = File.ReadLines(Path.Combine(outputPath, fileName)).ToList();
            
            (decimal score, string difference) = CompareLines(expectedLines, lines);

            if (score != 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("========================================================");
                Console.WriteLine($"Test failed for {fileName}. Score: {score}%\nDifferences:\n{difference}".Trim('\n'));
                Console.WriteLine("========================================================");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("========================================================");
                Console.WriteLine($"Test successful for {fileName}. Score: 100%");
                Console.WriteLine("========================================================");
                Console.ResetColor();
            }
        }
    }
    
    public static (decimal, string) CompareLines(List<string> expectedLines, List<string> actualLines)
    {
        decimal score = 0;
        StringBuilder difference = new StringBuilder();

        for (int i = 0; i < expectedLines.Count; i++)
        {
            if (expectedLines[i] == actualLines[i])
            {
                score += 1;
            }
            else
            {
                difference.AppendLine($"Line {i + 1}: Expected '{expectedLines[i]}', but got '{actualLines[i]}'");
            }
        }

        if (score == expectedLines.Count)
        {
            return (100, "");
        }

        return (score / expectedLines.Count * 100, difference.ToString());
    }
}