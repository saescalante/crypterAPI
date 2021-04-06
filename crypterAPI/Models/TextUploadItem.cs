using System;
namespace CrypterAPI.Models
{
    //TextUpload inherits from UploadItem
    public class TextUploadItem : UploadItem
    {
        //add additional members/ methods unique to text uploads
        public int CharCount { get; set; }
        public string Message { get; set; }
    }
}
