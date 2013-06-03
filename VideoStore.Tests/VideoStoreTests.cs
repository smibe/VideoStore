using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RefactoringDemo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class VideoStoreTests
    {
        private Customer customer;

        [TestInitialize]
        public void SetUp()
        {
            customer = new Customer("Fred");
        }

        [TestMethod]
        public void SingleNewReleaseStatement()
        {
            customer.AddRental(new Rental(new Movie("The Cell", Movie.PriceCode.NEW_RELEASE), 3));
            Assert.AreEqual("Rental Record for Fred\n\tThe Cell\t9\nAmount owed is 9\nYou earned 2 frequent renter points", customer.Statement());
        }

        [TestMethod]
        public void DualNewReleaseStatement()
        {
            customer.AddRental(new Rental(new Movie("The Cell", Movie.PriceCode.NEW_RELEASE), 3));
            customer.AddRental(new Rental(new Movie("The Tigger Movie", Movie.PriceCode.NEW_RELEASE), 3));
            Assert.AreEqual("Rental Record for Fred\n\tThe Cell\t9\n\tThe Tigger Movie\t9\nAmount owed is 18\nYou earned 4 frequent renter points", customer.Statement());
        }

        [TestMethod]
        public void SingleChildrensReleaseStatement()
        {
            customer.AddRental(new Rental(new Movie("The Tigger Movie", Movie.PriceCode.CHILDRENS), 3));
            Assert.AreEqual("Rental Record for Fred\n\tThe Tigger Movie\t1,5\nAmount owed is 1,5\nYou earned 1 frequent renter points", customer.Statement());
        }

        [TestMethod]
        public void MultipleRegularStatement()
        {
            customer.AddRental(new Rental(new Movie("Plan 9 from Outer Space", Movie.PriceCode.REGULAR), 1));
            customer.AddRental(new Rental(new Movie("8 1/2", Movie.PriceCode.REGULAR), 2));
            customer.AddRental(new Rental(new Movie("Eraserhead", Movie.PriceCode.REGULAR), 3));
            Assert.AreEqual("Rental Record for Fred\n\tPlan 9 from Outer Space\t2\n\t8 1/2\t2\n\tEraserhead\t3,5\nAmount owed is 7,5\nYou earned 3 frequent renter points", customer.Statement());
        }
    }
}
