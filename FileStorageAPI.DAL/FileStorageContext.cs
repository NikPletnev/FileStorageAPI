using FileStorageAPI.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FileStorageContext>
    {
        public FileStorageContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FileStorageContext>();
            builder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FileStorageDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var context = new FileStorageContext(builder.Options);
            return context;
        }
    }
}