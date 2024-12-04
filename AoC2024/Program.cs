namespace AoC2024;
public class AoC {
    public static void Main(string[] args) {
        Day1(File.ReadAllText("AoC2024/inputs/day1.txt"));
    }
    public static void Day1(string input) {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nAdvent of Code 2024 - Day 1");
        string[] values = input.Split('\n');

        List<int> left = [], right = [];

        foreach (string value in values) {
            string[] pairs = value.Split("   ");
            left.Add(int.Parse(pairs[0]));
            right.Add(int.Parse(pairs[1]));
        }

        left.Sort();
        right.Sort();

        int sum = 0;
        for (int i = 0; i < left.Count; i++) {
            sum += Math.Abs(left[i] - right[i]);
        }

        Console.WriteLine($"Part 1: {sum}");

        int similarity = 0;
        foreach (int l in left)
            similarity += l * right.Count(x => x == l);

        Console.WriteLine($"Part 2: {similarity}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}