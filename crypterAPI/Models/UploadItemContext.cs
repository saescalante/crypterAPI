using System;
using Microsoft.EntityFrameworkCore; 

namespace CrypterAPI.Models

{
    public class UploadItemContext : DbContext
    {
        public UploadItemContext(DbContextOptions<UploadItemContext> options)
            : base(options)
        {
        }
        public DbSet<UploadItem> UploadItems { get; set; }
    }
}
