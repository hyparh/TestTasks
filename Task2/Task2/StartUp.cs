Console.Write("Please enter your salary in gross value: ");
string input = Console.ReadLine();

decimal idr = 0;
decimal allTaxes = 0;
decimal incomeTax = 0.1m;
decimal socialContributionsTax = 0.15m;
decimal lowTaxableAmount = 1000m;
decimal highTaxableAmount = 3000m;

if (decimal.TryParse(input, out idr))
{
    if (idr <= 0)
    {
        Console.WriteLine("Your salary cannot be zero or negative number.");
    }

    if (idr <= lowTaxableAmount && idr > 0)
    {
        Console.WriteLine($"Your net salary is {idr:F2} IDR");
    }
    else if (idr > lowTaxableAmount)
    {
        idr -= lowTaxableAmount;

        if (idr > lowTaxableAmount)
        {
            allTaxes = idr * incomeTax;
        }

        int firstDigit = Math.Abs((int)idr);

        while (firstDigit >= 10)
        {
            firstDigit /= 10;
        }

        string temp = firstDigit.ToString().PadRight(4, '0');
        decimal result = Int32.Parse(temp);

        if (result > lowTaxableAmount && result <= highTaxableAmount)
        {
            allTaxes += result * socialContributionsTax;
        }

        idr += lowTaxableAmount;
        idr -= allTaxes;

        Console.WriteLine($"Your net salary is {idr:F2} IDR");
    }
}
else
{
    Console.WriteLine("Please enter a valid salary input (a number).");
}

// Like incomeTax and socialContributionsTax we can add more taxes and check the
// necessary salary ranges for the calculations




