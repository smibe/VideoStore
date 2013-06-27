using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoStore
{
    public class Statement
    {
        private string name;
        private double totalAmount = 0;
        private int frequentRenterPoints = 0;
        private string statement;
        private List<Rental> rentals = new List<Rental>();


        public Statement(string name)
        {
            this.name = name;
        }

        public void AddRental(Rental arg)
        {
            rentals.Add(arg);
        }

        public string Name
        {
            get { return name; }
        }

        public string Generate()
        {
            Initialize();
            AddHeader();
            AddBody();
            AddFooter();
            return statement;
        }

        private void Initialize()
        {
            totalAmount = 0;
            frequentRenterPoints = 0;

        }

        private void AddBody()
        {
            foreach (Rental rental in rentals)
            {
                double amount = rental.GetAmount();
                frequentRenterPoints += rental.GetFrequentRenterPoints();

                statement += String.Format("\t{0}\t{1}\n", rental.Movie.GetTitle(), amount);
                totalAmount += amount;
            }
        }

        private void AddHeader()
        {
            this.statement = "Rental Record for " + Name + "\n";
        }

        private void AddFooter()
        {
            this.statement += "Amount owed is " + totalAmount + "\n";
            this.statement += "You earned " + frequentRenterPoints + " frequent renter points";
        }

        public double TotalAmount
        {
            get { return this.totalAmount; }
        }

        public object FrequentPoints
        {
            get { return this.frequentRenterPoints; }
        }
    }
}
