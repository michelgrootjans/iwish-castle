/*
 * Created by: 
 * Created: zondag 5 augustus 2007
 */

using System;
using System.Collections.Generic;
using Castle.ActiveRecord;

namespace iWish.Castle.ActiveRecord
{
    [ActiveRecord]
    public class Wish : Entity<Wish>
    {
        private string description;
        private Price price = new Price();


        public static IList<Wish> GetMyWishes()
        {
            return FindAll();
        }

        public override void Create()
        {
            Validate();
            base.Create();
        }

        private void Validate()
        {
            IList<string> exceptions = new List<string>();
            if (string.IsNullOrEmpty(Description))
                exceptions.Add("Description cannot be null.");

            if (exceptions.Count > 0)
                throw new ValidationException(exceptions);
        }

        [Property]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Price
        {
            get { return price.Value; }
            set { price.Value = value; }
        }

        [Property("Price")]
        private double PriceValue
        {
            get { return price.PriceValue; }
            set { price.PriceValue = value; }
        }
    }
}