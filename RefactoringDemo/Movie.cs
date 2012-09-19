using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringDemo
{
    public class Movie
    {
        public enum PriceCode
        {
            REGULAR = 0,
            NEW_RELEASE = 1,
            CHILDRENS = 2
        }

        private string title;
        private PriceCode priceCode;

        public Movie(string title, PriceCode priceCode)
        {
            this.title = title;
            this.priceCode = priceCode;
        }

        public PriceCode GetPriceCode()
        {
            return priceCode;
        }

        public void SetPriceCode(PriceCode arg)
        {
            priceCode = arg;
        }

        public string GetTitle()
        {
            return title;
        }
    }
}
