using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInventory
{
    public class StockAccountManagement
    {
        double amount = 1000;
        List<StockDetails> stock = new List<StockDetails>();
        List<StockDetails> customer = new List<StockDetails>();
        public void ReadStockJsonFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            this.stock = JsonConvert.DeserializeObject<List<StockDetails>>(json);
            Console.WriteLine("StockName  StockPrice  NoOfShares");
            foreach (var content in stock)
            {
                Console.WriteLine(content.StockName + "   " + content.StockPrice + "   " + content.NoOfShares);
            }
        }
        public void ReadCustomerJsonFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            this.customer = JsonConvert.DeserializeObject<List<StockDetails>>(json);
            Console.WriteLine("\nStockName  StockPrice  NoOfShares");
            foreach (var content in customer)
            {
                Console.WriteLine(content.StockName + "   " + content.StockPrice + "   " + content.NoOfShares);
            }
        }
        public void BuyStock(string name)
        {
            foreach (var data in stock)
            {
                int count = 0;
                if (data.StockName.Equals(name))
                {
                    Console.WriteLine("Enter required stocks you need to buy");
                    int noOfStocks = Convert.ToInt32(Console.ReadLine());
                    if (noOfStocks * data.StockPrice <= amount && noOfStocks <= data.NoOfShares)
                    {
                        StockDetails details = new StockDetails()
                        {
                            StockName = data.StockName,
                            StockPrice = data.StockPrice,
                            NoOfShares = noOfStocks
                        };
                        data.NoOfShares -= noOfStocks;
                        amount -= data.StockPrice * noOfStocks;
                        foreach (var account in customer)
                        {
                            if (account.StockName.Equals(name))
                            {
                                count++;
                            }
                        }
                        if (count == 1)
                        {
                            data.NoOfShares += noOfStocks;
                        }
                        else
                        {
                            customer.Add(details);
                        }
                    }
                }
            }
        }
        public void WriteToStockJsonFile(string filepath)
        {
            var json = JsonConvert.SerializeObject(stock);
            File.WriteAllText(filepath, json);
        }
        public void WriteToCusatomerJsonFile(string filepath)
        {
            var json = JsonConvert.SerializeObject(customer);
            File.WriteAllText(filepath, json);
        }
        public void SellStocks(string name)
        {
            foreach (var data in customer)
            {
                int count = 0;
                if (data.StockName.Equals(name))
                {
                    Console.WriteLine("Available Amount :{0}", amount);
                    Console.WriteLine("Enter the number of stocks you need to sell : ");
                    int noOfStocks = Convert.ToInt32(Console.ReadLine());
                    if (noOfStocks <= data.NoOfShares)
                    {
                        StockDetails details = new StockDetails()
                        {
                            StockName = data.StockName,
                            StockPrice = data.StockPrice,
                            NoOfShares = noOfStocks
                        };
                        data.NoOfShares -= noOfStocks;
                        amount += noOfStocks * data.StockPrice;

                        foreach (var account in stock)
                        {
                            if (account.StockName.Equals(name))
                            {
                                count++;
                            }
                        }
                        if (count == 1)
                        {
                            data.NoOfShares -= noOfStocks;
                        }
                        else
                        {
                            customer.Add(details);
                        }
                    }

                }
            }
        }
        public void WriteSellToStockJsonFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(stock);
            File.WriteAllText(filePath, json);
        }
        public void WriteSellToCustomerJsonFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(customer);
            File.WriteAllText(filePath, json);
        }
    }
}
