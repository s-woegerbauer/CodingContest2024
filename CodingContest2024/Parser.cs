namespace CodingContest2024;

public class Parser
{
    private const string InputFilePath = "\\Input";

    private int _currentIndex = 0;
    
    private List<Func<List<string>, object>> Parsers { get; }

    public Parser(List<Func<List<string>, object>> parsers)
    {
        Parsers = parsers;
    }

    public List<object> Go()
    {
        List<object> parsed = new();
        string[] input = File.ReadAllLines((Directory.GetFiles(Directory.GetCurrentDirectory() + InputFilePath))[_currentIndex]);
        
        foreach (Func<List<string>, object> parsing in Parsers)
        {
            List<string> lines = new();
            string curLine;
            int lineIndex = 0;
            do
            {
                curLine = input[lineIndex];
                lines.Add(curLine);
                lineIndex++;
            } 
            while (curLine != "" && lineIndex < input.Length);
            
            parsed.Add(parsing.Invoke(lines.Skip(1).ToList()));
        }

        _currentIndex++;

        return parsed;
    }
}