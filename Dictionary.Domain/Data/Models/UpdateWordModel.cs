using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Data.Models
{
    public class UpdateWordModel
    {
        public string EngWord { get; set; }
        public string RusWord { get; set; }
        public string Transcription { get; set; }
    }
}
