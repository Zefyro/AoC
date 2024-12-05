namespace AoC2016;
public class AoC {
    public static void Main() {
        Day1(File.ReadAllText("AoC2016/inputs/day1.txt"));
    }
    public static void Day1(string input) {
        Console.WriteLine("\nAdvent Of Code 2016 - Day 1");
        Console.ForegroundColor = ConsoleColor.DarkGreen;

        string[] instructions = input.Split(", ");
        char[] directions = ['N', 'E', 'S', 'W'];
        List<(int x, int y)> visited_locations = [(0, 0)];
        (int x, int y) = (0, 0);
        (int rx, int ry) = (0, 0);
        bool revisited = false;
        int dir = 0;

        foreach (string step in instructions) {
            dir = ((dir + (step[0] == 'R' ? 1 : -1)) % directions.Length + 4) % directions.Length;

            for (int blocks = int.Parse(step[1..]); blocks > 0; blocks--) {
                if (directions[dir] == 'N')
                    y += 1;
                else if (directions[dir] == 'E')
                    x += 1;
                else if (directions[dir] == 'S')
                    y -= 1;
                else if (directions[dir] == 'W')
                    x -= 1;
                
                if (visited_locations.Contains((x, y)) && !revisited) {
                    revisited = true;
                    (rx, ry) = (x, y);
                }
                visited_locations.Add((x, y));
            }
        }
        int manhattan_distance = Math.Abs(x) + Math.Abs(y);
        int revisited_manhattan_distance = Math.Abs(rx) + Math.Abs(ry);

        Console.WriteLine($"Part 1: {manhattan_distance}");
        Console.WriteLine($"Part 2: {revisited_manhattan_distance}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}