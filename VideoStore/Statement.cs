using System.Collections.Generic;

namespace RefactoringDemo
{
    public class Statement
    {
        private string name;
        private int frequentRenterPoints;
        private List<Rental> rentals = new List<Rental>();

        public Statement(string name)
        {
            this.name = name;
        }

        public double TotalAmount { get; private set; }

        public int FrequentRenterPoints
        {
            get { return frequentRenterPoints; }
        }

        public void AddRental(Rental arg)
        {
            rentals.Add(arg);
        }

        public string Generate()
        {
            CalculateTotals();
            var result = FormatHeader();
            result += FormatRentalLines();
            result += FormatFooter();
            return result;
        }

        public void CalculateTotals()
        {
            ClearTotals();
            foreach (Rental rental in rentals)
            {
                TotalAmount += rental.DetermineAmount();
                this.frequentRenterPoints += rental.DetermineFrequentRentalPoints();
            }
        }

        private void ClearTotals()
        {
            TotalAmount = 0;
            frequentRenterPoints = 0;
        }

        private string FormatHeader()
        {
            return string.Format("Rental Record for {0}\n", name);
        }

        private string FormatRentalLines()
        {
            string rentalLines = string.Empty;
            foreach (Rental rental in rentals)
            {
                rentalLines += FormatRentalLine(rental);
            }
            return rentalLines;
        }

        private static string FormatRentalLine(Rental rental)
        {
            return string.Format("\t{0}\t{1}\n", rental.Title, rental.DetermineAmount());
        }

        private string FormatFooter()
        {
            return string.Format("Amount owed is {0}\n" + "You earned {1} frequent renter points", TotalAmount,
                                 frequentRenterPoints);
        }
    }
}
