using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringDemo
{
    public class Customer
    {
        private string name;
        private List<Rental> rentals = new List<Rental>();

        public Customer(string name)
        {
            this.name = name;
        }

        public void AddRental(Rental arg)
        {
            rentals.Add(arg);
        }

        public string GetName()
        {
            return name;
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + GetName() + "\n";

            foreach (Rental each in rentals)
            {
                double thisAmount = 0;

                // determine amounts for each line
                switch (each.GetMovie().GetPriceCode())
                {
                    case Movie.PriceCode.REGULAR:
                        thisAmount += 2;
                        if (each.GetDaysRented() > 2)
                            thisAmount += (each.GetDaysRented() - 2) * 1.5;
                        break;
                    case Movie.PriceCode.NEW_RELEASE:
                        thisAmount += each.GetDaysRented() * 3;
                        break;
                    case Movie.PriceCode.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.GetDaysRented() > 3)
                            thisAmount += (each.GetDaysRented() - 3) * 1.5;
                        break;
                }

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((each.GetMovie().GetPriceCode() == Movie.PriceCode.NEW_RELEASE) &&
                    each.GetDaysRented() > 1) frequentRenterPoints++;

                // show figures for this rental
                result += "\t" + each.GetMovie().GetTitle() + "\t" +
                          thisAmount + "\n";
                totalAmount += thisAmount;
            }
            // add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }
    }
}
