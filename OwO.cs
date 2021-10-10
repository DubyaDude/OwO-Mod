using Harmony;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;

namespace OwO_Mod
{
    public class OwO : MelonMod
    {
        public override void OnApplicationStart()
        {
            TextOwO.Init();
            TextMeshOwO.Init();
            TMPOwO.Init();
        }
    }
}

