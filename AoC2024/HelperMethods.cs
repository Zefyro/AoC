namespace AoC2024;
public static class HelperMethods
{
    public static bool Day2_IsSafe(int[] report) {
        int _safety = 0;
        for (int i = 1; i < report.Length; i++) {
            if (report[i-1] < report[i] && (report[i] - report[i-1]) <= 3)
                _safety++;
            else if (report[i-1] > report[i] && (report[i-1] - report[i]) <= 3)
                _safety--;
        }
        return report.Length - 1 == Math.Abs(_safety);
    }
}
