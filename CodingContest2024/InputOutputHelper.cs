using System.Diagnostics;

namespace CodingContest2024;

public static class InputOutputHelper
{
    private const string InputFilePath = "Input";
    private const string OutputFilePath = "Output";

    private static string GetFilePath(bool input, string fileName = "")
    {
        string addon = input ? InputFilePath : OutputFilePath;
        
        if (fileName == "")
        {
            return Path.Combine(Directory.GetCurrentDirectory(), addon);
        }
        
        return Path.Combine(Directory.GetCurrentDirectory(), addon, fileName);
    }

    public static void Process(Func<Parser, List<string>> solution, Parser parser)
    {
        string inputPath = GetFilePath(true);
        string outputPath = GetFilePath(false);

        foreach (string filePath in Directory.GetFiles(outputPath))
        {
            File.Delete(filePath);
        }
        
        foreach (string filePath in Directory.GetFiles(inputPath))
        {
            List<string> lines = solution.Invoke(parser);
            string fileName = filePath.Split(Path.DirectorySeparatorChar)[^1];

            File.WriteAllLines(Path.Combine(outputPath, fileName), lines);
        }
    }
}