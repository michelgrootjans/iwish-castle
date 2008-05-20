/*
 * Created by: 
 * Created: zaterdag 11 augustus 2007
 */

using Castle.MonoRail.Framework;
using iWish.Castle.MonoRail.Filters;

namespace iWish.Castle.MonoRail.Controllers
{
    [Layout("default"), Rescue("generalerror")]
    [Filter(ExecuteEnum.BeforeAction, typeof(AuthenticationFilter))]
    public class FriendController : BaseController
    {
        public void List()
        {

        }

        public void FriendWishes()
        {

        }

        public void New()
        {
            
        }

        public void SendInvitation()
        {
            Flash["message"] = "An invitation has been sent";
            RedirectToAction("List");
        }

        public void Reserve()
        {
            Flash["message"] = "Wish has been reserved";
            RedirectToAction("FriendWishes");
        }
    }
}