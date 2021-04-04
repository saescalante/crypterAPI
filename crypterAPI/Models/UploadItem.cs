using System;
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
        public long Size { get; set; }
        // file time stamp
        public DateTime TimeStamp { get; set;}

        //constructor sets TimeStamp upon instantiation
        public UploadItem()
        {
            this.TimeStamp = DateTime.UtcNow; 
        }
    }
}


//Sources:
// https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-5.0
// https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/mvc/models/file-uploads/samples/3.x/SampleApp/Models/AppFile.cs