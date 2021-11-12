using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SuperSimpleStockMarket
{
    public class StockCalculations
    {
        private static List<StockDetails> _stockData;
        private const int VWAPwindow = 15;
        public StockCalculations(List<StockDetails> stockDetails)
        {
            _stockData = stockDetails;
        }

        public double? CalculateDividendYield(string StockSymbol, double? price)
        {
            var stock = _stockData.Where(s => s.Symbol == StockSymbol).FirstOrDefault();
            if (stock.Type.Equals("Common"))
            {
                return stock.LastDividend.Value / price.Value;
            }
            else if (stock.Type.Equals("Preferred"))
            {
                return ((stock.FixedDividend.Value/100) * stock.ParValue) / price.Value;
            }
            else
            { return null; }
            
            
        }

        public double CalculatePERatio(string StockSymbol, double? price)
        {
            var dividend = CalculateDividendYield(StockSymbol, price);
            return price.Value / dividend.Value;
        }

        public double CalculateVWAP(string StockSymbol)
        {
            
            var stock = _stockData.Where(s => s.Symbol == StockSymbol).FirstOrDefault();
            if(stock.TradeDetails == null || !stock.TradeDetails.Any())
            {
                throw new Exception("No trades associated for the given stock");
            }

            //get trades for last 15 minutes
            var eligibleTrades = stock.TradeDetails.OrderBy(o => o.TradeTime).Where(t => t.TradeTime >= DateTime.Now.AddMinutes(-VWAPwindow));

            double? summation = 0;
            double? totalQuantity = 0;
            foreach(var price in eligibleTrades)
            {
                summation += price.Price * price.Quantity;
                totalQuantity += price.Quantity;
            }

            return summation.Value / totalQuantity.Value;
        }

        public double CalculateGeometricMean()
        {
            var prices  = _stockData.Select(s => s.TradeDetails.Select(p => p.Price));
            List<double> price = new List<double>();
            foreach( var p in prices)
            {
                price.AddRange(p.Select(p => p).ToArray());
            }
            return GeometricMean(price.ToArray(), price.ToArray().Length);
        }

        private double GeometricMean(double[] allstockprices , int n)
        {
            double sum = 0;
            for (int p = 0; p < n; p++)
            {
                sum = sum + (double)Math.Log(allstockprices[p]);
            }
            sum = sum / n;
            return (double)Math.Exp(sum);
        }

    }
}
