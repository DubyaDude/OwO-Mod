using HarmonyLib;
using UnityEngine;

namespace OwO_Mod
{
    internal static class TextMeshOwO
    {
        public static unsafe void Init()
        {
            OwO.owoHarmonyInstance.Patch(typeof(TextMesh).GetMethod("set_text"), new HarmonyMethod(Utils.GetMethod(nameof(Patch))));
        }

        internal static void Patch(ref string value)
        {
            value = Utils.OwOify(value);
        }
    }
}
