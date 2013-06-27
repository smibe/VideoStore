using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoStore;

namespace VideoStore
{
    public enum MovieType
    {
        Regular = 0,
        NewRelease = 1,
        ChildrensMovie = 2,
    }

    public struct MovieRentalRules
    {
        public Func<int, double> calculateAmount;
        public Func<int, int> calculateFrequentRenterPoints;

        public MovieRentalRules(Func<int, double> calculateAmount, Func<int, int> calculateFrequentRenterPoints)
        {
            this.calculateAmount = calculateAmount;
            this.calculateFrequentRenterPoints = calculateFrequentRenterPoints;
        }
    }

    public class Rental
    {
        private Movie movie;
        private int daysRented;
        private MovieRentalRules[] rentalRules;

        public Rental(Movie movie, int daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;

            this.rentalRules = new MovieRentalRules[3];
            rentalRules[(int)MovieType.Regular] = new MovieRentalRules((days) => 2 + ((days > 2) ? (days - 2) * 1.5 : 0), (days) => 1);
            rentalRules[(int)MovieType.NewRelease] = new MovieRentalRules((days) => days * 3, (days) => days > 1 ? 2 : 1);
            rentalRules[(int)MovieType.ChildrensMovie] = new MovieRentalRules((days) => 1.5 + ((days > 3) ? (days - 3) * 1.5 : 0), (days) => 1);
        }

        public Movie Movie
        {
            get
            {
                return this.movie;
            }
        }

        public double GetAmount()
        {
            MovieRentalRules rentalRule = this.rentalRules[(int)this.movie.GetPriceCode()];
            return rentalRule.calculateAmount(this.daysRented);
        }

        public int GetFrequentRenterPoints()
        {
            MovieRentalRules rentalRule = this.rentalRules[(int)this.movie.GetPriceCode()];
            return rentalRule.calculateFrequentRenterPoints(this.daysRented);
        }
    }
}
