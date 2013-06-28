using RefactoringDemo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class VideoStoreTests
    {
        private Statement statement;
        private Movie newReleaseMovie = new Movie("The Cell", PriceCode.NewRelease);
        private Movie newReleaseMovie2 = new Movie("The Tigger Movie", PriceCode.NewRelease);

        [TestInitialize]
        public void SetUp()
        {
            statement = new Statement("Fred");
        }

        [TestMethod]
        public void SingleNewReleaseStatement()
        {
            statement.AddRental(new Rental(newReleaseMovie, 3));
            statement.CalculateTotals();
            Assert.AreEqual(9, statement.TotalAmount);
            Assert.AreEqual(2, statement.FrequentRenterPoints);
        }

        [TestMethod]
        public void DualNewReleaseStatement()
        {
            statement.AddRental(new Rental(newReleaseMovie, 3));
            statement.AddRental(new Rental(newReleaseMovie2, 3));
            statement.CalculateTotals();
            Assert.AreEqual(18, statement.TotalAmount);
            Assert.AreEqual(4, statement.FrequentRenterPoints);
        }

        [TestMethod]
        public void DualChildrensReleaseStatement()
        {
            statement.AddRental(new Rental(new Movie("The Tigger Movie", PriceCode.Childrens), 3));
            statement.AddRental(new Rental(new Movie("The Tigger Movie1", PriceCode.Childrens), 4));
            statement.CalculateTotals();
            Assert.AreEqual(4,5, statement.TotalAmount);
            Assert.AreEqual(2, statement.FrequentRenterPoints);
        }

        [TestMethod]
        public void MultipleRegularStatementValues()
        {
            statement.AddRental(new Rental(new Movie("Plan 9 from Outer Space", PriceCode.Regular), 1));
            statement.AddRental(new Rental(new Movie("8 1/2", PriceCode.Regular), 2));
            statement.AddRental(new Rental(new Movie("Eraserhead", PriceCode.Regular), 3));
            statement.CalculateTotals();
            Assert.AreEqual(7,5, statement.TotalAmount);
            Assert.AreEqual(3, statement.FrequentRenterPoints);
        }

        [TestMethod]
        public void MultipleRegularStatementFormat()
        {
            statement.AddRental(new Rental(new Movie("Plan 9 from Outer Space", PriceCode.Regular), 1));
            statement.AddRental(new Rental(new Movie("8 1/2", PriceCode.Regular), 2));
            statement.AddRental(new Rental(new Movie("Eraserhead", PriceCode.Regular), 3));
            Assert.AreEqual("Rental Record for Fred\n\tPlan 9 from Outer Space\t2\n\t8 1/2\t2\n\tEraserhead\t3,5\nAmount owed is 7,5\nYou earned 3 frequent renter points", statement.Generate());
        }
    }
}
