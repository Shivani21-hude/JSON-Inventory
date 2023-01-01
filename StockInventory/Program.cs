using StockInventory;
using System;

namespace StockInventoey
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Stock inventory management \n");
            StockAccountManagement stockAccountManagement = new StockAccountManagement();

            string stockFilePath = @"E:\JSON Problems\StockInventory\StockInventory\Stock.json";
            stockAccountManagement.ReadStockJsonFile(stockFilePath);
            string customerFilePath = @"E:\JSON Problems\StockInventory\StockInventory\Stock.json";
            stockAccountManagement.ReadCustomerJsonFile(customerFilePath);
            stockAccountManagement.BuyStock("Google");
            stockAccountManagement.SellStocks("Flipcart");
            stockAccountManagement.WriteToStockJsonFile(stockFilePath);
            stockAccountManagement.WriteToStockJsonFile(customerFilePath);

        }
    }
}