namespace SplitBillLib;

using System;
using System.Collections.Generic;

public class TestCalculateTip
{
    public Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
    {
        if (tipPercentage < 0 || tipPercentage > 100)
            throw new ArgumentException("Tip percentage must be between 0 and 100.");

        Dictionary<string, decimal> tipAmounts = new Dictionary<string, decimal>();

        decimal totalCost = 0;
        foreach (var kvp in mealCosts)
        {
            totalCost += kvp.Value;
        }

        foreach (var kvp in mealCosts)
        {
            decimal tip = (decimal)(tipPercentage / 100.0) * kvp.Value;
            tipAmounts.Add(kvp.Key, tip);
        }

        return tipAmounts;
    }
}
