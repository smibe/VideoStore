using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class VideoStoreTests
    {
        private Statement statement;

        [TestInitialize]
        public void SetUp()
        {
            statement = new Statement("Fred");
        }

        [TestMethod]
        public void SingleNewReleaseStatement()
        {
            statement.AddRental(new Rental(new Movie("The Cell", Movie.PriceCode.NEW_RELEASE), 3));
            Assert.AreEqual(
                "Rental Record for Fred\n" +
                "\tThe Cell\t9\nAmount owed is 9\n" +
                "You earned 2 frequent renter points",
                statement.Generate());
            Assert.AreEqual(9.0, statement.TotalAmount);
            Assert.AreEqual(2, statement.FrequentPoints);
        }

        [TestMethod]
        public void DualNewReleaseStatement()
        {
            statement.AddRental(new Rental(new Movie("The Cell", Movie.PriceCode.NEW_RELEASE), 3));
            statement.AddRental(new Rental(new Movie("The Tigger Movie", Movie.PriceCode.NEW_RELEASE), 3));
            statement.Generate();
            Assert.AreEqual(18.0, statement.TotalAmount);
            Assert.AreEqual(4, statement.FrequentPoints);
        }

        [TestMethod]
        public void SingleChildrensReleaseStatement()
        {
            statement.AddRental(new Rental(new Movie("The Tigger Movie", Movie.PriceCode.CHILDRENS), 3));
            statement.Generate();
            Assert.AreEqual(1.5, statement.TotalAmount);
            Assert.AreEqual(1, statement.FrequentPoints);
        }

        [TestMethod]
        public void MultipleRegularStatementFormat()
        {
            statement.AddRental(new Rental(new Movie("Plan 9 from Outer Space", Movie.PriceCode.REGULAR), 1));
            statement.AddRental(new Rental(new Movie("8 1/2", Movie.PriceCode.REGULAR), 2));
            statement.AddRental(new Rental(new Movie("Eraserhead", Movie.PriceCode.REGULAR), 3));
            statement.Generate();
            Assert.AreEqual("Rental Record for Fred\n\tPlan 9 from Outer Space\t2\n\t8 1/2\t2\n\tEraserhead\t3,5\nAmount owed is 7,5\nYou earned 3 frequent renter points", statement.Generate());
        }


        [TestMethod]
        public void MultipleRegularStatementValue()
        {
            statement.AddRental(new Rental(new Movie("Plan 9 from Outer Space", Movie.PriceCode.REGULAR), 1));
            statement.AddRental(new Rental(new Movie("8 1/2", Movie.PriceCode.REGULAR), 2));
            statement.AddRental(new Rental(new Movie("Eraserhead", Movie.PriceCode.REGULAR), 3));
            statement.Generate();
            Assert.AreEqual(7.5, statement.TotalAmount);
            Assert.AreEqual(3, statement.FrequentPoints);
        }
    }
}
