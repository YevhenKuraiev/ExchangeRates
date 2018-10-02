namespace ExchangeRates.Core.Models
{
    class DetailModel
    {
        private ExchangeRatesDTO _exchangeRates;
        public ExchangeRatesDTO ExchangeRates => _exchangeRates;
        public DetailModel(ExchangeRatesDTO exchangeRates)
        {
            _exchangeRates = exchangeRates;
        }
    }
}
