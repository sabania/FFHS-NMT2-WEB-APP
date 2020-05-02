using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ffhs_nmt2_translator_ui.Models
{
    public class TranslationResponse
    {
        public String outputs { get; set; }
        public String inputs { get; set; }
        public double scores { get; set; }
    }
}
