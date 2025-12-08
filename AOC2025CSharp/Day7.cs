using System.Diagnostics;

namespace AOC2025CSharp;

public static class Day7
{
    private const string InputFile = "/home/stuart/Source/AOC2025CSharp/AOC2025CSharp/Inputs/day7";
    public static void Part1()
    {
        var sw = new Stopwatch();
        sw.Start();
        
        var manifold = File.ReadAllLines(InputFile);
        List<int> beams = []; // can this just be X locations ? And keep track of Xs as we go over each row ?
        int initialBeam = manifold[0].IndexOf("S", StringComparison.Ordinal);
        beams.Add(initialBeam);
        int splits = 0;
        
        foreach (var row in manifold)
        {
            List<int> newBeams = [];
            foreach (var beam in beams)
            {
                // if beam location on this row is a ^, remove that beam and add two beams, one at X-1 and one at X+1
                // keep track of beams to remove, and beams to add.
                if (row[beam] == '^')
                {
                    splits++;
                    newBeams.Add(beam+1);
                    newBeams.Add(beam-1);
                }
                else
                {
                    newBeams.Add(beam);
                }
            }
            beams = newBeams.Distinct().ToList();
        }
        
        var answer = beams.Count;
        
        sw.Stop();
        
        Console.WriteLine($"Day 7 Part 1 Answer: {splits.ToString(),-20}{sw.Elapsed}");
    }
    
    public static void Part2()
    {
        var sw = new Stopwatch();
        sw.Start();

        var fileContents = File.ReadAllText(InputFile);
        var answer = 0;
        
        sw.Stop();
        
        Console.WriteLine($"Day 7 Part 2 Answer: {answer.ToString(),-20}{sw.Elapsed}");
    }

    // private class Beam
    // {
    //     public int X { get; set; }
    //     public bool Removed { get; set; }
    // }
}
