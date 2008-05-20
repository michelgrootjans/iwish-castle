/*
 * Created by: 
 * Created: maandag 6 augustus 2007
 */

using Castle.MonoRail.Framework;
using iWish.Castle.MonoRail.Filters;

namespace iWish.Castle.MonoRail.Controllers
{
    [Layout("default"), Rescue("generalerror")]
    [Filter(ExecuteEnum.BeforeAction, typeof(AuthenticationFilter))]
    public class UserController : BaseController
    {
    }
}