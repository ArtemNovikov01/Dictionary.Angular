namespace Dictionary.Web.Models.Request
{
    public class MatchConfirmationCodeRequest
    {
        public string Email { get; set; }
        public string ConfirmationCode { get; set; }
    }
}
