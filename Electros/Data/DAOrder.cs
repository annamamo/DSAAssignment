using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class DAOrder : ConnectionClass
    {
        public DAOrder() : base() { }

        public void addOrder(Order order)
        {
            entities.AddToOrder(order);
            entities.SaveChanges();
                

        }

        public Order getOrderById(int id)
        {
            return entities.Order.SingleOrDefault(o => o.ID == id);
        }

        public Order getOrderIDByAccountIDStatus(int accountID, string status)
        {
            return entities.Order.SingleOrDefault(o => o.AccountID == accountID && o.Status == status);
        }

        //get order details for basket section
        public Order getUserProductOrder(int accountID, string status)
        {
            return entities.Order.SingleOrDefault(o => o.AccountID == accountID && o.Status == status);
        }

        public void UpdateOrder(Order o)
        {
            entities.Order.Attach(getOrderById(o.ID));
            entities.Order.ApplyCurrentValues(o);
            entities.SaveChanges();
        }

        public IEnumerable<Order> getShippedOrders(int accountID)
        {
            return entities.Order.Where(o => o.AccountID == accountID && o.Status == "Shipped");
        }

        public IEnumerable<Order> getPurchasesUnderWarranty(int accountID)
        {
            return entities.Order.Where(o => o.AccountID == accountID && o.Status == "Shipped" && o.WarrantyExpiryDate > System.DateTime.Now);
        }

        public IEnumerable<Order> getPurchasesByDates(int accountID,DateTime dateFrom, DateTime dateTo)
        {
            return entities.Order.Where(o => o.AccountID == accountID && o.DateOfPurchase >= dateFrom && o.DateOfPurchase <= dateTo && o.Status == "Shipped");
        }

        //get order for report by accountID and date of purchase
        public Order getOrderByIDs(int accountID, int orderID)
        {
            return entities.Order.SingleOrDefault(o => o.AccountID == accountID && o.ID == orderID);
        }
    }
}
