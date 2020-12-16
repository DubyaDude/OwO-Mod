using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace RubyCore.OwO.Texts
{
    public class TextText : OwOMonoTextBase
    {
        public TextText() : base()
        {
            textType = typeof(Text);
        }

        public override void OnLevelWasLoaded(int level)
        {
            Text[] textobjects = Resources.FindObjectsOfTypeAll<Text>();
            foreach (Text text in textobjects)
            {
                text.cachedTextGenerator.Invalidate();
                text.SetAllDirty();
            }
        }
    }
}
