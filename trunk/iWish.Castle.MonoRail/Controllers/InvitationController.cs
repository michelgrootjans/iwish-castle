/*
 * Created by: 
 * Created: zondag 12 augustus 2007
 */

using Castle.MonoRail.Framework;
using iWish.Castle.MonoRail.Filters;

namespace iWish.Castle.MonoRail.Controllers
{
    [Layout("default"), Rescue("generalerror")]
    [Filter(ExecuteEnum.BeforeAction, typeof(AuthenticationFilter))]
    public class InvitationController : BaseController
    {
        public void MyInvitations()
        {
        }

        public void AcceptInvitation()
        {
            Flash["message"] = "You have accepted the invitation";
            RedirectToAction("MyInvitations");
        }

        public void DeclineInvitation()
        {
            Flash["message"] = "You have declined the invitation";
            RedirectToAction("MyInvitations");
        }
    }
}