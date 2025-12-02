using System.Transactions;

namespace AoC2025;

public class AoC
{
    public static void Main()
    {
        //Day1(File.ReadAllText("./inputs/day1.txt"));
        Day2(File.ReadAllText("./inputs/day2.txt"));
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
    public static void Day2(string input)
    {
        Console.WriteLine("\nAdvent of Code 2025 - Day 2");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        string[] ranges = input.Split(',');

        long invalid_id_sum = 0;

        foreach (string range in ranges)
        {
            string[] values = range.Split('-');
            for (long id = long.Parse(values[0]); id < long.Parse(values[1]); id++)
            {
                string string_id = id.ToString();
                int half_length = string_id.Length / 2;
                if (string_id[..half_length] == string_id[half_length..]) invalid_id_sum += id;
            }
        }

        Console.WriteLine($"Part 1: {invalid_id_sum}");

        invalid_id_sum = 0;

        foreach (string range in ranges)
        {
            string[] values = range.Split('-');
            for (long id = long.Parse(values[0]); id < long.Parse(values[1]); id++)
            {
                string string_id = id.ToString();
                int half_length = string_id.Length / 2;
                if (string_id[..half_length] == string_id[half_length..])
                {
                    invalid_id_sum += id;
                    continue;
                }
                for (int length = 1; length < string_id.Length; length++)
                {
                    string substring = string_id[..length];
                    string temp = substring;
                    do
                    {
                        substring += temp;
                    }
                    while (string_id.Length > substring.Length);
                    if (string_id == substring)
                    {
                        invalid_id_sum += id;
                        break;
                    }
                }
            }
        }

        Console.WriteLine($"Part 2: {invalid_id_sum}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}