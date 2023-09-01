namespace Dictionary.Web.Models.Request
{
    public class PasswordRecoveryRequest
    {
        public string Email { get; set; }
        public string ConfirmationCode { get; set; }
        public string Password { get; set; }
    }
}
