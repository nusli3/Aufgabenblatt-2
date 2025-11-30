namespace Array_Linrary;

public class IntArrayTools
{
    //Calculates the average of all values in the array
    //The result is float, because the average of integers can be a decimal number
    public static float Average(int[] array)
    {
        int sum = 0;

        //Adds all numbers together
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        //Convert sum to float to avoid integer division
        return (float)sum / array.Length;
    }

    //Finds and returns the smallest value in the array
    public static int Min(int[] array)
    {
        int smallest = array[0];

        //Assume the first number is the smallest
        //Compare every other number in the array with it
        //If we find a smaller number, replace it and contine
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < smallest)
                smallest = array[i];
        }

        return smallest;
    }

    // Finds and returns the largest value in the array.
    public static int Max(int[] array)
    {
        int largest = array[0];


        //Assume the first number is the biggest
        //Compare every other number in the array with it
        //If we find a bigger number, replace it and contine
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > largest)
                largest = array[i];
        }

        return largest;
    }

    //Joining togather two arrays and returning a new array containing all numbers
    
    public static int[] Togather(int[] array1, int[] array2)
    {
        //New array with enough place for both existing array
        int[] result = new int[array1.Length + array2.Length];

        //Copy the first array into the new one
        for (int i = 0; i < array1.Length; i++)
        {
            result[i] = array1[i];
        }

        //Now copy the second one into the new array
        for (int i = 0; i < array2.Length; i++)
        {
            result[array1.Length + i] = array2[i];
        }

        return result;
    }

    //Create/Build a new array with the numbbers reversed
    //The input array cannot be modified
    //Create/Build new array and fill in the numbers from the back so that the numbers are reversed
    public static int[] Reverse(int[] array)
    {
        int[] reversed = new int[array.Length];

        
        //Fill the new array by taking the numbers from the end
        for (int i = 0; i < array.Length; i++)
        {
            reversed[i] = array[array.Length - 1 - i];
        }

        return reversed;
    }
}



class Program
{
    static void Main()
    {
        //Test arrays used to demonstrate the diferent tools
        int[] a = { 10, 3, 4, 9 };
        int[] b = { 15, 35, 2 };

        Console.WriteLine("Testing in process, don't quit programm");

        //Test for the Average methode
        Console.WriteLine($"Average of a: {IntArrayTools.Average(a)}");

        //Test for the Min methode
        Console.WriteLine($"Min of a: {IntArrayTools.Min(a)}");

        //Test for the Max method
        Console.WriteLine($"Max of a: {IntArrayTools.Max(a)}");

        //Test for the Togather methode
        int[] concat = IntArrayTools.Togather(a, b);
        Console.Write("Concat(a, b): ");

        //Printing the array directly here
        Console.WriteLine("{ " + string.Join(", ", concat) + " }");

        //Test fotr the Reverse method.
        int[] reversed = IntArrayTools.Reverse(a);
        Console.Write("Reverse(a): ");

        //Printibg the array directly here
        Console.WriteLine("{ " + string.Join(", ", reversed) + " }");

        Console.WriteLine("\nAll tests complete.");
    }
}