using AOC2025CSharp;

namespace Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Day3Tests()
    {
        List<int> input = [9,8,7,6,5,4,3,2,1,1,1,1,1,1,1];
        var res = Day3.GetBiggest1(input);
        Assert.That(res[0] == 9);
        Assert.That(res[1] == 8);
        
        input = [8,1,1,1,1,1,1,1,1,1,1,1,1,1,9];
        res = Day3.GetBiggest1(input);
        Assert.That(res[0] == 8);
        Assert.That(res[1] == 9);
        
        input = [2,3,4,2,3,4,2,3,4,2,3,4,2,7,8];
        res = Day3.GetBiggest1(input);
        Assert.That(res[0] == 7);
        Assert.That(res[1] == 8);
        
        input = [8,1,8,1,8,1,9,1,1,1,1,2,1,1,1];
        res = Day3.GetBiggest1(input);
        Assert.That(res[0] == 9);
        Assert.That(res[1] == 2);
    }
}