class Program
{
    private static int NotContains(int[] array)
    {
        var startNumber = 1;
        Array.Sort(array);
        foreach (var number in array)
        {
            if (number == startNumber)
            {
                startNumber++;
            }
        }

        return startNumber; 
    }
    
    public static void Main()
    {
        int[] myArr = { 1,2,3,5,4 };
        Console.WriteLine(NotContains(myArr));
    }
}