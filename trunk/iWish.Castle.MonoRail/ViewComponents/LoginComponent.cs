/*
 * Created by: 
 * Created: zondag 12 augustus 2007
 */


using Castle.MonoRail.Framework;

namespace iWish.Castle.MonoRail.ViewComponents
{
    public class LoginComponent : ViewComponent
    {
        private bool isLoggedIn;

        public override void Initialize()
        {
            base.Initialize();
            if (!Context.HasSection("login"))
            {
                throw new RailsException("LoginComponent: Must have a login section defined");
            }
            if (!Context.HasSection("logout"))
            {
                throw new RailsException("LoginComponent: Must have a logout section defined");
            }
            isLoggedIn = RailsContext.CurrentUser.Identity.IsAuthenticated;
        }

        public override void Render()
        {
            if (isLoggedIn)
            {
                Context.RenderSection("logout");
            }
            else
            {
                Context.RenderSection("login");
            }
        }


        public override bool SupportsSection(string name)
        {
            return name == "login" || name == "logout";
        }
    }
}