namespace FileStorageAPI.Models.InputModels
{
    public class StoragedFileInputModel
    {
        public int Id;
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int UserId { get; set; }
    }
}
