using System;

class Program
{
    static void Main()
    {
        double investment, monthlyReturn, capital, interest, total;
        int months;
        double usdToInr = 85.0;

        Console.Write("Enter initial investment (USD): ");
        investment = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter monthly return percentage: ");
        monthlyReturn = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter number of months: ");
        months = Convert.ToInt32(Console.ReadLine());

        capital = investment;

        Console.WriteLine();
        Console.WriteLine("\tMonth\t\tCapital\t\t\tInterest\t\tTotal Value");
        Console.WriteLine("\t\t(USD / ₹)\t\t\t(USD / ₹)\t\t(USD / ₹)");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");

        for (int i = 1; i <= months; i++)
        {
            interest = capital * (monthlyReturn / 100.0);
            total = capital + interest;

            Console.WriteLine($"\tMonth {i}\t|\t${capital:F2} / ₹{capital * usdToInr:F2}\t|\t${interest:F2} / ₹{interest * usdToInr:F2}\t|\t${total:F2} / ₹{total * usdToInr:F2}");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

            capital = total;
        }
    }
}


///V1
///V2
///V3
