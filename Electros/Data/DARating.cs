using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class DARating : ConnectionClass
    {
        public DARating() : base() { }

        public void CreateRating(Rating rating)
        {
            entities.Rating.AddObject(rating);
                //AddToRating(rating);
            entities.SaveChanges();
        }
        public double getAverageRating(int productID)
        {
            return Convert.ToDouble(entities.Rating.Where(r => r.ProductID == productID).Average(r => r.Rating1)); 
        }

    }
}
