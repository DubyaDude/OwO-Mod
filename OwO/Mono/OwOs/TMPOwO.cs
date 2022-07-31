using HarmonyLib;
using System.Reflection;
using TMPro;

namespace OwO_Mod
{
    internal static class TMPOwO
    {
        static MethodInfo _setTextMeshPro;

        public static unsafe void Init()
        {
            _setTextMeshPro = typeof(TMP_Text).GetProperty(nameof(TMP_Text.text)).GetSetMethod();
            OwO.owoHarmonyInstance.Patch(_setTextMeshPro, prefix: new HarmonyMethod(Utils.GetMethod(nameof(Patch))));
        }

        internal static void Patch(ref string __0) => PatchUtils.OwOifySetObj<TMP_Text>(ref __0);
    }
}
