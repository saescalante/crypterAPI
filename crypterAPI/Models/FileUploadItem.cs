using System;
namespace CrypterAPI.Models
{
    // FileUpload inherits from UploadItem
    public class FileUploadItem : UploadItem
    {
        //file content is array of bytes
        //public byte[] FileContent { get; set; }
        public string FileContent { get; set; }
    }
}
