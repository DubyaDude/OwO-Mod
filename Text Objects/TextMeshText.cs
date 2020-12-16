using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RubyCore.OwO.Texts
{
    public class TextMeshText : OwOMonoTextBase
    {
        public TextMeshText() : base()
        {
            textType = typeof(TextMesh);
        }
    }
}
