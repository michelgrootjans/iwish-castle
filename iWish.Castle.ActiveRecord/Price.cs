/*
 * Created by: 
 * Created: zondag 20 januari 2008
 */

using System.Globalization;

namespace iWish.Castle.ActiveRecord
{
    public class Price
    {
        private double priceValue;
        private string decimalSeparator;
        private string thousandSeparator;

        public Price()
        {
            decimalSeparator = CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
            thousandSeparator = CultureInfo.CurrentUICulture.NumberFormat.NumberGroupSeparator;
        }

        public string Value
        {
            get { return priceValue.ToString("F"); }
            set
            {
                string preparedValue = PrepareValue(value);
                double parsedValue;
                if (double.TryParse(preparedValue, out parsedValue))
                    priceValue = parsedValue;
            }
        }

        public double PriceValue
        {
            get { return priceValue; }
            set { priceValue = value; }
        }

        private string PrepareValue(string value)
        {
            string preparedValue = value.Replace(decimalSeparator, thousandSeparator);
            return preparedValue;
        }
    }
}