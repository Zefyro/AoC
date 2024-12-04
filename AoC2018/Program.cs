namespace AoC2018;
public class AoC {
    public static void Main(string[] args) {
        Day1(File.ReadAllText("AoC2018/inputs/day1.txt"));
    }
    public static void Day1(string input) {
        Console.WriteLine("\nAdvent of Code 2018 - Day 1");
        Console.ForegroundColor = ConsoleColor.DarkGreen;

        string[] changes = input.Split('\n');
        int frequency = 0;
        List<int> frequencies = [];

        static int calc(string change) => change[0] == '-' ? -int.Parse(change[1..]) : int.Parse(change[1..]);

        foreach (string change in changes)
            frequency += calc(change);

        Console.WriteLine($"Part 1: {frequency}");

        frequency = 0;
        int duplicate = 0;
        bool has_duplicate = false;

        while (true) {
            foreach (string change in changes) {
                frequency += calc(change);
                if (frequencies.Contains(frequency) && !has_duplicate) {
                    has_duplicate = true;
                    duplicate = frequency;
                    break;
                }
                frequencies.Add(frequency);
            }
            if (has_duplicate) break;
        }

        Console.WriteLine($"Part 2: {duplicate}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}