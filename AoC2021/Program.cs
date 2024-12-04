namespace AoC2021;
public class AoC {
    public static void Main(string[] args) {
        Day1(File.ReadAllText("AoC2021/inputs/day1.txt"));
    }
    public static void Day1(string input) {
        Console.WriteLine("\nAdvent Of Code 2021 - Day 1");
        Console.ForegroundColor = ConsoleColor.DarkGreen;

        int[] nums = [.. input.Split('\n').Select(int.Parse)];
        int larger = 0;
        for (int i = 1; i < nums.Length; i++)
            if (nums[i-1] < nums[i])
                larger++;

        Console.WriteLine($"Part 1: {larger}");

        larger = 0;
        for (int i = 4; i < nums.Length; i++)
            if (nums[i-3] + nums[i-2] + nums[i-1] < nums[i-2] + nums[i-1] + nums[i])
                larger++;

        Console.WriteLine($"Part 2: {larger}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}