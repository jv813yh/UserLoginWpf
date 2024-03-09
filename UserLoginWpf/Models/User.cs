namespace UserLoginWpf.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
    }
}
