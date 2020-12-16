using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;

namespace RubyCore.OwO.Texts
{
    public class TextMeshProText : OwOMonoTextBase
    {
        public TextMeshProText() : base()
        {
            textType = typeof(TMP_Text);
        }
    }
}
