using System;

namespace RefactoringDemo
{
    public enum PriceCode
    {
        Regular = 0,
        NewRelease = 1,
        Childrens = 2
    }

    static internal class RentalRules
    {
        struct RentalRulesEntry
        {
            internal RentalRulesEntry(PriceCode priceCode, Func<int, double> determineAmount)
                : this()
            {
                this.PriceCodede = priceCode;
                this.DetermineAmountFunction = determineAmount;
            }

            public Func<int, double> DetermineAmountFunction { get; private set; }
            public PriceCode PriceCodede { internal get; set; }
        }

        private static RentalRulesEntry[] rentalRules;
        static RentalRules()
        {
            rentalRules = new RentalRulesEntry[3];
            rentalRules[(int)PriceCode.Regular] = new RentalRulesEntry(PriceCode.Regular, daysRented => daysRented > 2 ? 2 + (daysRented - 2) * 1.5 : 2);
            rentalRules[(int)PriceCode.NewRelease] = new RentalRulesEntry(PriceCode.NewRelease, daysRented1 => daysRented1 * 3);
            rentalRules[(int)PriceCode.Childrens] = new RentalRulesEntry(PriceCode.Childrens, daysRented => daysRented > 3 ? 1.5 + (daysRented - 3) * 1.5 : 1.5);
        }

        public static double DetermineAmount(int daysRented, Movie movie)
        {
            return rentalRules[(int)movie.GetPriceCode()].DetermineAmountFunction(daysRented);
        }

        public static int DetermineFrequentrenterPoints(int getDaysRented, Movie movie)
        {
            return EarnsBonus(getDaysRented, movie) ? 2 : 1;
        }

        private static bool EarnsBonus(int getDaysRented, Movie movie1)
        {
            return (movie1.GetPriceCode() == PriceCode.NewRelease) && getDaysRented > 1;
        }
    }
}