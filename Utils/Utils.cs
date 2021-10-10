using MelonLoader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib;
using UnityEngine;

namespace OwO_Mod
{
    public static class Utils
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
                        text = OwOify(text);
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
                    text = OwOify(text);
                    InvokeMethod(origMethodPtr, instance, new IntPtr[] { IL2CPP.il2cpp_string_new(text) });
                    return;
            }
            catch { }
            InvokeMethod(origMethodPtr, instance, new IntPtr[] { val });
        }

        public static MethodInfo GetMethod(string MethodName, BindingFlags bindingAttributes = BindingFlags.NonPublic | BindingFlags.Static)
        {
            StackTrace stackTrace = new StackTrace();
            try
            {
                Type callingType = stackTrace.GetFrame(1).GetMethod().DeclaringType;
                MethodInfo targetMethod = callingType.GetMethod(MethodName, bindingAttributes);

                if (targetMethod == null)
                    MelonLogger.Error($"Null Method Grab: Method:{MethodName} | Type {callingType}", ConsoleColor.Yellow);
                return targetMethod;

            }
            catch (Exception e)
            {
                MelonLogger.Error("This is so sad", e);
            }
            return null;
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

        static string[] owoFaces =
        {
            "OwO", "Owo", "owO", "ÓwÓ", "ÕwÕ", "@w@", "ØwØ", "øwø", "uwu", "UwU", "☆w☆", "✧w✧", "♥w♥", "゜w゜", "◕w◕",
            "ᅌwᅌ", "◔w◔", "ʘwʘ", "⓪w⓪", " ︠ʘw ︠ʘ", "(owo)"
        };

        static string[] owoStrings =
            {"OwO *what's this*", "OwO *notices bulge*", "uwu yu so warm~", "owo pounces on you~~"};

        static System.Random rnd = new System.Random();

        internal static string OwOify(string text)
        {
            if (string.IsNullOrEmpty(text) || text.Contains("color="))
                return text;

            text = text.Replace('r', 'w').Replace('l', 'w').Replace('R', 'W').Replace('L', 'W');

            switch (rnd.Next(2))
            {
                case 0:
                    text = text.Replace("n", "ny");
                    break;
                case 1:
                    text = text.Replace("n", "nya");
                    break;
            }

            switch (rnd.Next(2))
            {
                case 0:
                    text = text.Replace("!", "!");
                    break;
                case 1:
                    text = text.Replace("!", $" {owoFaces[rnd.Next(owoFaces.Length)]}");
                    break;
            }

            switch (rnd.Next(2))
            {
                case 0:
                    text = text.Replace("?", "?!");
                    break;
                case 1:
                    text = text.Replace("?", $" {owoFaces[rnd.Next(owoFaces.Length)]}");
                    break;
            }

            switch (rnd.Next(31))
            {
                case 7:
                    text += $" {owoStrings[rnd.Next(owoStrings.Length)]}";
                    break;
            }

            return text;
        }
    }
}
