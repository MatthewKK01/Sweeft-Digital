
class Program
{
   private  static bool IsProperly(string sequence)
    {
        var count = 0;

        foreach (var c in sequence)
        {
            if (c == '(')
            {
                count++;
            }
            else if (c == ')')
            {
                count--;
                if (count < 0) return false;
            }
        }

        return count == 0; 
    }

    public static void Main()
    {
        
        Console.WriteLine(IsProperly("(()())")); // true
        Console.WriteLine(IsProperly("())()"));  // false
        Console.WriteLine(IsProperly("((()))")); // true
        Console.WriteLine(IsProperly(")("));     // false
    }
}