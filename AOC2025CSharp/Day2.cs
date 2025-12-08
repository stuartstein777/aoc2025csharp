using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace AOC2025CSharp;

public static class Day2
{
    public static void Part1()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        
        var inputFile = @"/home/stuart/Source/AOC2025CSharp/AOC2025CSharp/Inputs/day2";

        var res = File.ReadAllText(inputFile)
            .Split(",")
            .Select(x => x.Split("-").ToList())
            .Select(x => (X: double.Parse(x[0]), Y: double.Parse(x[1])));

        double ans = 0;

        foreach(var xs in res)
        {
            for(double i = xs.Item1; i <= xs.Item2; i++)
            {
                if(Filter1(i))
                {
                    ans += i;
                }
            }
        }
        sw.Stop();
        Console.WriteLine($"Day 2 Part 1 Answer: {ans.ToString().PadRight(20)}{sw.Elapsed}");
    }
    
    private static bool Filter1(double x)
    {
        var s = x.ToString();
        if(s.Length % 2 != 0) return false;
    
        var sp0 = s.Substring(0, s.Length / 2);
        var sp1 = s.Substring(s.Length / 2);
    
        if(sp0 == sp1)
        {
            return true;
        }
    
        return false;
    }
    
    public static void Part2()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        
        var inputFile = @"/home/stuart/Source/AOC2025CSharp/AOC2025CSharp/Inputs/day2";

        var res = File.ReadAllText(inputFile)
            .Split(",")
            .Select(x => x.Split("-").ToList())
            .Select(x => (X: double.Parse(x[0]), Y: double.Parse(x[1])));

        double ans = 0;

        foreach(var xs in res)
        {
            for(double i = xs.Item1; i <= xs.Item2; i++)
            {
                if(Filter2(i))
                {
                    ans += i;
                }
            }
        }

        sw.Stop();
        
        Console.WriteLine($"Day 2 Part 2 Answer: {ans.ToString().PadRight(20)}{sw.Elapsed}");
    }
    
    private static bool Filter2(double x)
    {
        var s = x.ToString(CultureInfo.InvariantCulture);
        
        var lim = s.Length /2+1;
    
        for(var i = 1; i < lim; i++)
        {
            var xs = s.Chunk(i).ToList();

            // Are all x in xs the same
            if(xs.All(y => y.SequenceEqual(xs.First())) && xs.Count() >= 2)
            {
                return true;
            }
        }
        return false;
    }

}

