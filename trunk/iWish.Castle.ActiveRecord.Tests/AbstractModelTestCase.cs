// Copyright 2004-2006 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Reflection;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;
using MbUnit.Framework;

namespace iWish.Castle.ActiveRecord.Tests
{
    /// <summary>
    /// This is a suggestion of base class that might 
    /// simplify the unit testing for the ActiveRecord
    /// classes.
    /// <para>
    /// Basically you have to create a separate database
    /// for your tests, which is always a good idea:
    /// - production
    /// - development
    /// - test
    /// </para>
    /// <para>
    /// You have to decide if you want to administrate the
    /// schema on the <c>test</c> database or let ActiveRecord
    /// generate them for you during test execution. Check 
    /// <see cref="AbstractModelTestCase.PrepareSchema"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Note that this class enables lazy classes and collections
    /// by using a <see cref="SessionScope"/>.
    /// This have side effects. Some of your test must 
    /// invoke <see cref="Flush"/> 
    /// to persist the changes.
    /// </remarks>
    public class AbstractModelTestCase
    {
        protected SessionScope scope;

        private static bool HasBeenInitialized = false;

        [TestFixtureSetUp]
        public virtual void FixtureInit()
        {
            InitFramework();
        }

        [SetUp]
        public virtual void Init()
        {
            PrepareSchema();

            CreateScope();
        }

        [TearDown]
        public virtual void Terminate()
        {
            DisposeScope();

            //DropSchema();
        }

        [TestFixtureTearDown]
        public virtual void TerminateAll()
        {
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
            Assembly assembly = typeof (Wish).Assembly;
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
