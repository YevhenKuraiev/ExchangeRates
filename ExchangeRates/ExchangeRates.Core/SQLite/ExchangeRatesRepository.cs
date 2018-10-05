//using ExchangeRates.Core.Models;
//using ExchangeRates.Core.SQLite.Entities;
//using MvvmCross.Platform;
//using SQLite;
//using System.Collections.Generic;
//using System.Linq;

//namespace ExchangeRates.Core.SQLite
//{
//    public class ExchangeRatesRepository
//    {
//        private SQLiteConnection _connection;

//        public ExchangeRatesRepository()
//        {
//            string databasePath = Mvx.Resolve<ISQLite>().DatabasePath;
//            _connection = new SQLiteConnection(databasePath);
//            _connection.CreateTable<ExchangeRatesDTO>();
//        }

//        public IEnumerable<ExchangeRatesDTO> GetItems()
//        {
//            return (from i in _connection.Table<ExchangeRatesDTO>() select i).ToList();
//        }

//        public ExchangeRatesDTO GetItem(int id)
//        {
//            return _connection.Get<ExchangeRatesDTO>(id);
//        }

//        public int DeleteItem(int id)
//        {
//            return _connection.Delete<ExchangeRatesDTO>(id);
//        }

//        public int SaveItem(ExchangeRatesDTO item)
//        {
//            if (item.Id != 0)
//            {
//                _connection.Update(item);
//                return item.Id;
//            }
//            else
//            {
//                return _connection.Insert(item);
//            }
//        }

//        public void SaveItems(IEnumerable<ExchangeRatesDTO> item)
//        {
//            if (item != null)
//            {
//                _connection.UpdateAll(item);
//            }
//        }
//    }
//}
