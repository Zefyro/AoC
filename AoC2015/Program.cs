﻿namespace AoC2015;
public class AoC {
    public static void Main(string[] args) {
        Day1(File.ReadAllText("AoC2015/inputs/day1.txt"));
        Day2(File.ReadAllText("AoC2015/inputs/day2.txt"));
        Day3(File.ReadAllText("AoC2015/inputs/day3.txt"));
    }
    public static void Day1(string input) {
        Console.WriteLine("\nAdvent of Code 2015 - Day 1");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        
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
        Console.WriteLine("\nAdvent of Code 2015 - Day 2");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        
        string[] boxes = input.Split('\n');
        List<List<int>> box_dimensions = [];

        foreach (string box in boxes) {
            string[] dim = box.Split('x');
            List<int> dimensions = [int.Parse(dim[0]), int.Parse(dim[1]), int.Parse(dim[2])]; 
            box_dimensions.Add(dimensions);
        }

        int total_paper = 0;
        int total_ribbon = 0;

        foreach (List<int> box in box_dimensions) {
            int min_size = Math.Min(box[0]*box[1], box[1]*box[2]);
            min_size = Math.Min(min_size, box[2]*box[0]);
            total_paper += 2*box[0]*box[1] + 2*box[1]*box[2] + 2*box[2]*box[0] + min_size;

            int max_size = Math.Max(box[0], box[1]);
            max_size = Math.Max(max_size, box[2]);
            total_ribbon += box[0]*box[1]*box[2];
            box.Remove(max_size);
            total_ribbon += 2*box[0] + 2*box[1];
        }

        Console.WriteLine($"Part 1:  {total_paper}");
        Console.WriteLine($"Part 2:  {total_ribbon}");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void Day3(string input) {
        Console.WriteLine("\nAdvent of Code 2015 - Day 3");
        Console.ForegroundColor = ConsoleColor.DarkGreen;

        int houses_visited, x = 0, y = 0;
        HashSet<(int, int)> santa_visited = [];

        for (int i = 0; i < input.Length; i++) {
            (x, y) = input[i] switch {
                '^' => (x, y + 1),
                'v' => (x, y - 1),
                '>' => (x + 1, y),
                '<' => (x - 1, y),
                _ => (x, y)
            };
            santa_visited.Add((x, y));
        }
        houses_visited = santa_visited.Count;

        Console.WriteLine($"Part 1:  {houses_visited}");
        
        santa_visited.Clear();
        HashSet<(int, int)> robo_visited = [];
        x = 0; 
        y = 0;
        int sx = 0, sy = 0, rx = 0, ry = 0;
        bool is_santa = false;

        for (int i = 0; i < input.Length; i++) {
            is_santa = !is_santa;
            if (is_santa)
                (x, y) = (sx, sy);
            else
                (x, y) = (rx, ry);
            (x, y) = input[i] switch {
                '^' => (x, y + 1),
                'v' => (x, y - 1),
                '>' => (x + 1, y),
                '<' => (x - 1, y),
                _ => (x, y)
            };
            if (is_santa) {
                santa_visited.Add((x, y));
                (sx, sy) = (x, y);
            }
            else {
                robo_visited.Add((x, y));
                (rx, ry) = (x, y);
            }
        }
        santa_visited.UnionWith(robo_visited);
        houses_visited = santa_visited.Count;

        Console.WriteLine($"Part 2:  {houses_visited}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}