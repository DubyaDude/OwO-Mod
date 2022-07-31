using HarmonyLib;
using System.Reflection;
using UnityEngine.UI;

namespace OwO_Mod
{
    internal static class TextOwO
    {
        static MethodInfo _getText;

        public static unsafe void Init()
        {
            _getText = typeof(Text).GetProperty(nameof(Text.text)).GetGetMethod();
            OwO.owoHarmonyInstance.Patch(_getText, postfix: new HarmonyMethod(Utils.GetMethod(nameof(Patch))));
        }

        internal static void Patch(ref string __result) => PatchUtils.OwOifyGetObj<Text>(ref __result);
    }
}
