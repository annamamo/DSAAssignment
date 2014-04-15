using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class DAProductOrder : ConnectionClass
    {
        public DAProductOrder() : base() { }

        public void addProductOrder(ProductOrder productOrder)
        {
           
            entities.ProductOrder.AddObject(productOrder);
            //entities.AddToProductOrder(productOrder);
            entities.SaveChanges();
                
        }

        public void DeleteProductOrder(ProductOrder productOrder)
        {
            entities.ProductOrder.DeleteObject(productOrder);
            entities.SaveChanges();
        }

        public void UpdateProductOrder(ProductOrder po)
        {
            entities.ProductOrder.Attach(getProductOrderID(po.ProductID,po.OrderID));
            entities.ProductOrder.ApplyCurrentValues(po);
            entities.SaveChanges();
        }

        public ProductOrder getProductOrderID(int productID, int orderID)
        {
            return entities.ProductOrder.SingleOrDefault(po => po.ProductID == productID && po.OrderID == orderID);
        }

        public IEnumerable<ProductOrder> getProductOrderByOrderID(int orderID)
        {
            return entities.ProductOrder.Where(po => po.OrderID == orderID);
        }
        
        //to delete product order by given productId and
        public void DeleteProductOrderByIDs(int productID, int orderID)
        {
            entities.ProductOrder.DeleteObject(getProductOrderID(productID, orderID));
            entities.SaveChanges();
        }
        
    }
}
