using MbUnit.Framework;

namespace iWish.Castle.ActiveRecord.Tests
{
    [TestFixture]
    public class PriceTest
    {
        [Row("0", 0.0, "0,00")]
        [Row("1", 1.0, "1,00")]
        [Row("-1", -1.0, "-1,00")]
        [Row("0.5", 0.5, "0,50")]
        [Row(".5", 0.5, "0,50")]
        [Row("0,5", 0.5, "0,50")]
        [Row(",5", 0.5, "0,50")]
        [RowTest]
        public void VerifyPrices(string inputValue, double expectedPriceValue, string expectedPrice)
        {
            Price price = new Price();
            price.Value = inputValue;
            Assert.AreEqual(expectedPriceValue, price.PriceValue);
            Assert.AreEqual(expectedPrice, price.Value);
        }
    }
}