namespace CodingContest2024;

public static class Program
{
    /// <summary>
    /// The Input in the Coding Contest is given always the same:
    /// 3 [Number of how many lines the input is]
    /// Line 1
    /// Line 2
    /// Line 3
    /// 2 [Number of how many lines the next input is]
    /// Line 1 of the next input
    /// Line 2 of the next input
    /// ... [this can go on for many inputs]
    ///
    /// To make this easy the InputOutputHelper needs a parameter List of functions, these functions are in the order of the input to process e.g.:
    /// ParseOneFunc(); --> Will parse the first part of the input (in the above example 3 Lines)
    /// ParseTwoFunc(); --> Will parse the second part of the input (in the above example 2 Lines)
    ///
    /// To process the parsed input a Solution function is needed --> List[string] Solution(Parser parser)
    ///
    /// InputOutputHelper.Process(Solution, new Parser(ParseOneFunc(), ParseTwoFunc(), ...));
    ///
    /// The function "parser.Go()" will return a list of objects, the parsed objects from the functions given to the parser
    ///
    /// The InputOutputHelper.Process( ... ) will automatically process all input files in the ./Input/ folder and will print the List[string] given from the solution
    /// foreach Input into the ./Output/ folder with the same name as the input file
    ///
    /// The Grid class will help with 2d array stuff like path finding, neighbours, boundary management, etc.
    /// </summary>
    
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