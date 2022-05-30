namespace FileStorageAPI.BLL.Models
{
    public class StoragedFileModel
    {
        public int Id;
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public UserModel User { get; set; }
        public bool IsDeleted { get; set; }
    }
}
