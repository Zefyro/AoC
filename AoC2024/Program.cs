namespace AoC2024;
public class AoC {
    public static void Main() {
        Day1(File.ReadAllText("AoC2024/inputs/day1.txt"));
        Day2(File.ReadAllText("AoC2024/inputs/day2.txt"));
        Day3(File.ReadAllText("AoC2024/inputs/day3.txt"));
        Day4(File.ReadAllText("AoC2024/inputs/day4.txt"));
    }
    public static void Day1(string input) {
        Console.WriteLine("\nAdvent of Code 2024 - Day 1");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
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
        Console.WriteLine("\nAdvent of Code 2024 - Day 2");
        Console.ForegroundColor = ConsoleColor.DarkGreen;

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

        Console.WriteLine($"Part 1: {safe_reports}");
        
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
        
        Console.WriteLine($"Part 2: {safe_reports}");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void Day3(string input) {
        Console.WriteLine("\nAdvent of Code 2024 - Day 3");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        
        string _text = input;
        int _position = 0;
        int total_product = 0;
        char peek(int offset) => (_position + offset >= _text.Length) ? '\0' : _text[_position + offset];
        bool is_mul() => peek(0) == 'm' && peek(1) == 'u' && peek(2) == 'l';

        while (true) {
            if (peek(0) == '\0') break;
            else if (is_mul()) {
                _position += 3;
                if (peek(0) == '(') {
                    int start = _position + 1;

                    for (int i = 1; i <= 8; i++)
                        if (peek(i) == ')') {
                            _position += i;
                            string[] num = _text[start.._position].Split(',');
                            if (num.Length == 2)
                                total_product += int.Parse(num[0]) * int.Parse(num[1]);
                            break;
                        }
                }
            }
            _position++;
        }

        Console.WriteLine($"Part 1: {total_product}");

        _position = 0;
        total_product = 0;
        bool enabled = true;
        bool is_do() => peek(0) == 'd' && peek(1) == 'o' && peek(2) == '(' && peek(3) == ')';
        bool is_dont() => peek(0) == 'd' && peek(1) == 'o' && peek(2) == 'n' 
            && peek(3) == '\'' && peek(4) == 't' && peek(5) == '(' && peek(6) == ')';

        while (true) {
            if (peek(0) == '\0') break;
            else if (is_do()) enabled = true;
            else if (is_dont()) enabled = false;
            else if (is_mul() && enabled) {
                _position += 3;
                if (peek(0) == '(') {
                    int start = _position + 1;

                    for (int i = 1; i <= 8; i++)
                        if (peek(i) == ')') {
                            _position += i;
                            string[] num = _text[start.._position].Split(',');
                            if (num.Length == 2)
                                total_product += int.Parse(num[0]) * int.Parse(num[1]);
                            break;
                        }
                }
            }
            _position++;
        }

        Console.WriteLine($"Part 2: {total_product}");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void Day4(string input) {
        Console.WriteLine("\nAdvent of Code 2024 - Day 4");
        Console.ForegroundColor = ConsoleColor.DarkGreen;

        string[] lines = input.Split('\n');
        int total = 0;
        int[][] dirs = [[-1, -1], [-1, 0], [-1, 1], [0, -1], [0, 1], [1, -1], [1, 0], [1, 1]];
        char get_char(int x, int y) => x < 0 || y < 0 || x >= lines.Length || y >= lines[x].Length ? '\0' : lines[x][y];

        for (int x = 0; x < lines.Length; x++)
            for (int y = 0; y < lines[x].Length; y++) 
                if (lines[x][y] == 'X')
                    foreach (int[] dir in dirs) {
                        bool valid = true;
                        for (int i = 1; i <= 3; i++)
                            if (get_char(x+i*dir[0], y+i*dir[1]) != "XMAS"[i])
                                valid = false;
                        if (valid) total++;
                    }

        Console.WriteLine($"Part 1: {total}");

        total = 0;
        dirs = [[-1, -1], [-1, 1], [1, 1], [1, -1]]; 

        for (int x = 0; x < lines.Length; x++)
            for (int y = 0; y < lines[x].Length; y++) 
                if (lines[x][y] == 'A') {
                    if (get_char(x+dirs[0][0], y+dirs[0][1]) == 'M' &&
                        get_char(x+dirs[1][0], y+dirs[1][1]) == 'M' &&
                        get_char(x+dirs[2][0], y+dirs[2][1]) == 'S' &&
                        get_char(x+dirs[3][0], y+dirs[3][1]) == 'S') total++;
                    
                    if (get_char(x+dirs[0][0], y+dirs[0][1]) == 'S' &&
                        get_char(x+dirs[1][0], y+dirs[1][1]) == 'M' &&
                        get_char(x+dirs[2][0], y+dirs[2][1]) == 'M' &&
                        get_char(x+dirs[3][0], y+dirs[3][1]) == 'S') total++;

                    if (get_char(x+dirs[0][0], y+dirs[0][1]) == 'S' &&
                        get_char(x+dirs[1][0], y+dirs[1][1]) == 'S' &&
                        get_char(x+dirs[2][0], y+dirs[2][1]) == 'M' &&
                        get_char(x+dirs[3][0], y+dirs[3][1]) == 'M') total++;

                    if (get_char(x+dirs[0][0], y+dirs[0][1]) == 'M' &&
                        get_char(x+dirs[1][0], y+dirs[1][1]) == 'S' &&
                        get_char(x+dirs[2][0], y+dirs[2][1]) == 'S' &&
                        get_char(x+dirs[3][0], y+dirs[3][1]) == 'M') total++;
                }

        Console.WriteLine($"Part 2: {total}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}