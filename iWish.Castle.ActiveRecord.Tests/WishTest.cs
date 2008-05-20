using System.Collections.Generic;
using MbUnit.Framework;

namespace iWish.Castle.ActiveRecord.Tests
{
    [TestFixture]
    public class WishTest : AbstractModelTestCase
    {
        [Test]
        public void VerifyPrice()
        {
            Wish wish = new Wish();
            wish.Price = "0.5";
            Assert.AreEqual("0,50", wish.Price);
        }

        [Test]
        public void GetMyWishes_WithoutParameters_Succeeds()
        {
            IList<Wish> myWishes = Wish.GetMyWishes();
            Assert.IsNotNull(myWishes);
            Assert.AreEqual(0, myWishes.Count);

        }

    }
}