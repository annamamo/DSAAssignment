﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1022
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Electros.ProductServ {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductServ.IProductService")]
    public interface IProductService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetAllProducts", ReplyAction="http://tempuri.org/IProductService/GetAllProductsResponse")]
        Common.Product[] GetAllProducts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProductByID", ReplyAction="http://tempuri.org/IProductService/GetProductByIDResponse")]
        Common.Product GetProductByID(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetAllComments", ReplyAction="http://tempuri.org/IProductService/GetAllCommentsResponse")]
        Common.Comment[] GetAllComments();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetCommentByProductID", ReplyAction="http://tempuri.org/IProductService/GetCommentByProductIDResponse")]
        Common.Comment[] GetCommentByProductID(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/Create", ReplyAction="http://tempuri.org/IProductService/CreateResponse")]
        void Create(Common.Comment comment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/getPurchasesByDates", ReplyAction="http://tempuri.org/IProductService/getPurchasesByDatesResponse")]
        Common.Order[] getPurchasesByDates(int accountID, System.DateTime dateFrom, System.DateTime dateTo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/searchByCategory", ReplyAction="http://tempuri.org/IProductService/searchByCategoryResponse")]
        Common.Product[] searchByCategory(string category);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/searchByName", ReplyAction="http://tempuri.org/IProductService/searchByNameResponse")]
        Common.Product[] searchByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/searchByPriceRange", ReplyAction="http://tempuri.org/IProductService/searchByPriceRangeResponse")]
        Common.Product[] searchByPriceRange(decimal lowPrice, decimal highPrice);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/sortByAscPrice", ReplyAction="http://tempuri.org/IProductService/sortByAscPriceResponse")]
        Common.Product[] sortByAscPrice();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/sortByDescPrice", ReplyAction="http://tempuri.org/IProductService/sortByDescPriceResponse")]
        Common.Product[] sortByDescPrice();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/sortByDateListed", ReplyAction="http://tempuri.org/IProductService/sortByDateListedResponse")]
        Common.Product[] sortByDateListed();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/CreateRating", ReplyAction="http://tempuri.org/IProductService/CreateRatingResponse")]
        void CreateRating(Common.Rating rating);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/getAverageRating", ReplyAction="http://tempuri.org/IProductService/getAverageRatingResponse")]
        double getAverageRating(int productID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/getHighlyRatedItem", ReplyAction="http://tempuri.org/IProductService/getHighlyRatedItemResponse")]
        Common.Rating[] getHighlyRatedItem();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/getMostPurchasedItem", ReplyAction="http://tempuri.org/IProductService/getMostPurchasedItemResponse")]
        Common.ProductOrder[] getMostPurchasedItem();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/getMostFaults", ReplyAction="http://tempuri.org/IProductService/getMostFaultsResponse")]
        Common.FaultReport[] getMostFaults();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/getLeastFaults", ReplyAction="http://tempuri.org/IProductService/getLeastFaultsResponse")]
        Common.FaultReport[] getLeastFaults();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/Update", ReplyAction="http://tempuri.org/IProductService/UpdateResponse")]
        void Update(Common.Product p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/UpdateProductStock", ReplyAction="http://tempuri.org/IProductService/UpdateProductStockResponse")]
        void UpdateProductStock(int newStock, int productID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductServiceChannel : Electros.ProductServ.IProductService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductServiceClient : System.ServiceModel.ClientBase<Electros.ProductServ.IProductService>, Electros.ProductServ.IProductService {
        
        public ProductServiceClient() {
        }
        
        public ProductServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Common.Product[] GetAllProducts() {
            return base.Channel.GetAllProducts();
        }
        
        public Common.Product GetProductByID(int id) {
            return base.Channel.GetProductByID(id);
        }
        
        public Common.Comment[] GetAllComments() {
            return base.Channel.GetAllComments();
        }
        
        public Common.Comment[] GetCommentByProductID(int id) {
            return base.Channel.GetCommentByProductID(id);
        }
        
        public void Create(Common.Comment comment) {
            base.Channel.Create(comment);
        }
        
        public Common.Order[] getPurchasesByDates(int accountID, System.DateTime dateFrom, System.DateTime dateTo) {
            return base.Channel.getPurchasesByDates(accountID, dateFrom, dateTo);
        }
        
        public Common.Product[] searchByCategory(string category) {
            return base.Channel.searchByCategory(category);
        }
        
        public Common.Product[] searchByName(string name) {
            return base.Channel.searchByName(name);
        }
        
        public Common.Product[] searchByPriceRange(decimal lowPrice, decimal highPrice) {
            return base.Channel.searchByPriceRange(lowPrice, highPrice);
        }
        
        public Common.Product[] sortByAscPrice() {
            return base.Channel.sortByAscPrice();
        }
        
        public Common.Product[] sortByDescPrice() {
            return base.Channel.sortByDescPrice();
        }
        
        public Common.Product[] sortByDateListed() {
            return base.Channel.sortByDateListed();
        }
        
        public void CreateRating(Common.Rating rating) {
            base.Channel.CreateRating(rating);
        }
        
        public double getAverageRating(int productID) {
            return base.Channel.getAverageRating(productID);
        }
        
        public Common.Rating[] getHighlyRatedItem() {
            return base.Channel.getHighlyRatedItem();
        }
        
        public Common.ProductOrder[] getMostPurchasedItem() {
            return base.Channel.getMostPurchasedItem();
        }
        
        public Common.FaultReport[] getMostFaults() {
            return base.Channel.getMostFaults();
        }
        
        public Common.FaultReport[] getLeastFaults() {
            return base.Channel.getLeastFaults();
        }
        
        public void Update(Common.Product p) {
            base.Channel.Update(p);
        }
        
        public void UpdateProductStock(int newStock, int productID) {
            base.Channel.UpdateProductStock(newStock, productID);
        }
    }
}
