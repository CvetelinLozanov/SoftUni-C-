using System;

namespace _11.Price_Change_Alert
{
    class PriceChangeAlert
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double threshold = double.Parse(Console.ReadLine());
            double last = double.Parse(Console.ReadLine());
            for (int i = 0; i < n - 1; i++)
            {
                double price = double.Parse(Console.ReadLine());
                double diff = Proc(last, price);
                bool isSignificantDifference = isDiff(diff, threshold);
                string message = Get(price, last, diff, isSignificantDifference);
                Console.WriteLine(message);
                last = price;
            }
        }

        private static string Get(double price, double last, double change, bool etherTrueOrFalse)

        {
            string result = "";
            if (change == 0)
            {
                result = string.Format("NO CHANGE: {0}", price);
            }
            else if (!etherTrueOrFalse)
            {
                result = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", last, price, change * 100);
            }
            else if (etherTrueOrFalse && (change > 0))
            {
                result = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", last, price, change * 100);
            }
            else if (etherTrueOrFalse && (change < 0))
                result = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", last, price, change * 100);
            return result;

        }



        private static bool isDiff(double threshold, double isDiff)
        {
            if (Math.Abs(threshold) >= isDiff)
            {
                return true;
            }
            return false;
        }



        private static double Proc(double last, double price)
        {
            double res = (price - last) / last;
            return res;
        }
    }
}