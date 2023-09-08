using Dictionary.Domain.Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Data.Entity
{
    public class Word : EntityBase<int>
    {
        public string EngWord { get; private set; }
        public string RusWord { get; private set; }
        public string Transcription { get; private set; }
        public int UserId { get; private set; }

        public User User { get; private set; }

    }
}
