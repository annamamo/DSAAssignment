using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class DAProduct : ConnectionClass
    {
        public DAProduct() : base() { }

        public IEnumerable<Product> GetAllProducts()
        {
            return entities.Product.AsEnumerable();
        }
        public Product GetProductByID(int id)
        {
            return entities.Product.SingleOrDefault(p => p.ID == id);
        }
    }
}
