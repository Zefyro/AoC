namespace AoC2022;
public class AoC {
    public static void Main() {
        Day1(File.ReadAllText("AoC2022/inputs/day1.txt"));
    }
    public static void Day1(string input) {
        Console.WriteLine("\nAdvent of Code 2022 - Day 1");
        Console.ForegroundColor = ConsoleColor.DarkGreen;

        List<int> totals = [.. input.Replace(Environment.NewLine, "\n").Split("\n\n").Select(x => x.Split('\n').Select(int.Parse).Sum()).OrderByDescending(x => x)];

        int most_calories = totals[0];
        int top_three = totals[0] + totals[1] + totals[2];

        Console.WriteLine($"Part 1: {most_calories}");
        Console.WriteLine($"Part 2: {top_three}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}

