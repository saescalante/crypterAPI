using Microsoft.EntityFrameworkCore;

namespace CrypterAPI.Models

{
    public class TextUploadItemContext : DbContext
    {
        public TextUploadItemContext(DbContextOptions<TextUploadItemContext> options)
            : base(options)
        {
        }
        public DbSet<TextUploadItem> TextUploadItems { get; set; }
    }
}

