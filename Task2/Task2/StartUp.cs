Console.Write("Please enter your salary in gross value: ");
string input = Console.ReadLine();

decimal idr = 0;
decimal incomeTax = 0.9m;
decimal socialContributionsTax = 0.85m;
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
    else if (idr > lowTaxableAmount && idr <= highTaxableAmount)
    {
        idr *= incomeTax;

        if (idr > lowTaxableAmount)
        {
            idr *= socialContributionsTax;
        }

        Console.WriteLine($"Your net salary is {idr:F2} IDR");
    }
    else if (idr > 0)
    {
        idr *= incomeTax;

        if (idr <= highTaxableAmount)
        {
            idr *= socialContributionsTax;
        }

        Console.WriteLine($"Your net salary is {idr:F2} IDR");
    }
}
else
{
    Console.WriteLine("Please enter a valid salary input (a number).");
}

// Like incomeTax and socialContributionsTax we can add more taxes and check the
// necessary salary ranges for the calculations




