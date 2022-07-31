using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace OwO_Mod
{
    internal static class TextMeshOwO
    {
        static MethodInfo _getTextMesh;

        public static unsafe void Init()
        {
            _getTextMesh = typeof(TextMesh).GetProperty(nameof(TextMesh.text)).GetGetMethod();
            OwO.owoHarmonyInstance.Patch(_getTextMesh, postfix: new HarmonyMethod(Utils.GetMethod(nameof(Patch))));
        }

        internal static void Patch(ref string __result) => PatchUtils.OwOifyGetObj<TextMesh>(ref __result);
    }
}
