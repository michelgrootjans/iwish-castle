/*
 * Created by: 
 * Created: zondag 5 augustus 2007
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using Castle.ActiveRecord;

namespace iWish.Castle.ActiveRecord
{
    [ActiveRecord("USR")]
    public class User : Entity<User>
    {
    }
}