namespace Dictionary.Web.Models.Request
{
    public class AddWordRequest
    {
        public string EngWord{ get; set; }
        public string RusWord { get; set; }
        public string Transcription { get; set; }
    }
}
