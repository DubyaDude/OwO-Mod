using MelonLoader;
using System;
using System.Reflection;
using TMPro;

namespace OwO_Mod
{
    internal static class TMPOwO
    {
        static IntPtr _setTextMeshPro;

        public static unsafe void Init()
        {
            _setTextMeshPro = (IntPtr)typeof(TMP_Text).GetField("NativeMethodInfoPtr_set_text_Public_Virtual_New_set_Void_String_0", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
            MelonUtils.NativeHookAttach(_setTextMeshPro, Utils.GetMethod(nameof(Patch)).MethodHandle.GetFunctionPointer());
        }

        internal static void Patch(IntPtr instance, IntPtr text) => PatchUtils.OwOifySetObj<TMP_Text>(_setTextMeshPro, instance, text);
    }
}
