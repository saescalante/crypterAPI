using System;
namespace CrypterAPI.Models
{
    public class UploadItem
    {
        //unique key in database
        public long Id { get; set; }
        // item name/ title
        public string Name { get; set; }
        // user id
        public string UserID { get; set; }
        // file size
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
