using System;

namespace Calculator_Revisited;

class Program
{
    static void Main()
    {
        // We want to endlessly repeat the whole program ...
        while (true)
        {
            // Ask the user how many numbers they want to enter.
            int count = ReadCount();

            // Read in the numbers, that were specified by the user
            float[] numbers = ReadNumbers(count);

            // Ask the user which operation should be performed.
            string operation = ReadOperation();

            // Perform the calculations
            float result = Calculate(numbers, operation);

            // Print the results of the calculations
            PrintResult(result);
        }
    }

    // Reads the number of values the user wants to enter.
    static int ReadCount()
    {
        while (true)
        {
            // Ask the user how many numbers they want to enter.
            Console.Write("How many numbers do you want to enter? ");

            // Sanity check.
            if (int.TryParse(Console.ReadLine(), out int count) && count > 0)
                return count;

            //If the number is not useable as previously checked..
            //The user is prompted to enter a number greater than 0
            Console.WriteLine("Please enter a number > 0.");
        }
    }

    // Reads the numbers in a loop and returns them in an array
    static float[] ReadNumbers(int count)
    {
        float[] numbers = new float[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Number #{i + 1}: ");

            // Sanity check again
            while (!float.TryParse(Console.ReadLine(), out numbers[i]))
            {
                Console.Write("Invalid number, try again: ");
            }
        }

        return numbers;
    }

    // Asks the user for the operation they want to use
    //Allowed operations are only "+" "-" "*"
    //repeats if invalide input
    static string ReadOperation()
    {
        string operation = "";

        // If the user enters an not useable operation we ask again.
        do
        {
            Console.Write("Which operation should be performed (+, -, *)? ");
            operation = Console.ReadLine();
        }
        while (operation != "+" && operation != "-" && operation != "*");

        return operation;
    }

    // Performs the calculation using the first number as initial value.
    static float Calculate(float[] numbers, string operation)
    {
        // For the initial value of our result, we simply use
        // the first number the user has entered.
        float result = numbers[0];

        //The chosen operation is applied to all numbers entered by the user
        for (int i = 1; i < numbers.Length; i++)
        {
            switch (operation)
            {
                case "+":
                    result += numbers[i];
                    break;
                case "-":
                    result -= numbers[i];
                    break;
                case "*":
                    result *= numbers[i];
                    break;
            }
        }

        return result;
    }

    // Prints the final result.
    static void PrintResult(float result)
    {
        //Output of the final result on the console
        Console.WriteLine($"Result: {result}");
    }
}