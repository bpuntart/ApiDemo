// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Series;
//
//    var weeklyPriceSerie = WeeklyPriceSerie.FromJson(jsonString);

using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestApis
{
    public partial class WeeklyPriceSerie
    {
        [JsonProperty("Meta Data")]
        public MetaData MetaData { get; set; }

        [JsonProperty("Weekly Time Series")]
        public Dictionary<DateTime, Serie> WeeklyTimeSeries { get; set; }
    }

    public class Serie
    {
        [JsonProperty("1. open")]
        public decimal Open { get; set; }

        [JsonProperty("2. high")]
        public decimal High { get; set; }

        [JsonProperty("3. low")]
        public decimal Low { get; set; }

        [JsonProperty("4. close")]
        public decimal Close { get; set; }

        [JsonProperty("5. volume")]
        public long Volume { get; set; }

    }

    public class MetaData
    {
        [JsonProperty("1. Information")]
        public string The1Information { get; set; }

        [JsonProperty("2. Symbol")]
        public string The2Symbol { get; set; }

        [JsonProperty("3. Last Refreshed")]
        public System.DateTimeOffset The3LastRefreshed { get; set; }

        [JsonProperty("4. Time Zone")]
        public string The4TimeZone { get; set; }
    }

    public partial class WeeklyPriceSerie
    {
        public static WeeklyPriceSerie FromJson(string json) => JsonConvert.DeserializeObject<WeeklyPriceSerie>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this WeeklyPriceSerie self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
        };
    }
}