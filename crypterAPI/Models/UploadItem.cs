using System;
using System.Data;
using System.Threading.Tasks; 
using MySqlConnector;

namespace CrypterAPI.Models
{
    public class UploadItem
    {
        //unique key in database
        public long Id { get; set; }
        // item name/ title
        public string UntrustedName { get; set; }
        // user id/ tag, null if anonymous
        public string UserID { get; set; }
        // file size in Mb
        public float Size { get; set; }
        // file time stamp
        public DateTime TimeStamp { get; set;}

        internal CrypterDB Db{ get; set; }

        //constructor sets TimeStamp upon instantiation
        public UploadItem()
        {
            TimeStamp = DateTime.UtcNow; 
        }
        internal UploadItem(CrypterDB db)
        {
            Db = db; 
        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `TextUploadItems` (`UntrustedName`, `UserID`, `Size`, `TimeStamp`) VALUES (@untrustedname, @userid, @size, @timestamp);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `TextUploadItems` SET `UntrustedName` = @untrustedname, `UserID` = @userid, `Size` = @size, `TimeStamp` = @timestamp WHERE `Id` = @id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `TextUploadItems` WHERE `Id` = @id;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = Id,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@untrustedname",
                DbType = DbType.String,
                Value = UntrustedName,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@userid",
                DbType = DbType.String,
                Value = UserID,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@size",
                DbType = DbType.String,
                Value = Size,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@timestamp",
                DbType = DbType.String,
                Value = TimeStamp,
            });
        }

    }
}


//Sources/ Docs:
// https://mysqlconnector.net/tutorials/net-core-mvc/
// https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-5.0
// https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/mvc/models/file-uploads/samples/3.x/SampleApp/Models/AppFile.cs