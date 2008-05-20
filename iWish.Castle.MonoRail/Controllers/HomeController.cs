using System.Security.Permissions;
using Castle.MonoRail.Framework;
using iWish.Castle.MonoRail.Filters;

namespace iWish.Castle.MonoRail.Controllers
{
	[Layout("default"), Rescue("generalerror")]
    [Filter(ExecuteEnum.BeforeAction, typeof(AuthenticationFilter))]
    public class HomeController : BaseController
	{
        [SkipFilter]
        public void Index()
		{
		}

        public void Headlines()
        {
            
        }
	}
}
