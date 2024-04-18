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
        functions.Add(ParserOne);
        
        InputOutputHelper.Process(Solution, new Parser(functions));
        
        // If you want to take the first line or anything for info just remove it here
        // BUT! Default is that the first line of each input contains number of lines + params
        // e.g.:
        // 2 Hello 18
        // 1,2,3,4
        // 5,6,7,8
        
        // Here 2 is the number of lines
        // And the parser will get as the first line as params "Hello 18"
        // HOWEVER it can be that you need to extract extra lines at the beginning!
    }

    /// <summary>
    /// To Cast:
    /// [DataType] scores = parsed[0] as [DataType];
    /// </summary>
    /// <param name="parser"></param>
    /// <returns></returns>
    public static List<string> Solution(Parser parser)
    {
        List<object> parsed = parser.Go();
        List<int>? scores = parsed[0] as List<int>;
        
        List<string> result = new List<string>();
        result.Add(scores!.Max().ToString());
        
        return result;
    }


    
    /// <summary>
    /// First line in toParse are additional params
    /// To delete these:
    /// toParse.RemoveAt(0);
    /// </summary>
    /// <param name="toParse"></param>
    /// <returns></returns>
    public static object ParserOne(List<string> toParse)
    {
        toParse.RemoveAt(0);
        
        List<int> scores = new List<int>();
        foreach(string line in toParse)
        {
            scores.Add(int.Parse(line));
        }

        return scores;
    }
}