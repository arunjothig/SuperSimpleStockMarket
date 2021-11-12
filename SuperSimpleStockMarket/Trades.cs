using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSimpleStockMarket
{
    public class Trades
    {
        public DateTime TradeTime { get; set; }
        public double Quantity { get; set; }
        public string BuySellIndicator { get; set; }
        public double Price { get; set; }

    }

    
}
