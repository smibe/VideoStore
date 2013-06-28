namespace RefactoringDemo
{
    public class Movie
    {
        private PriceCode priceCode;

        public Movie(string title, PriceCode priceCode)
        {
            this.Title = title;
            this.priceCode = priceCode;
        }

        public PriceCode GetPriceCode()
        {
            return priceCode;
        }

        public string Title { get; private set; }
    }
}
