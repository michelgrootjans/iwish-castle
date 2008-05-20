/*
 * Created by: 
 * Created: maandag 6 augustus 2007
 */

using System;
using Castle.MonoRail.Framework;
using iWish.Castle.ActiveRecord;
using iWish.Castle.MonoRail.Filters;

namespace iWish.Castle.MonoRail.Controllers
{
    [Layout("default"), Rescue("generalerror")]
    [Filter(ExecuteEnum.BeforeAction, typeof (AuthenticationFilter))]
    public class WishController : BaseController
    {
        public void MyWishes()
        {
            PropertyBag["wishes"] = Wish.GetMyWishes();
        }

        public void New()
        {
        }

        public void Create([DataBind("wish")] Wish wish)
        {
            try
            {
                wish.Create();
                RedirectToAction("MyWishes");
            }
            catch (ValidationException ex)
            {
                Flash["error"] = "";
                foreach (string exception in ex.Exceptions)
                {
                    Flash["error"] += string.Format("{0}<br/>", exception);
                }
                Flash["wish"] = wish;
                RedirectToAction("new");
            }
            catch (Exception e)
            {
                Flash["error"] = e.Message;
                Flash["wish"] = wish;
                RedirectToAction("new");
            }
        }

        public void Edit(int id)
        {
            try
            {
                PropertyBag["wish"] = Wish.Find(id);
            }
            catch (Exception e)
            {
                Flash["error"] = "Could not edit this wish.<br/>";
            }
        }

        public void Update([DataBind("wish")] Wish wish)
        {
            try
            {
                wish.Update();
                if (wish.Id <= 0)
                    throw new Exception("Could not update wish.<br/>");
                RedirectToAction("MyWishes");
            }
            catch (Exception e)
            {
                Flash["error"] = e.Message;
                Flash["wish"] = wish;

                RedirectToAction("edit", wish.Id.ToString());
            }
        }

        public void Delete(int id)
        {
            Wish wish = Wish.Find(id);
            wish.Delete();
            RedirectToAction("MyWishes");
        }
    }
}