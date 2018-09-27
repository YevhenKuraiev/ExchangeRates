using Newtonsoft.Json;

namespace ExchangeRates.Core.Models
{
    public class ExchangeRatesModel
    {
        [JsonProperty(PropertyName = "ccy")]
        public string CurrencyCode { get; set; }

        [JsonProperty(PropertyName = "base_ccy")]
        public string NationalCurrencyCode { get; set; }

        [JsonProperty(PropertyName = "buy")]
        public string PurchaseRate { get; set; }

        [JsonProperty(PropertyName = "sale")]
        public string SalesRate { get; set; }

    }
}
