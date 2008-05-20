/*
 * Created by: 
 * Created: dinsdag 7 augustus 2007
 */

using System;
using System.Collections.Specialized;
using Castle.MonoRail.Framework;
using iWish.Castle.ActiveRecord;

namespace iWish.Castle.MonoRail.Filters
{
    public class AuthenticationFilter : IFilter
    {
        public bool Perform(ExecuteEnum exec, IRailsEngineContext context, Controller controller)
        {
            return true;
        }
    }
}