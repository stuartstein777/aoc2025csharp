using System.Diagnostics;

namespace AOC2025CSharp;

public static class Day3
{
    public static void Part1()
    {
        var sw = new Stopwatch();
        sw.Start();
        
        var answer = File.ReadAllLines(@"/home/stuart/Source/clojure/aoc/puzzle-inputs/2025/day3")
            .Select(l => l.ToCharArray())
            .Select(x => x.Select(y => int.Parse(y.ToString())).ToList())
            .Select(GetBiggest1)
            .Select(ListToNumber)
            .Aggregate((long)0, (x, y) => x + y);
        
        sw.Stop();
        Console.WriteLine($"Day 3 Part 1 Answer: {answer.ToString().PadRight(20)}{sw.Elapsed}");
    }

    public static List<int> GetBiggest1(List<int> input)
    {
        List<int> res = [0, 0];
        for (var i = 0; i < input.Count; i++)
        {
            var n = input[i];
            if (n > res[0] && input.Count - i > 1)
            {
                res[0] = n;
                res[1] = 0;
            }
            else if (n > res[1])
            {
                res[1] = n;
            }
        }
        
        return res;
    }
    
    public static void Part2()
    {
        var sw = new Stopwatch();
        sw.Start();
        
        var answer = File.ReadAllLines(@"/home/stuart/Source/clojure/aoc/puzzle-inputs/2025/day3")
            .Select(l => l.ToCharArray())
            .Select(x => x.Select(y => int.Parse(y.ToString())).ToList())
            .Select(GetBiggest)
            .Select(ListToNumber)
            .Aggregate((long)0, (x, y) => x + y);
        
        sw.Stop();
        Console.WriteLine($"Day 3 Part 2 Answer: {answer.ToString().PadRight(20)}{sw.Elapsed}");
    }
    
    private static List<int> GetBiggest(List<int> input)
    {
        const int maxLength = 12;
        var result = new List<int>(12);
   
        for (var i = 0; i < input.Count; i++)
        {
            var slotsRemainingToFill = maxLength - result.Count;
            var inputSlotsToConsider = input.Count - i;
            var n = input[i];
        
            if (result.Count == 0 || inputSlotsToConsider == slotsRemainingToFill)
            {
                result.Add(n);
                continue;
            }

            var resultStartConsiderPoint = inputSlotsToConsider > maxLength ? 0 : 12 - inputSlotsToConsider;
            var placedN = false;
            for (var j = resultStartConsiderPoint; j < result.Count; j++)
            {
                if (n > result[j])
                {
                    result[j] = n;
                    result = result[..(j+1)]; 
                    placedN = true;
                }
            }

            if (!placedN && result.Count < maxLength)
            {
                result.Add(n);
            }
        }

        return result;
    }

    private static long ListToNumber(List<int> xs)
    {
        long total = 0;

        foreach (var x in xs)
        {
            total *= 10;
            total += x;
        }
    
        return total;
    }
    
}