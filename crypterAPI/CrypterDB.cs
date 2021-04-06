﻿using System;
using MySqlConnector;

namespace CrypterAPI
{
    public class CrypterDB: IDisposable
    {
       public MySqlConnection Connection { get; }
       public CrypterDB(string connectionString)
        {
            Connection = new MySqlConnection(connectionString); 
        }

        public void Dispose() => Connection.Dispose(); 

    }
}
