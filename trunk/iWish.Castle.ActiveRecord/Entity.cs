/*
 * Created by: 
 * Created: zondag 5 augustus 2007
 */

using Castle.ActiveRecord;

namespace iWish.Castle.ActiveRecord
{
    public class Entity<T> : ActiveRecordBase<T>
    {
        private int id;

        public Entity()
        {
        }

        public Entity(int id)
        {
            this.id = id;
        }

        [PrimaryKey]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}