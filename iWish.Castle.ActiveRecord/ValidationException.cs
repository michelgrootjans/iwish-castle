/*
 * Created by: 
 * Created: zondag 20 januari 2008
 */

using System;
using System.Collections.Generic;

namespace iWish.Castle.ActiveRecord
{
    public class ValidationException : Exception
    {
        private IList<string> _exceptions;

        public ValidationException(IList<string> exceptions) : base ("There were validation exceptions.")
        {
            Exceptions = exceptions;
        }

        public IList<string> Exceptions
        {
            get { return _exceptions; }
            set { _exceptions = value; }
        }
    }
}