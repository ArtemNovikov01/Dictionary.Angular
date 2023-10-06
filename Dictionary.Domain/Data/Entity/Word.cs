using Dictionary.Domain.Data.Entity.Base;
using Dictionary.Domain.Data.Models;
using Serilog;

namespace Dictionary.Domain.Data.Entity
{
    public class Word : EntityBase<int>
    {
        public Word() { }
        public Word(string engWord, string rusWord, string transcription)
        {
            EngWord = engWord;
            RusWord = rusWord;
            Transcription = transcription;
        }
        public Word(string engWord, string rusWord, string transcription, int userId) 
        {
            EngWord = engWord;
            RusWord = rusWord;
            Transcription = transcription;
            UserId = userId;
        }
        public string EngWord { get; private set; }
        public string RusWord { get; private set; }
        public string Transcription { get; private set; }
        public int UserId { get; private set; }

        public User User { get; private set; }

        public void Update(UpdateWordModel model)
        {
            EngWord = model.EngWord;
            RusWord = model.RusWord;
            Transcription = model.Transcription;
        }
    }
}
