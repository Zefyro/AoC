namespace AoC2015;
public class AoC {
    public static void Main(string[] args) {
        Day1(File.ReadAllText("AoC2015/inputs/day1.txt"));
        //Day2(File.ReadAllText("AoC2015/inputs/day2.txt"));
        //Day3(File.ReadAllText("AoC2015/inputs/day3.txt"));
    }
    public static void Day1(string input) {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nAdvent of Code 2015 - Day 1");
        
        int floor = 0;
        int basement_step = 0;
        bool visited_basement = false;
        
        for (int i = 0; i < input.Length; i++) {
            if (input[i] == '(') 
                floor++;
            else if (input[i] == ')')
                floor--;
            if (!visited_basement && floor == -1) {
                basement_step = i + 1;
                visited_basement = true;
            }
        }
        
        Console.WriteLine($"Part 1:  {floor}");
        Console.WriteLine($"Part 2:  {basement_step}");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void Day2(string input) {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nAdvent of Code 2015 - Day 2");
        
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void Day3(string input) {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nAdvent of Code 2015 - Day 3");
        
        Console.ForegroundColor = ConsoleColor.White;
    }
}