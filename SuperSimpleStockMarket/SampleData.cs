using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SuperSimpleStockMarket
{
    internal static class SampleData
    {
        private static List<StockDetails> stocks;
        private static List<Trades> trades;
        public static List<StockDetails> PrepareTestData()
        {
            if (stocks == null)
            {
                stocks = new List<StockDetails>();
                stocks.Add(new StockDetails
                {
                    Symbol = "TEA",
                    Type = "Common",
                    LastDividend = 0,
                    FixedDividend = null,
                    ParValue = 100

                });
                stocks.Add(new StockDetails
                {
                    Symbol = "POP",
                    Type = "Common",
                    LastDividend = 8,
                    FixedDividend = null,
                    ParValue = 100
                });
                stocks.Add(new StockDetails
                {
                    Symbol = "ALE",
                    Type = "Common",
                    LastDividend = 23,
                    FixedDividend = null,
                    ParValue = 60
                });
                stocks.Add(new StockDetails
                {
                    Symbol = "GIN",
                    Type = "Preferred",
                    LastDividend = 8,
                    FixedDividend = 2,
                    ParValue = 100
                });
                stocks.Add(new StockDetails
                {
                    Symbol = "JOE",
                    Type = "Common",
                    LastDividend = 13,
                    FixedDividend = null,
                    ParValue = 250,
                });
            }
            return stocks;
        }

        public static void RecordTrade(string stockSymbol)
        {
            if (new string[] { "TEA" ,  "POP" , "GIN"}.Contains(stockSymbol))
            {
                trades = new List<Trades>();
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now,
                    Price = 101.12,
                    Quantity = 8,
                    BuySellIndicator = "BUY"
                });
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now.AddMinutes(-1),
                    Price = 102.15,
                    Quantity = 1,
                    BuySellIndicator = "BUY"
                });
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now.AddMinutes(-15),
                    Price = 101.16,
                    Quantity = 3,
                    BuySellIndicator = "SELL"
                });
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now.AddMinutes(-4),
                    Price = 101.11,
                    Quantity = 4,
                    BuySellIndicator = "BUY"
                });
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now.AddMinutes(-3),
                    Price = 101.10,
                    Quantity = 7,
                    BuySellIndicator = "SELL"
                });
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now.AddMinutes(-19),
                    Price = 103.10,
                    Quantity = 7,
                    BuySellIndicator = "SELL"
                });

                stocks.Where(s => s.Symbol == stockSymbol).FirstOrDefault().TradeDetails = trades;

            }
            if (new string[] { "JOE" }.Contains(stockSymbol))
            {
                trades = new List<Trades>();
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now,
                    Price = 253.12,
                    Quantity = 8,
                    BuySellIndicator = "BUY"
                });
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now.AddMinutes(-1),
                    Price = 251.15,
                    Quantity = 1,
                    BuySellIndicator = "BUY"
                });
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now.AddMinutes(-14),
                    Price = 252.16,
                    Quantity = 3,
                    BuySellIndicator = "SELL"
                });
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now.AddMinutes(-5),
                    Price = 251.11,
                    Quantity = 4,
                    BuySellIndicator = "BUY"
                });
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now.AddMinutes(-4),
                    Price = 251.10,
                    Quantity = 7,
                    BuySellIndicator = "SELL"
                });
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now.AddMinutes(-19),
                    Price = 253.10,
                    Quantity = 7,
                    BuySellIndicator = "SELL"
                });
                stocks.Where(s => s.Symbol == stockSymbol).FirstOrDefault().TradeDetails = trades;

            }
            if (new string[] { "ALE" }.Contains(stockSymbol))
            {
                trades = new List<Trades>();
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now,
                    Price = 60.58,
                    Quantity = 8,
                    BuySellIndicator = "BUY"
                });
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now.AddMinutes(-1),
                    Price = 60.28,
                    Quantity = 1,
                    BuySellIndicator = "BUY"
                });
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now.AddMinutes(-13),
                    Price = 60.25,
                    Quantity = 3,
                    BuySellIndicator = "SELL"
                });
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now.AddMinutes(-4),
                    Price = 61.25,
                    Quantity = 4,
                    BuySellIndicator = "BUY"
                });
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now.AddMinutes(-3),
                    Price = 61.89,
                    Quantity = 7,
                    BuySellIndicator = "SELL"
                });
                trades.Add(new Trades
                {
                    TradeTime = DateTime.Now.AddMinutes(-19),
                    Price = 61.98,
                    Quantity = 7,
                    BuySellIndicator = "SELL"
                });
                
                stocks.Where(s => s.Symbol == stockSymbol).FirstOrDefault().TradeDetails = trades;

            }
                      
        }
    }
}
