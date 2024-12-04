namespace AoC2019;
public class AoC {
    public static void Main(string[] args) {
        Day1(File.ReadAllText("AoC2019/inputs/day1.txt"));
    }
    public static void Day1(string input) {
        Console.WriteLine("\nAdvent Of Code 2019 - Day 1");
        Console.ForegroundColor = ConsoleColor.DarkGreen;

        string[] modules = input.Split('\n');
        int total_fuel = 0;
        foreach (string fuel in modules)
            total_fuel += int.Parse(fuel) / 3 - 2;
        
        Console.WriteLine($"Part 1: {total_fuel}");

        total_fuel = 0;
        foreach (string fuel in modules) {
            int req_fuel = 0;
            int additional_fuel = int.Parse(fuel) / 3 - 2;
            while (additional_fuel > 0) {
                req_fuel += additional_fuel;
                additional_fuel = additional_fuel / 3 - 2;
            }
            total_fuel += req_fuel;
        }

        Console.WriteLine($"Part 2: {total_fuel}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}