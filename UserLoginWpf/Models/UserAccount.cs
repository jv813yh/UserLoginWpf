namespace UserLoginWpf.Models
{
    public class UserAccount
    {
        public string Username { get; set; } = "";
        public string DisplayName { get; set; } = "";
        public byte[]? ProfilesPicture { get; set; } = null;
    }
}
