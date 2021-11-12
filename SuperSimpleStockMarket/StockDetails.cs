using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSimpleStockMarket
{
    public class StockDetails
    {
        public string Symbol { get; set; }

        public string Type { get; set; }

        public double? LastDividend { get; set; }

        public double? FixedDividend { get; set ; }

        public double? ParValue { get; set; }

        public List<Trades> TradeDetails {  get; set; }
    }
}
