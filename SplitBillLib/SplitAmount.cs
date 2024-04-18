
namespace SplitBillLib;

public class PaymentCalculator
{
    public object CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
    {
        throw new NotImplementedException();
    }

    public decimal SplitAmount(decimal totalAmount, int numberOfPeople)
    {
        if (numberOfPeople <= 0)
            throw new ArgumentException("Number of people must be greater than zero.");

        return totalAmount / numberOfPeople;
    }
}

