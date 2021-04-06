//using System.Collections.Generic;
//using System.Data;
//using System.Data.Common;
//using System.Threading.Tasks;
//using MySqlConnector;
//using CrypterAPI.Models; 


//namespace CrypterAPI.Controllers

//{
  
//    public class UploadItemQuery
//    {
//        public CrypterDB Db { get; }
//        public UploadItemQuery(CrypterDB db)
//        {
//            Db = db; 
//        }

//        public async Task<UploadItem> FindOneAsync(int id)
//        {
//            using var cmd = Db.Connection.CreateCommand();
//            cmd.CommandText = @"SELECT `Id`, `UntrustedName`, `UserID`, `Size`, `TimeStamp` FROM `TextUploadItems` WHERE `Id` = @id";
//            cmd.Parameters.Add(new MySqlParameter
//            {
//                ParameterName = "@id",
//                DbType = DbType.Int32,
//                Value = id,
//            });
//            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
//            return result.Count > 0 ? result[0] : null;
//        }

//        public async Task<List<UploadItem>> LatestItemsAsync()
//        {
//            using var cmd = Db.Connection.CreateCommand();
//            cmd.CommandText = @"SELECT `Id`, `UntrustedName`, `UserID`, `Size`, `TimeStamp` FROM `TextUploadItems` ORDER BY `Id` DESC LIMIT 10;";
//            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
//        }

//        public async Task DeleteAllAsync()
//        {
//            using var txn = await Db.Connection.BeginTransactionAsync();
//            using var cmd = Db.Connection.CreateCommand();
//            cmd.CommandText = @"DELETE FROM `UploadItems`";
//            await cmd.ExecuteNonQueryAsync();
//            await txn.CommitAsync();
//        }

//        private async Task<List<UploadItem>> ReadAllAsync(DbDataReader reader)
//        {
//            var items = new List<UploadItem>();
//            using (reader)
//            {
//                while (await reader.ReadAsync())
//                {
//                    var item = new UploadItem(Db)
//                    {
//                        Id = reader.GetInt32(0),
//                        UntrustedName = reader.GetString(1),
//                        UserID = reader.GetString(2),
//                        Size = reader.GetFloat(3),
//                        TimeStamp = reader.GetDateTime(4)
//                    };
//                    items.Add(item);
//                }
//            }
//            return items;
//        }
//    }
//}