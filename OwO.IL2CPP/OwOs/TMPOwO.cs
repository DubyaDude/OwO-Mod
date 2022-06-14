using MelonLoader;
using System;
using System.Reflection;
using TMPro;

namespace OwO_Mod
{
    internal static class TMPOwO
    {
        static IntPtr _getTextMeshPointer;

        public static unsafe void Init()
        {
            _getTextMeshPointer = (IntPtr) typeof(TMP_Text).GetField("NativeMethodInfoPtr_set_text_Public_Virtual_New_set_Void_String_0", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
            MelonUtils.NativeHookAttach(_getTextMeshPointer, Utils.GetMethod(nameof(Patch)).MethodHandle.GetFunctionPointer());
        }

        internal static void Patch(IntPtr instance, IntPtr text) => IL2CPPUtils.OwOifySetObj<TMP_Text>(_getTextMeshPointer, instance, text);
    }
}
