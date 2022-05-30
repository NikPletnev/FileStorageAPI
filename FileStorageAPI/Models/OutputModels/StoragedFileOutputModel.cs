namespace FileStorageAPI.Models.OutputModels
{
    public class StoragedFileOutputModel
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
    }
}
