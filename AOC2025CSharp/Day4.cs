using System.Diagnostics;

namespace AOC2025CSharp;

public static class Day4
{
    private const string InputFile = "/home/stuart/Source/AOC2025CSharp/AOC2025CSharp/Inputs/day4";
    
    public static void Part1()
    {
        var sw = new Stopwatch();
        sw.Start();

        var grid = File.ReadAllText(InputFile)
            .Split(Environment.NewLine)
            .Select(line => line.ToCharArray())
            .ToList();

        var answer = 0;

        for (var x = 0; x < grid.Count; x++)
        {
            for (var y = 0; y < grid[x].Length; y++)
            {
                if (grid[x][y] == '@')
                {
                    var accessible = IsAccessible(grid, x, y);
                    if (accessible)
                    {
                        answer++;
                    }
                }
            }
        }

        sw.Stop();
        Console.WriteLine($"Day 4 Part 1 Answer: {answer.ToString(),-20}{sw.Elapsed}");
    }

    private static bool IsAccessible(List<char[]> currentGrid, int x, int y)
    {
        var neighbourCount = 0;
        var neighbours = new List<Location>()
            {
                new() { X = x - 1, Y = y },
                new() { X = x + 1, Y = y },
                new() { X = x, Y = y - 1 },
                new() { X = x, Y = y + 1 },
                new() { X = x - 1, Y = y - 1 },
                new() { X = x + 1, Y = y + 1 },
                new() { X = x - 1, Y = y + 1 },
                new() { X = x + 1, Y = y - 1 },
            }
            .Where(xy => xy is { X: >= 0, Y: >= 0 })
            .Where(xy => xy.X < currentGrid.Count && xy.Y < currentGrid[xy.X].Length)
            .ToList();

        foreach (var neighbour in neighbours)
        {
            if (currentGrid[neighbour.X][neighbour.Y] == '@')
            {
                neighbourCount++;
            }
        }

        return neighbourCount < 4;
    }

    public static void Part2()
    {
        var sw = new Stopwatch();
        sw.Start();

        var input = File.ReadAllText(InputFile);

        var grid = input.Split(Environment.NewLine)
            .Select(line => line.ToCharArray())
            .ToList();

        var total = 0;
        int removed;
        List<Location> toRemove = [];

        do
        {
            removed = 0;
            for (var x = 0; x < grid.Count; x++)
            {
                for (var y = 0; y < grid[x].Length; y++)
                {
                    if (grid[x][y] == '@')
                    {
                        var accessible = IsAccessible(grid, x, y);
                        if (accessible)
                        {
                            total++;
                            removed++;
                            toRemove.Add(new Location { X = x, Y = y });
                        }
                    }
                }
            }

            if (removed > 0)
            {
                foreach (var location in toRemove)
                {
                    grid[location.X][location.Y] = '.';
                }
            }
        } while (removed > 0);

        sw.Stop();
        Console.WriteLine($"Day 4 Part 1 Answer: {total.ToString(),-20}{sw.Elapsed}");
    }

    private class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}