using System;

namespace SplitBillLib
{
    public class TestTipPerPerson
    {
        public decimal TipPerPerson(decimal price, int numberOfPatrons, float tipPercentage)
        {
            if (numberOfPatrons <= 0)
                throw new ArgumentException("Number of patrons must be greater than zero.");

            if (tipPercentage < 0 || tipPercentage > 100)
                throw new ArgumentException("Tip percentage must be between 0 and 100.");

            decimal totalTip = price * ((decimal)tipPercentage / 100); // Explicitly convert tipPercentage to decimal
            return totalTip / numberOfPatrons;
        }
    }
}
