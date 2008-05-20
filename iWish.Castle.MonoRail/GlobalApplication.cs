using System.Reflection;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;
using iWish.Castle.ActiveRecord;

namespace iWish.Castle.MonoRail
{
	using System;
	using System.Web;

	public class GlobalApplication : HttpApplication
	{
        //public GlobalApplication()
        //{
        //}

		public void Application_OnStart()
		{
            IConfigurationSource source = ActiveRecordSectionHandler.Instance;
            Assembly assembly = typeof(Wish).Assembly;
            ActiveRecordStarter.Initialize(assembly, source);
        }

        //public void Application_OnEnd() 
        //{
        //}
	}
}
