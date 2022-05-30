namespace FileStorageAPI.BLL.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<StoragedFileModel> StoragedFiles { get; set; }
    }
}
