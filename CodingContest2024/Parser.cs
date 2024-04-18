namespace CodingContest2024;

public class Parser
{
    private readonly string _inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Input");
    private int _currentIndex = 0;
    
    private List<Func<List<string>, object>> Parsers { get; }

    public Parser(List<Func<List<string>, object>> parsers, bool isTest = false)
    {
        if (isTest)
        {
            _inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Test_Input");
        }
        
        Parsers = parsers;
    }

    public List<object> Go()
    {
        List<object> parsed = new();
        string[] input = File.ReadAllLines((Directory.GetFiles(_inputFilePath))[_currentIndex]);
        
        int lineIndex = 0;
        foreach (Func<List<string>, object> parsing in Parsers)
        {
            List<string> lines = new();
            string curLine;
            string parameters = input[lineIndex];
            lineIndex += 1;
            int curIndex = 0;
            int numberOfLines = int.Parse(parameters.Split(' ')[0]);
            string others = string.Join(' ', parameters.Split(' ').Skip(1));
            do
            {
                curLine = input[lineIndex];
                lines.Add(curLine);
                lineIndex++;
                curIndex++;
            } 
            while (curIndex < numberOfLines && curLine != "" && lineIndex < input.Length);

            var list = lines.ToList();
            list.Insert(0, others);
            
            parsed.Add(parsing.Invoke(list));
        }

        _currentIndex++;

        return parsed;
    }
}