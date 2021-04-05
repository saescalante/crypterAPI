using System;
using MySqlConnector;

namespace CrypterAPI.Models
{
    public class CrypterDB: IDisposable
    {
       public MySqlConnection Connection { get; }
       public CrypterDB(string connectionString)
        {
            Connection = new MySqlConnection(connectionString); 
        }

        public void Dispose() => Connection.Close(); 

    }
}
