using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AOC2025CSharp;

public static class Day1
{
    public static void Part1()
    {
        var sw = new Stopwatch();
        sw.Start();
        
        const string inputFile = "/home/stuart/Source/AOC2025CSharp/AOC2025CSharp/Inputs/day1";

        var input = File.ReadAllLines(inputFile)
            .Select(l => (l[..1], int.Parse(l[1..])));
				
        var x = 50;
        var y  = 0;

        foreach(var (d, n) in input)
        {
            if(d == "R")
            {
                x = (x + n) % 100;
            }
            else
            {
                x = x - n;

                if (x <= 0)
                {
                    x %= 100;
			
                    x = 100 - -x;

                    if(x == 100)
                    {
                        x = 0;
                    }
                }
            }
	
            if(x == 0)
            {
                y++;
            }
        }
        
        sw.Stop();
        Console.WriteLine($"Day 1 Part 1 Answer: {y.ToString().PadRight(20)}{sw.Elapsed}");
    }
    
    public static void Part2()
    {
        var sw = new Stopwatch();
        sw.Start();
        
        const string inputFile = @"/home/stuart/Source/AOC2025CSharp/AOC2025CSharp/Inputs/day1";

        var input = File.ReadAllLines(inputFile)
            .Select(l => (l[..1], int.Parse(l[1..])));
				
        var x = 50;
        var y  = 0;

        foreach(var (d, n) in input)
        {
            if(d == "R")
            {
                for(var i = 0; i < n; i++)
                {
                    x++;
                    
                    if(x == 100) 
                    {
                        x = 0;
                        y++;
                    }
                }
            }
            else
            {
                for(var i = 0; i < n; i++)
                {
                    x--;
                    
                    if(x == 0)
                    {
                        y++;
                    }
                    if(x < 0)
                    {
                        x = 99;
                    }
                }
            } 

        }
        sw.Stop();
        Console.WriteLine($"Day 1 Part 1 Answer: {y.ToString().PadRight(20)}{sw.Elapsed}");
    }
}