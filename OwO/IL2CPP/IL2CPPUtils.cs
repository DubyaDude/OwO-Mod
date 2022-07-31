using System;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib;
using UnityEngine;

namespace OwO_Mod
{
    public static class IL2CPPUtils
    {
        public static IntPtr OwOifyGetObj<T>(IntPtr origMethodPtr, IntPtr instance)
        {
            try
            {
                IntPtr ret = InvokeMethod(origMethodPtr, instance);
                if (getClass(instance) == Il2CppType.Of<T>().TypeHandle.Value)
                {
                    try
                    {
                        string text = IntPtrToString(ret);
                        text = Utils.OwOify(text);
                        return IL2CPP.il2cpp_string_new(text);
                    }
                    catch { }
                }
                return ret;
            }
            catch
            {
                return IntPtr.Zero;
            }
        }

        public static void OwOifySetObj<T>(IntPtr origMethodPtr, IntPtr instance, IntPtr val) where T : MonoBehaviour
        {
            try
            {
                string text = IntPtrToString(val);
                text = Utils.OwOify(text);
                InvokeMethod(origMethodPtr, instance, new IntPtr[] { IL2CPP.il2cpp_string_new(text) });
                return;
            }
            catch { }
            InvokeMethod(origMethodPtr, instance, new IntPtr[] { val });
        }


        public static IntPtr getClass(IntPtr inst) => IL2CPP.il2cpp_class_get_type(IL2CPP.il2cpp_object_get_class(inst));

        public static unsafe string IntPtrToString(IntPtr ptr)
        {
            int length = IL2CPP.il2cpp_string_length(ptr);
            if (length <= 0) return string.Empty;
            return new string(IL2CPP.il2cpp_string_chars(ptr));
        }

        public unsafe static IntPtr InvokeMethod(IntPtr method, IntPtr obj, params IntPtr[] parameters)
        {
            fixed (void* parameterF = &parameters[0])
                return InvokeMethod(method, obj, (void**)parameterF);
        }

        public unsafe static IntPtr InvokeMethod(IntPtr method, IntPtr obj)
        {
            return InvokeMethod(method, obj, (void**)IntPtr.Zero);
        }

        public unsafe static IntPtr InvokeMethod(IntPtr method, IntPtr obj, void** parameters)
        {
            if (method == IntPtr.Zero)
                return IntPtr.Zero;
            IntPtr exc = IntPtr.Zero;
            IntPtr returnval = IL2CPP.il2cpp_runtime_invoke(method, obj, parameters, ref exc);
            if (exc != IntPtr.Zero)
            {
                throw new InvalidOperationException($"Invoke failed");
            }
            return returnval;
        }
    }
}
