using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ffhs_nmt2_translator_ui.Models
{
    public class TranslationRequest
    {
        public String inputs { get; set; }
        public String corrections { get; set; }
        public String model { get; set; }
    }
}
