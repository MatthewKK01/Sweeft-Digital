using System;

class Program
{
   private static int CountVariants(int stairCount)
    {
        if (stairCount == 1) return 1;
        if (stairCount == 2) return 2;

        var prev1 = 2; // f(n-1)
        var prev2 = 1; // f(n-2)
        var current = 0;

        for (var i = 3; i <= stairCount; i++)
        {
            current = prev1 + prev2;
            prev2 = prev1;
            prev1 = current;
        }

        return current;
    }

   public static void Main()
    {
        Console.Write("Enter the number of steps: ");
        var n = int.Parse(Console.ReadLine());

        var result = CountVariants(n);
        Console.WriteLine(result);
    }
}