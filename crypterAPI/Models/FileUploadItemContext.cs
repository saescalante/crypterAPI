
using Microsoft.EntityFrameworkCore;
namespace CrypterAPI.Models
{
    public class FileUploadItemContext : DbContext
    {
        public FileUploadItemContext(DbContextOptions<FileUploadItemContext> options)
            : base(options)
        {
        }
        public DbSet<FileUploadItem> FileUploadItems { get; set; }
    }
}
