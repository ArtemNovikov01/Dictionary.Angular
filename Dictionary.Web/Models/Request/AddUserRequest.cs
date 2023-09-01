namespace Dictionary.Web.Models.Request
{
    public class AddUserRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
