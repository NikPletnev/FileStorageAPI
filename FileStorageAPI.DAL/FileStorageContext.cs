using FileStorageAPI.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace FileStorageAPI.DAL
{
    public class FileStorageContext : DbContext
    {
        public FileStorageContext(DbContextOptions<FileStorageContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<StoragedFile> StoragedFiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<StoragedFile>().ToTable("Files");


        }
    }
}