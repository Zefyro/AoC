namespace AoC;
public class AoC2024 {
    public static void Main(string[] args) {
        Day1(File.ReadAllText("inputs/day1.txt"));
        Day2(File.ReadAllText("inputs/day2.txt"));
        //Day3(File.ReadAllText("inputs/day3.txt"));
    }
    public static void Day1(string input) {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nAdvent of Code 2024 - Day 1");
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
        Console.WriteLine($"Part 2: {similarity}");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void Day2(string input) {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nAdvent of Code 2024 - Day 2");

        string[] reports = input.Split('\n');
        int safe_reports = 0;

        List<int[]> all_reports = [];
        foreach (string report in reports) {
            List<int> levels = [];
            foreach (string level in report.Split(' ')) 
                levels.Add(int.Parse(level));

            all_reports.Add([.. levels]);
            if (HelperMethods.Day2_IsSafe([.. levels]))
                safe_reports++;
        }

        Console.WriteLine($"Part 1:  {safe_reports}");
        
        safe_reports = 0;
        
        foreach (int[] report in all_reports) {
            if (HelperMethods.Day2_IsSafe(report))
                safe_reports++;
            else {
                for (int i = 0; i < report.Length; i++) {
                    List<int> new_report = [.. report];
                    new_report.RemoveAt(i);
                    if (HelperMethods.Day2_IsSafe([.. new_report])) {
                        safe_reports++;
                        break;
                    }
                }
            }
        }
        
        Console.WriteLine($"Part 2:  {safe_reports}");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void Day3(string input) {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nAdvent of Code 2024 - Day 2");
        
        Console.ForegroundColor = ConsoleColor.White;
    }
}