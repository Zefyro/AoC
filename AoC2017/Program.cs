namespace AoC2017;
public class AoC {
    public static void Main() {
        Day1(File.ReadAllText("AoC2017/inputs/day1.txt"));
    }
    public static void Day1(string input) {
        Console.WriteLine("\nAdvent Of Code 2017 - Day 1");
        Console.ForegroundColor = ConsoleColor.DarkGreen;

        int sum_one = 0, sum_two = 0, pos = 0;

        foreach (char c in input) {
            if (c == input[(pos + 1) % input.Length])
                sum_one += int.Parse(c.ToString());
            if (c == input[(pos + input.Length / 2) % input.Length])
                sum_two += int.Parse(c.ToString());
            pos++;
        }

        Console.WriteLine($"Part 1: {sum_one}");
        Console.WriteLine($"Part 2: {sum_two}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}