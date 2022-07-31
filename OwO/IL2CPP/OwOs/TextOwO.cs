using MelonLoader;
using System;
using System.Reflection;
using UnityEngine.UI;

namespace OwO_Mod
{
    internal static class TextOwO
    {
        static IntPtr _getText;

        public static unsafe void Init()
        {
            _getText = (IntPtr)typeof(Text).GetField("NativeMethodInfoPtr_get_text_Public_Virtual_New_get_String_0", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
            MelonUtils.NativeHookAttach(_getText, Utils.GetMethod(nameof(Patch)).MethodHandle.GetFunctionPointer());
        }

        internal static IntPtr Patch(IntPtr instance) => PatchUtils.OwOifyGetObj<Text>(_getText, instance);
    }
}
