/*
 * Created by: 
 * Created: donderdag 9 augustus 2007
 */

using System.Security.Permissions;
using Castle.MonoRail.Framework;
using iWish.Castle.ActiveRecord;
using iWish.Castle.MonoRail.Filters;

namespace iWish.Castle.MonoRail.Controllers
{
    [Layout("default"), Rescue("generalerror")]
    [Filter(ExecuteEnum.BeforeAction, typeof(AuthenticationFilter))]
    public class SecurityController : BaseController
    {
    }
}