namespace AoC2022;
public class AoC {
    public static void Main() {
        Day1(File.ReadAllText("AoC2022/inputs/day1.txt"));
    }
    public static void Day1(string input) {
        Console.WriteLine("\nAdvent of Code 2022 - Day 1");
        Console.ForegroundColor = ConsoleColor.DarkGreen;

        int[][] elfs = [.. input.Replace("\r\n", "\n").Split("\n\n").Select(elf => elf.Split('\n').Select(int.Parse).ToArray())];
        List<int> total_calories = [];

        foreach(int[] calories in elfs) {
            int cal = 0;
            foreach (int c in calories)
                cal += c;
            total_calories.Add(cal);
        }

        total_calories.Sort();
        int most_calories = total_calories[^1];
        int top_three = total_calories[^1] + total_calories[^2] + total_calories[^3];

        Console.WriteLine($"Part 1: {most_calories}");
        Console.WriteLine($"Part 2: {top_three}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}

