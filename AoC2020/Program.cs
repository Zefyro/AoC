namespace AoC2020;
public class AoC {
    public static void Main() {
        Day1(File.ReadAllText("AoC2020/inputs/day1.txt"));
    }
    public static void Day1(string input) {
        Console.WriteLine("\nAdvent Of Code 2020 - Day 1");
        Console.ForegroundColor = ConsoleColor.DarkGreen;

        int[] nums = [.. input.Split('\n').Select(int.Parse)];
        int product = 0;
        for (int i = 0; i < nums.Length; i++) {
            for (int j = 0; j < nums.Length; j++) {
                if (nums[i] + nums[j] == 2020) {
                    product = nums[i] * nums[j];
                    break;
                }
            }
            if (product != 0) break;
        }

        Console.WriteLine($"Part 1: {product}");

        product = 0;
        for (int i = 0; i < nums.Length; i++) {
            for (int j = 0; j < nums.Length; j++) {
                for (int k = 0; k < nums.Length; k++) {
                    if (nums[i] + nums[j] + nums[k] == 2020) {
                        product = nums[i] * nums[j] * nums[k];
                        break;
                    }
                }
                if (product != 0) break;
            }
            if (product != 0) break;
        }

        Console.WriteLine($"Part 2: {product}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}