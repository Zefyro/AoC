namespace AoC2023;
public class AoC {
    public static void Main() {
        Day1(File.ReadAllText("AoC2023/inputs/day1.txt"));
    }
    public static void Day1(string input) {
        Console.WriteLine("\nAdvent of Code 2023 - Day 1");
        Console.ForegroundColor = ConsoleColor.DarkGreen;

        string[] calibration_values = input.Split('\n');
        int sum = 0;

        foreach (string calibration_value in calibration_values) {
            string[] values = new string[2];
            bool has_first = false, has_last = false;
            for (int i = 0; i < calibration_value.Length; i++) {
                if (char.IsDigit(calibration_value[i]) && !has_first) {
                    has_first = true;
                    values[0] = calibration_value[i].ToString();
                }
                if (char.IsDigit(calibration_value[^(i + 1)]) && !has_last) {
                    has_last = true;
                    values[1] = calibration_value[^(i + 1)].ToString();
                }
            }
            sum += int.Parse(values[0] + values[1]);
        }

        Console.WriteLine($"Part 1: {sum}");

        sum = 0;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Part 2: {sum}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}

