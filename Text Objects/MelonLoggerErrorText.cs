using Harmony;
using MelonLoader;
using RubyCore.OwO.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RubyCore.OwO.Texts
{
    public class MelonLoggerErrorText : OwOTextBase
    {
        public override void Patch()
        {
            foreach (MethodInfo method in typeof(MelonLogger).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(method=> method.Name == "LogError"))
            {
                try
                {
                    harmonyInstance.Patch(method, new HarmonyMethod(typeof(MelonLoggerText).GetMethod(nameof(LogStringFirstParam), BindingFlags.NonPublic | BindingFlags.Static)));
                }
                catch
                {
                    MelonLogger.Log($"FAIL! : Patched MelonLogger.{method.Name} To OwOify");
                }
            }
        }

        private static void LogStringFirstParam(ref string __0)
        {
            Utils.OwOify(ref __0);
        }
    }
}
