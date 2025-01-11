public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create an array that will contain the multiples. The length of the array = the "length" parameter of the function.
        // Step 2: Declare a variable called "index" that will be used to access the multiples array. It will be used to add items to the array.
        // if "number" is positive:
            // Step 3: Create a for loop that starts from the "number" parameter and increments (positive) or decreases (negative) in intervals of "number" up to "number*length". With this, for every iteration, i will always be a multiple of "number".
            //         For instance, if "number" = 3, then i = 3, in the first iteration, and 6 in the second, then 9 in the next, and so on.
            // Step 4: Add the current value of i to the "multiples" array. The "index" variable makes this possible. When index = 0, we are able to set the value of the first array item, then we increment it by 1 to access the next item, and so on.
            // Step 5: Return the multiples array.
        // if "number" is negative:
            // Repeat Steps 3 to 5
            // (in Step 3, i is decreasing in the condition statement for the loop, thus i must be greater than or equal to the last multiple.)

        var multiples = new double[length]; // Step 1
        int index = 0; // Step 2
        if (number >= 0)
        {
            for (double i = number; i <= length*number; i+=number) // Step 3
            {
                multiples[index++] = i; // Step4
            }

            return multiples; // Step 5
        }
        else
        {
            for (double i = number; i >= length*number; i+=number) // Step 3
            {
                multiples[index++] = i; // Step4
            }

            return multiples; // Step 5
        }
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Get the range of value items to be shifted using the GetRange method and store them in a variable. The amount provided in the function determines the range of items to get. For instance, if the amount specified is 1, we will select all the items except the last one. If the amount is 2, we select all except the last two, and so on.
        // Step 2: Remove the range that was selected in "Step 1" from the list.
        // Step 3: Append the items from "Step 1" to the resulting list.

        List<int> shiftedRange = data.GetRange(0, data.Count - amount); // Step 1
        data.RemoveRange(0, data.Count - amount); // Step 2
        data.AddRange(shiftedRange); // Step 3
    }
}
