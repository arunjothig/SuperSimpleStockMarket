using System;
using System.Collections.Generic;
using System.Linq;
 
namespace SuperSimpleStockMarket
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var data = SampleData.PrepareTestData();
                Console.WriteLine("Input stock symbol");
                var stock = Console.ReadLine();
                if (data.Any(sym => sym.Symbol == stock))
                {
                    StockCalculations calc = new StockCalculations(data);
                    Console.WriteLine("Input stock price");
                    var price = Console.ReadLine();
                    Console.WriteLine("Dividend Yield : " + calc.CalculateDividendYield(stock, Convert.ToDouble(price)));
                    Console.WriteLine("PE Ratio : " + calc.CalculatePERatio(stock, Convert.ToDouble(price)));
                    Console.WriteLine("Input 'Y' to capture trades and calcuate VWAP");
                    var option = Console.ReadLine();
                    if (option.ToUpper().Equals("Y"))
                    {
                        SampleData.RecordTrade(stock);
                        Console.WriteLine("Volume Weighted Average Price: " + calc.CalculateVWAP(stock));
                    }
                    else { Console.WriteLine("VWAP skipped"); }
                    Console.WriteLine("Input 'Y' to calcualte Geomteric mean");
                    var option1 = Console.ReadLine();
                    if (option1.ToUpper().Equals("Y"))
                    {
                        Console.WriteLine("Recording trades for stocks");
                        foreach (var stockdata in data)
                        {
                            if (stockdata.TradeDetails == null)
                            {
                                SampleData.RecordTrade(stockdata.Symbol);
                            }
                        }
                        Console.WriteLine("Geometric Mean of all stock prices : " + calc.CalculateGeometricMean());
                    }
                    else { Console.WriteLine("Geometric mean skipped"); }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid stock");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

      
    }
}
