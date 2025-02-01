using System;

class PalindromeChecker
{
    static void Main()
    {
        Console.WriteLine("Please enter your word");
        string input = Console.ReadLine();
        Console.WriteLine(sPalindrome(input));
    }

    static bool sPalindrome(string text)
    {
        if (string.IsNullOrEmpty(text)) return false;
        
            char[] splittedInput = text.ToCharArray();
            Array.Reverse(splittedInput);
            string reversedString = new string(splittedInput);
            return text.Equals(reversedString);
    }
}