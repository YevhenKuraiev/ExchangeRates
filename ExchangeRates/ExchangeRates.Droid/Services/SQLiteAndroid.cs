using System.IO;
using ExchangeRates.Core.SQLite;

namespace ExchangeRates.Droid.Services
{
    public class SQLiteAndroid : ISQLite
    {
        private const string DATABASE_FILE = "local.db";

        public SQLiteAndroid() {
        }

        public string DatabasePath
        {
            get
            {
                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var path = Path.Combine(documentsPath, DATABASE_FILE);
                return path;
            }
        }
    }
}