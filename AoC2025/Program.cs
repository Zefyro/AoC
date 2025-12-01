namespace AoC2025;

public class AoC
{
    public static void Main()
    {
        Day1(File.ReadAllText("./inputs/day1.txt"));
    }
    public static void Day1(string input)
    {
        Console.WriteLine("\nAdvent of Code 2025 - Day 1");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        string[] values = input.Split('\n');

        int dial = 50;
        int zeros = 0;
        foreach (string value in values)
        {
            int parsed = int.Parse(value[1..]);
            dial += value.StartsWith('L') ? -parsed : parsed;

            for (; dial < 0;)
            {
                dial += 100;
                parsed -= 100;
            }
            dial %= 100;

            if (dial == 0) zeros++;
        }

        Console.WriteLine($"Part 1: {zeros}");

        dial = 50;
        zeros = 0;
        foreach (string value in values)
        {
            int parsed = int.Parse(value[1..]);
            int rotate = value.StartsWith('L') ? -1 : 1;
            for (; parsed > 0; parsed--)
            {
                dial += rotate;
                if (dial > 99) dial = 0;
                if (dial == 0) zeros++;
                if (dial < 0) dial = 99;
            }
        }

        Console.WriteLine($"Part 2: {zeros}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}