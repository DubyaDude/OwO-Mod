using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib;
using UnityEngine.UI;

namespace OwO_Mod
{
    internal static class TextOwO
    {
        static IntPtr _getTextPointer;

        public static unsafe void Init()
        {
            _getTextPointer = (IntPtr) typeof(Text).GetField("NativeMethodInfoPtr_get_text_Public_Virtual_New_get_String_0", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
            MelonUtils.NativeHookAttach(_getTextPointer, Utils.GetMethod(nameof(Patch)).MethodHandle.GetFunctionPointer());
        }

        internal static IntPtr Patch(IntPtr instance) => Utils.OwOifyGetObj<Text>(_getTextPointer, instance);
    }
}
