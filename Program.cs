namespace Best_Time_to_Buy_and_Sell_Stock1;
using System;

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        if (prices == null || prices.Length < 2)
        {
            return 0;
        }

        int minPrice = prices[0];
        int maxProfit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            // Update minimum price if we find a lower price
            if (prices[i] < minPrice)
            {
                minPrice = prices[i];
            }
            // Update maximum profit if we can make more money selling today
            else if (prices[i] - minPrice > maxProfit)
            {
                maxProfit = prices[i] - minPrice;
            }
        }

        return maxProfit;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        Console.WriteLine("Welcome to Stock Profit Calculator!");
        Console.WriteLine("-----------------------------------");

        while (true)
        {
            Console.WriteLine("\nPlease enter the stock prices separated by spaces:");
            Console.WriteLine("(Example: 7 1 5 3 6 4)");

            string input = Console.ReadLine();

            try
            {
                // Split the input string and convert to integers
                string[] priceStrings = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] prices = Array.ConvertAll(priceStrings, int.Parse);

                if (prices.Length < 2)
                {
                    Console.WriteLine("Error: Please enter at least 2 prices.");
                    continue;
                }

                int result = solution.MaxProfit(prices);
                Console.WriteLine($"\nMaximum possible profit: {result}");

                Console.WriteLine("\nDo you want to calculate another set of prices? (yes/no)");
                string again = Console.ReadLine().ToLower();
                if (again != "yes" && again != "y")
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter valid numbers separated by spaces.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: Numbers are too large. Please enter smaller values.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        Console.WriteLine("\nThank you for using Stock Profit Calculator!");
    }
}