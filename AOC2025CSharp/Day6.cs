using System.Diagnostics;

namespace AOC2025CSharp;

public static class Day6
{
    private const string InputFile = "/home/stuart/Source/AOC2025CSharp/AOC2025CSharp/Inputs/day6";
    public static void Part1()
    {
        var sw = new Stopwatch();
        sw.Start();
        
        var fileContents = File.ReadAllText(InputFile);
        var lines = fileContents.Split(Environment.NewLine).ToList();

        var operators = lines[^1].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            
        var numbers = lines.Take(lines.Count - 1)
                           .Select(x => x.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToList())
                           .ToList();

        List<List<int>> xs = [];
        
        for(var col = 0; col < numbers[0].Count; col++)
        {
            xs.Add([]);
            
            foreach (var t in numbers)
            {
                xs[col].Add(t[col]);
            }
        }

        List<long> totals = [];
        
        for (var i = 0; i < xs.Count; i++)
        {
            long seed = operators[i] == "+" ? 0 : 1;
            totals.Add(xs[i].Aggregate(seed, (acc, n) =>
            {
                if (operators[i] == "+")
                {
                    return acc += n;
                }

                if (operators[i] == "*")
                {
                    return acc *= n;
                }

                return 0;
            }));
            
        }
        
        Console.WriteLine(totals.Sum());
        
        sw.Stop();
    }
    
    public static void Part2()
    {
        var sw = new Stopwatch();
        sw.Start();

        var fileContents = File.ReadAllText(InputFile);
        
        var lines = fileContents.Split(Environment.NewLine).ToList();
        var numbers = lines.Take(lines.Count - 1)
            .Select(x => x.ToCharArray())
            .ToList();
        
        var operators = lines[^1].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        
        foreach (var number in numbers)
        {
            for (var j = 0; j < number.Length; j++)
            {
                var c = number[j];
                
                if (c == ' ')
                {
                    foreach (var t in numbers)
                    {
                        if (char.IsNumber(t[j]))
                        {
                            number[j] = '0';
                            break;
                        }
                    }
                }
                
            }
        }
        
        var rows = numbers.Select(n => string.Join("", n))
            .Select(x => x.Split(" ").ToList())
            .ToList();
        
        List<List<int>> xs = [];
        long answer = 0;

        for (var i = 0; i < rows[0].Count; i++)
        {
            List<string> toParse = [];
            toParse.AddRange(rows.Select(row => row[i]));

            var parsed = ParseNumbers(toParse);
            xs.Add(parsed);
        }

        for (var i = 0; i < xs.Count; i++)
        {
            var op = operators[i];
            if (op == "+")
            {
                var total = xs[i].Aggregate((long)0, (acc, b) => acc + b);
                answer += total;
            }
            else if (op == "*")
            {
                var total = xs[i].Aggregate((long)1, (acc, b) => acc * b);
                answer += total;
            }
        }
        
        Console.WriteLine($"Answer: {answer}");
        
        sw.Stop();
    }

    private static List<int> ParseNumbers(List<string> xs)
    {
        var digits = xs[0].Length;
        var numbers = new List<int>();

        for (var i = 0; i < digits; i++)
        {
            var n = 0;

            foreach (var x in xs)
            {
                var currentDigit = x[i].ToString();
                if (currentDigit != "0")
                {
                    n *= 10;
                    n += int.Parse(currentDigit);
                }
            }

            numbers.Add(n);
        }
        
        return numbers;
    }
}