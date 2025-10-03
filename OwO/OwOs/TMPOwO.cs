using System;
using System.Linq;
using System.Reflection;
using HarmonyLib;

namespace OwO_Mod
{
    internal static class TMPOwO
    {
        //In some versions of MelonLoader the namespaces can be prefixed with "Il2Cpp".
        //This method prevents the potential TypeLoadException.
        public static Type TMP_Text = GetTMP_TextDynamic();

        private static Type GetTMP_TextDynamic()
        {
            Assembly textMeshProAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetName().Name == "Unity.TextMeshPro");

            if (textMeshProAssembly == null) {
                throw new DllNotFoundException($"Could not locate assembly: \"Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\"");
            }

            return textMeshProAssembly.GetType("Il2CppTMPro.TMP_Text") ?? textMeshProAssembly.GetType("TMPro.TMP_Text");
        }

        public static unsafe void Init()
        {
            OwO.owoHarmonyInstance.Patch(TMP_Text.GetMethod("set_text"), new HarmonyMethod(Utils.GetMethod(nameof(Patch))));
        }

        internal static void Patch(ref string value)
        {
            value = Utils.OwOify(value);
        }
    }
}
