using HarmonyLib;
using UnityEngine.UI;

namespace OwO_Mod
{
    internal static class TextOwO
    {
        public static unsafe void Init()
        {
            OwO.owoHarmonyInstance.Patch(typeof(Text).GetMethod("set_text"), new HarmonyMethod(Utils.GetMethod(nameof(Patch))));
        }

        internal static void Patch(ref string value)
        {
            value = Utils.OwOify(value);
        }
    }
}
