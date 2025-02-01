using System;

class GreedyCoins
{
    private static int MinSplit(int amount)
    {
        int[] coins = { 50, 20, 10, 5, 1 }; 
        var count = 0;

        foreach (var coin in coins)
        {
            count += amount / coin;
            amount %= coin; 
        }

        return count;
    }

    public static void Main()
    {
        Console.WriteLine("Please enter amount of money");
        var amount = int.Parse(Console.ReadLine());
        Console.WriteLine(MinSplit(amount));
        
    }
}