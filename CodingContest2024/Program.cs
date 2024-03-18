namespace CodingContest2024;

public static class Program
{
    public static void Main()
    {
        List<Func<List<string>, object>> functions = new List<Func<List<string>, object>>();
        functions.Add(AddNumbers);
        functions.Add(MultiplyNumbers);
        
        InputOutputHelper.Process(Solution, new Parser(functions));
    }

    public static List<string> Solution(Parser parser)
    {
        List<object> parsed = parser.Go();
        
        int numbersAdded = (int)parsed[0];
        int numbersMultiplied = (int)parsed[0];
        
        List<string> output = new List<string>();
        output.Add(numbersAdded.ToString());
        output.Add(numbersMultiplied.ToString());

        return output;
    }

    public static object AddNumbers(List<string> toParse)
    {
        int sum = 0;
        
        foreach (string line in toParse)
        {
            sum += int.Parse(line);
        }

        return sum;
    }
    
    public static object MultiplyNumbers(List<string> toParse)
    {
        int product = 1;
        
        foreach (string line in toParse)
        {
            product *= int.Parse(line);
        }

        return product;
    }
}