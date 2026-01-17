namespace MinimalAPIs.DTOs
{
    public class UpdatePersonRequest
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public int age { get; set; }
        public string email { get; set; } = string.Empty;
    }
}
