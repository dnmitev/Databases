namespace ToyStore.Utilities.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRandomProvider
    {
        int GetRandomInt(int minValue, int maxValue);

        double GetRandomDouble(double minValue, double maxValue);

        string GetRandomString(int length);

        string GetRandomLengthString();

        string GetRandomStringOfNumbers(int length);

        string GetRandomLengthStringOfNumbers();

        ISet<string> GetUniqueRandomStringsSet(int listLength);

        ISet<int> GetUniqueRandomIntegersSet(int listLength, int minValue, int maxValue);

        DateTime GetRandomDate(int minimalYear);

        decimal GetRandomPrice(double minPrice, double maxPrice);

        int GetRandomPercent();
    }
}