using System.Diagnostics;

namespace AOC2025CSharp;

public static class Day5
{
    private const string InputFile = "/home/stuart/Source/AOC2025CSharp/AOC2025CSharp/Inputs/day5";

    public static void Part1()
    {
        var sw = new Stopwatch();
        sw.Start();

        var lines = File.ReadAllText(InputFile).Split(Environment.NewLine);

        var ranges = lines.TakeWhile(l => l != string.Empty)
            .Select(l => l.Split("-"))
            .Select(xy => new Range1(xy[0], xy[1]));

        var ingredients = lines.Skip(ranges.Count()+1)
            .Select(long.Parse);

        int freshIngredients = 0;

        foreach(var ingredient in ingredients)
        {
            foreach(var range in ranges)
            {
                if(ingredient >= range.X && ingredient <= range.Y)
                {
                    freshIngredients++;
                    break;
                }
            }
        }
        
        sw.Stop();
        Console.WriteLine($"Day 5 Part 1 Answer: {freshIngredients.ToString(),-20}{sw.Elapsed}");
    }
    
    struct Range1
    {
        public Range1(string x, string y)
        {
            X = long.Parse(x);
            Y = long.Parse(y);
        }
        public long X { get; }
        public long Y { get; }
    }

    public static void Part2()
    {
        var sw = new Stopwatch();
        sw.Start();
        
        var input = File.ReadAllText(InputFile);

        var lines = input.Split(Environment.NewLine);

        var ranges = lines.TakeWhile(l => l != string.Empty)
            .Select(l => l.Split("-"))
            .Select(xy => new Range2(xy[0], xy[1]))
            .OrderBy(xy => xy.X)
            .ThenBy(xy => xy.Y)
            .ToList();

        var currentRangeToMerge = 0;

        do
        {
            if(currentRangeToMerge == ranges.Count) break;
	
            var xy1 = ranges[currentRangeToMerge];
	
            for(var i = 0; i < ranges.Count; i++)
            {
                if(xy1.Removed) break;
                if(i == currentRangeToMerge) continue;
		
                var xy2 = ranges[i];
                if(xy2.Removed) continue;
		
                // xy1 is within xy2
                if (xy1.X >= xy2.X && xy1.Y <= xy2.Y)
                {
                    xy1.Removed = true;
                }
                // xy1 overlaps at the end of xy2
                if(xy1.X >= xy2.X && xy1.Y >= xy2.Y && xy1.X <= xy2.Y)
                {
                    xy2.Y = xy1.Y;
                    xy1.Removed = true;
                }
                // xy1 overlaps at the start of xy2
                if(xy1.X < xy2.X && xy1.Y >= xy2.X && xy1.Y <= xy2.Y)
                {
                    xy2.X = xy1.X;
                    xy1.Removed = true;
                }
            }

            currentRangeToMerge++;

        } while (true);


        var answer = ranges.Where(r => !r.Removed)
                           .Select(r => r.Y+1 - r.X)
                           .Sum();
        
        sw.Stop();
        Console.WriteLine($"Day 5 Part 2 Answer: {answer.ToString(),-20}{sw.Elapsed}");

    }
    
    private class Range2
    {
        public Range2(string x, string y)
        {
            X = long.Parse(x);
            Y = long.Parse(y);
        }
        public long X { get; set; }
        public long Y { get; set; }
        public bool Removed { get; set; }
    }
}