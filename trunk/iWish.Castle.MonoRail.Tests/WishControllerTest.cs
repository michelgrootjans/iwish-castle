using System;
using System.Collections.Generic;
using Castle.ActiveRecord.Framework;
using iWish.Castle.ActiveRecord;
using iWish.Castle.MonoRail.Controllers;
using MbUnit.Framework;

namespace iWish.Castle.MonoRail.Tests
{
    [TestFixture]
    public class WishControllerTest : AbstractModelTestCase<WishController>
    {
        [Test]
        public void MyWishes_WithoutParameters_Succeeds()
        {
            controller.MyWishes();
            Assert.AreEqual(1, controller.PropertyBag.Count);
            Assert.IsTrue(controller.PropertyBag["wishes"] is IList<Wish>);
        }

        [Test]
        public void New_WithoutParameters_DoesNothing()
        {
            controller.New();
        }

        [Test]
        public void Create_WithNullWish_ThrowsException()
        {
            controller.Create(null);
            Assert.AreEqual(2, controller.Flash.Count);
            Assert.IsNull(controller.Flash["wish"]);
            Assert.AreEqual("Object reference not set to an instance of an object.", controller.Flash["error"]);
        }

        [Test]
        public void Create_WithEmptyWish_ThrowsException()
        {
            Wish wish = new Wish();
            controller.Create(wish);
            Assert.AreEqual(2, controller.Flash.Count);
            Assert.AreEqual(wish, controller.Flash["wish"]);
            Assert.AreEqual("Description cannot be null.<br/>", controller.Flash["error"]);
        }

        [Test]
        public void Create_WithCorrectWish_Succeeds()
        {
            Wish wish = new Wish();
            wish.Description = "Hello world";
            wish.Price = "1.25";
            controller.Create(wish);
            Assert.AreEqual(0, controller.Flash.Count);
        }

        [Test]
        public void Edit_WithExistingId_SetsTheWishInThePropertyBag()
        {
            Wish wish = new Wish();
            wish.Description = "Hello world";
            wish.Price = "1.25";
            wish.Create();

            controller.Edit(wish.Id);
            Assert.AreSame(wish, controller.PropertyBag["wish"]);
        }

        [Test]
        public void Edit_WithBadId_ThrowsException()
        {
            controller.Edit(123);
            Assert.AreEqual(1, controller.Flash.Count);
            Assert.AreEqual("Could not edit this wish.<br/>", controller.Flash["error"]);
        }

        [Test]
        public void Update_AnExistingWish_Succeeds()
        {
            Wish wish = new Wish();
            wish.Description = "Hello world";
            wish.Price = "1.25";
            wish.Create();

            controller.Update(wish);
        }

        [Test]
        public void Update_ABadWish_ThrowsException()
        {
            Wish wish = new Wish();
            wish.Description = "Hello world";
            wish.Price = "1.25";
            controller.Update(wish);
            Assert.AreEqual(2, controller.Flash.Count);
            Assert.AreEqual(wish, controller.Flash["wish"]);
            Assert.AreEqual("Could not update wish.<br/>", controller.Flash["error"]);
        }

        [Test]
        [ExpectedException(typeof(ActiveRecordException))]
        public void Delete_AnExistingWish_Works()
        {
            Wish wish = new Wish();
            wish.Description = "Hello world";
            wish.Price = "1.25";
            wish.Create();
            int wishId = wish.Id;
            FlushAndRecreateScope();

            controller.Delete(wishId);


            wish = Wish.Find(wishId);
            Assert.Fail();
        }

    }
}