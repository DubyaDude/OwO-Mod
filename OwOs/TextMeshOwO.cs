using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib;
using UnityEngine;

namespace OwO_Mod
{
    internal static class TextMeshOwO
    {
        static IntPtr _getTextMeshPointer;

        public static unsafe void Init()
        {
            _getTextMeshPointer = (IntPtr) typeof(TextMesh).GetField("NativeMethodInfoPtr_get_text_Public_get_String_0", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
            MelonUtils.NativeHookAttach(_getTextMeshPointer, Utils.GetMethod(nameof(Patch)).MethodHandle.GetFunctionPointer());
        }

        internal static IntPtr Patch(IntPtr instance) => Utils.OwOifyGetObj<TextMesh>(_getTextMeshPointer, instance);
    }
}
