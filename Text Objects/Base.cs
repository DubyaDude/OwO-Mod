using Harmony;
using RubyCore.OwO.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RubyCore.OwO.Texts
{
    public class OwOTextBase
    {
        public OwOTextBase()
        {
            harmonyInstance = HarmonyInstance.Create("OwOMod." + this.GetType().Name);
        }

        protected HarmonyInstance harmonyInstance;
        public virtual void Patch() { }

        public virtual void UnPatch()
            => harmonyInstance.UnpatchAll();
    }

    public class OwOMonoTextBase : OwOTextBase
    {
        //Type for the object
        public Type textType { get; set; }

        public override void Patch()
            => Utils.PatchGenericGameText(textType, harmonyInstance);

        //If object needs a per-scene refresh
        public virtual void OnLevelWasLoaded(int level) { }
    }
}
