namespace AoC2024;
public class AoC {
    public static void Main(string[] args) {
        Day1(File.ReadAllText("AoC2024/inputs/day1.txt"));
        Day2(File.ReadAllText("AoC2024/inputs/day2.txt"));
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
    public static void Day2(string input) {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nAdvent of Code 2024 - Day 2");

        string[] reports = input.Split('\n');
        int safe_reports = 0;
        List<int[]> all_reports = [];

        static bool is_safe(int[] report) {
            int _safety = 0;
            for (int i = 1; i < report.Length; i++) {
                if (report[i-1] < report[i] && (report[i] - report[i-1]) <= 3)
                    _safety++;
                else if (report[i-1] > report[i] && (report[i-1] - report[i]) <= 3)
                    _safety--;
            }
            return report.Length - 1 == Math.Abs(_safety);
        }

        foreach (string report in reports) {
            List<int> levels = [];
            foreach (string level in report.Split(' ')) 
                levels.Add(int.Parse(level));

            all_reports.Add([.. levels]);
            if (is_safe([.. levels]))
                safe_reports++;
        }

        Console.WriteLine($"Part 1:  {safe_reports}");
        
        safe_reports = 0;
        
        foreach (int[] report in all_reports) {
            if (is_safe(report))
                safe_reports++;
            else {
                for (int i = 0; i < report.Length; i++) {
                    List<int> new_report = [.. report];
                    new_report.RemoveAt(i);
                    if (is_safe([.. new_report])) {
                        safe_reports++;
                        break;
                    }
                }
            }
        }
        
        Console.WriteLine($"Part 2:  {safe_reports}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}