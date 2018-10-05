using SQLite;

namespace ExchangeRates.Core.SQLite.Entities
{
    [Table("ExchangeRates")]
    public class ExchangeRate
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string CurrencyCode { get; set; }

        public string NationalCurrencyCode { get; set; }

        public string PurchaseRate { get; set; }

        public string SalesRate { get; set; }
    }
}
