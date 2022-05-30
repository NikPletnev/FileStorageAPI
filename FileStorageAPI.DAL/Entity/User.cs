namespace FileStorageAPI.DAL.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<StoragedFile> StoragedFiles { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   Id == user.Id &&
                   Password == user.Password &&
                   Name == user.Name &&
                   IsDeleted == user.IsDeleted &&
                   EqualityComparer<ICollection<StoragedFile>>.Default.Equals(StoragedFiles, user.StoragedFiles);
        }
    }
}
