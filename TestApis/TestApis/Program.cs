using System;
using System.Collections.Generic;
using TestApis.DAL;

namespace TestApis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var dataGetter = new DataGetter();

            IEnumerable<TimeSerie> items = dataGetter.GetWeeklyTimeSeriesForEquitiy(Equity.MSFT);
        }
    }

    internal class DataGetter
    {
        internal IEnumerable<TimeSerie> GetWeeklyTimeSeriesForEquitiy(Equity equity)
        {
            var consumer = new Consumer();

            var urlable = new Urlable()
            {
                Protocol = "https",
                ApiKey = "X45KWL2GJGCXJ8B0",
                BaseDomain = "www.alphavantage.co/query?",
                Function = "TIME_SERIES_WEEKLY",
                Parameters = new Dictionary<string, string>()
                {
                     {"symbol", equity.ToString()}
                }
            };

            var url = Consumer.urlBuilder(urlable);
                
            return Mapper.Map(consumer.Get(url));
        }
    }

    internal class Mapper
    {
        public static List<TimeSerie> Map(WeeklyPriceSerie get)
        {
           return new List<TimeSerie>();
        }
    }
    
    public interface IUrlable
    {
        string Protocol { get; set; }
        string BaseDomain { get; set; }
        string Function { get; set; }
        string ApiKey { get; set; }
        Dictionary<string, string> Parameters { get; set; }
    }

    public class Urlable : IUrlable
    {
        public string Protocol { get; set; }
        public string BaseDomain { get; set; }
        public string Function { get; set; }
        public string ApiKey { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }

    public class Equity
    {
        private string _typeKeyWord;

        private Equity(string typeKeyWord)
        {
            _typeKeyWord = typeKeyWord;
        }

        public override string ToString()
        {
            return _typeKeyWord;
        }

        public static Equity MSFT = new Equity("MSFT");
    }

    internal class TimeSerie
    {
        
    }
}
