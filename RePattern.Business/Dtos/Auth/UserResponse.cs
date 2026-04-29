namespace RePattern.Business.Dtos.Auth
{
    public record UserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
