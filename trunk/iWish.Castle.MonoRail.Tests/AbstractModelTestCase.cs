/*
 * Created by: 
 * Created: maandag 6 augustus 2007
 */

using System;
using System.Reflection;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;
using Castle.MonoRail.Framework;
using Castle.MonoRail.TestSupport;
using iWish.Castle.ActiveRecord;
using MbUnit.Framework;
using Rhino.Mocks;

namespace iWish.Castle.MonoRail.Tests
{
    public class AbstractModelTestCase<C> : GenericBaseControllerTest<C>
        where C : Controller, new()
    {
        protected SessionScope scope;
        private MockRepository mockRepository;

        private static bool HasBeenInitialized = false;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            InitFramework();
        }

        [SetUp]
        public void SetUp()
        {
            PrepareSchema();
            CreateScope();
            CreateController();
            mockRepository = new MockRepository();
        }

        [TearDown]
        public void TearDown()
        {
            DisposeScope();

            //DropSchema();

            mockRepository.VerifyAll();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
        }

        private void CreateController()
        {
            controller = new C();
            PrepareController(controller);
        }

        protected void Flush()
        {
            SessionScope.Current.Flush();
        }

        protected void CreateScope()
        {
            scope = new SessionScope(FlushAction.Never);
        }

        protected void DisposeScope()
        {
            scope.Dispose();
        }

        /// <summary>
        /// If you want to delete everything from the model.
        /// Remember to do it in a descendent dependency order
        /// </summary>
        protected virtual void PrepareSchema()
        {
            // If you want to delete everything from the model.
            // Remember to do it in a descendent dependency order

            // Office.DeleteAll();
            // User.DeleteAll();

            // Another approach is to always recreate the schema 
            // (please use a separate test database if you want to do that)

            ActiveRecordStarter.CreateSchema();
        }

        protected virtual void DropSchema()
        {
            ActiveRecordStarter.DropSchema();
        }

        protected virtual void InitFramework()
        {
            if (HasBeenInitialized) return;
            IConfigurationSource source = ActiveRecordSectionHandler.Instance;
            Assembly assembly = typeof(Wish).Assembly;
            ActiveRecordStarter.Initialize(assembly, source);
            HasBeenInitialized = true;
        }

        protected void FlushAndRecreateScope()
        {
            DisposeScope();
            CreateScope();
        }
    }
}