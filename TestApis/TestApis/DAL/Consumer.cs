using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;


namespace TestApis.DAL
{
    public class Consumer
    {
        private WebRequester _requester;

        public Consumer()
        {
            _requester = new WebRequester();
        }

        public WeeklyPriceSerie Get(string url)
        {
            var returnString = _requester.GET(url);
            var returnValues = WeeklyPriceSerie.FromJson(returnString);
            return returnValues;
        }

        public static string urlBuilder(IUrlable url)
        {
            var result = $"{url.Protocol}://{url.BaseDomain}function={url.Function}";
            result = url.Parameters.Aggregate(result, (current, parameter) => current + $"&{parameter.Key}={parameter.Value}");
            result += $"&apikey={url.ApiKey}";
            return result;
        }
    }
}