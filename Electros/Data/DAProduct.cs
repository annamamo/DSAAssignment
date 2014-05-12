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

        public void Update(Product p)
        {
            //entities.GuestBookEntries.Attach(GetEntries(gb.ID));
            //entities.GuestBookEntries.ApplyCurrentValues(gb);

            //entities.SaveChanges();
            //entities.Product.Attach(GetProductByID(p.ID));
            Product pro = GetProductByID(p.ID);
            p.ID = pro.ID;
            entities.Product.ApplyCurrentValues(p);
            entities.SaveChanges();
        }

        public void UpdateProductStock(int newStock, int productID)
        {
            //entities.GuestBookEntries.Attach(GetEntries(gb.ID));
            //entities.GuestBookEntries.ApplyCurrentValues(gb);

            //entities.SaveChanges();
            //entities.Product.Attach(GetProductByID(p.ID));
            Product pro = GetProductByID(productID);
            pro.StockAmount = newStock;
            entities.Product.ApplyCurrentValues(pro);
            entities.SaveChanges();
        }

        //search product by category
        public IEnumerable<Product> searchByCategory(string category)
        {
            return entities.Product.Where(p => p.Category.Name.Contains(category));
        }
        //search product by name
        public IEnumerable<Product> searchByName(string name)
        {
            return entities.Product.Where(p => p.Name.Contains(name));
        }
        //search product by price
        public IEnumerable<Product> searchByPriceRange(decimal lowPrice, decimal highPrice)
        {
            return entities.Product.Where(p => p.Price >= lowPrice && p.Price <= highPrice );
        }
        //sort produclist by price ascending
        public IEnumerable<Product> sortByAscPrice()
        {
            
            return entities.Product.OrderBy(p => p.Price);
        }
        //sort productlist by price descending
        public IEnumerable<Product> sortByDescPrice()
        {
            return entities.Product.OrderByDescending(p => p.Price);
        }
        //sort productlist by datelisted
        public IEnumerable<Product> sortByDateListed()
        {
            return entities.Product.OrderBy(p => p.DateListed);
        }

        //report highly rated item
        public IEnumerable<Rating> getHighlyRatedItem()
        {
            //return entities.Product.OrderBy(p => p.Rating.id).Take(1);
            return entities.Rating.GroupBy(r => r.ProductID).OrderByDescending(rs => rs.Count()).FirstOrDefault();
             //return entities.Rating.GroupBy(r => r.ProductID).OrderByDescending(rs => rs.Count()).Join(Product, pro => pro.id
        }
        //report 2
        public IEnumerable<ProductOrder> getMostPurchasedItem()
        {
            return entities.ProductOrder.GroupBy(po => po.ProductID).OrderByDescending(p => p.Count()).FirstOrDefault();
        }
        //report 3
        public IEnumerable<FaultReport> getMostFaults()
        {
            return entities.FaultReport.GroupBy(fr => fr.ProductID).OrderByDescending(p => p.Count()).FirstOrDefault();
        }
        //report 4
        public IEnumerable<FaultReport> getLeastFaults()
        {
            return entities.FaultReport.GroupBy(fr => fr.ProductID).OrderBy(p => p.Count()).FirstOrDefault();
        }
    }
}
