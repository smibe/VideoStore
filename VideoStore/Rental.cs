namespace RefactoringDemo
{
    public class Rental
    {
        private Movie movie;
        private int daysRented;

        public Rental(Movie movie, int daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;
        }

        public int DaysRented
        {
            get { return daysRented; }
        }

        public Movie Movie
        {
            get { return movie; }
        }

        public string Title
        {
            get { return Movie.Title; }
        }

        public double DetermineAmount()
        {
            return RentalRules.DetermineAmount(DaysRented, Movie);
        }

        public int DetermineFrequentRentalPoints()
        {
            return RentalRules.DetermineFrequentrenterPoints(DaysRented, Movie);
        }
    }
}
