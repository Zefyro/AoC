namespace AoC;
public class AoC2024 {
    public static void Main(string[] args) {
        string input = File.ReadAllText("E:\\GitHub\\misc\\AoC 2024\\inputs\\day1.txt");
        Day1(input);
    }
    public static void Day1(string input) {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\n\nAdvent of Code 2024 - Day 1");
        string[] values = input.Split('\n');
        
        List<string> list_left = [];
        List<string> list_right = [];

        foreach (string value in values) {
            string[] pairs = value.Split("   "); 
            list_left.Add(pairs[0]);
            list_right.Add(pairs[1]);
        }
        
        List<int> left = [];
        foreach (string value in list_left) {
            left.Add(int.Parse(value));
        }

        List<int> right = [];
        foreach (string value in list_right) {
            right.Add(int.Parse(value));
        }

        left.Sort();
        right.Sort();

        List<int> diffs = [];
        for (int i = 0; i < left.Count; i++) {
            diffs.Add(Math.Abs(left[i] - right[i]));
        }

        int sum = 0;
        foreach (int diff in diffs) {
            sum += diff;
        }
        Console.WriteLine($"Part 1: {sum}");

        int similarity = 0;
        foreach (int l in left)
            similarity += l * right.Count(x => x == l);
        Console.WriteLine($"Part 2: {similarity}\n\n");
        Console.ForegroundColor = ConsoleColor.White;
    }
}