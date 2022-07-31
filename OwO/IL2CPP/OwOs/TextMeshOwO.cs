using MelonLoader;
using System;
using System.Reflection;
using UnityEngine;

namespace OwO_Mod
{
    internal static class TextMeshOwO
    {
        static IntPtr _getTextMesh;

        public static unsafe void Init()
        {
            _getTextMesh = (IntPtr)typeof(TextMesh).GetField("NativeMethodInfoPtr_get_text_Public_get_String_0", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
            MelonUtils.NativeHookAttach(_getTextMesh, Utils.GetMethod(nameof(Patch)).MethodHandle.GetFunctionPointer());
        }

        internal static IntPtr Patch(IntPtr instance) => PatchUtils.OwOifyGetObj<TextMesh>(_getTextMesh, instance);
    }
}
