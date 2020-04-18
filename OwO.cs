using Harmony;
using MelonLoader;
using NET_SDK;
using NET_SDK.Harmony;
using NET_SDK.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;

namespace RubyMemes.OwO
{

    public class OwO : MelonMod
    {
        private static IntPtr _getTextPointer;
        private static IntPtr _getTextMeshPointer;
        private static IntPtr _getTextMeshProPointer;

        public override void OnApplicationStart()
        {
            try
            {
                _getTextPointer = NET_SDK.SDK.GetAssembly("UnityEngine.UI").GetClass("Text", "UnityEngine.UI").GetProperty("text").GetGetMethod().Ptr;
                HookOverrideCauseHerpREEEEEE(_getTextPointer, GetDetourMethod(nameof(TextPatch)));
                MelonModLogger.Log(_getTextPointer + " : Patched Text To OwOify");
            }
            catch (Exception e)
            {
                MelonModLogger.LogError("FAIL! : Patched Text To OwOify\n" + e.ToString());
            }

            try
            {
                _getTextMeshPointer = NET_SDK.SDK.GetAssembly("UnityEngine.TextRenderingModule").GetClass("TextMesh", "UnityEngine").GetProperty("text").GetGetMethod().Ptr;
                HookOverrideCauseHerpREEEEEE(_getTextMeshPointer, GetDetourMethod(nameof(TextMeshPatch)));
                MelonModLogger.Log(_getTextMeshPointer + " : Patched TextMesh To OwOify");
            }
            catch (Exception e)
            {
                MelonModLogger.LogError("FAIL! : Patched TextMesh To OwOify\n" + e.ToString());
            }


            try
            {
                _getTextMeshProPointer = NET_SDK.SDK.GetAssemblies().First(x => x.Name.Contains("TextMeshPro")).GetClass("TMP_Text", "TMPro").GetProperty("text").GetGetMethod().Ptr;
                HookOverrideCauseHerpREEEEEE(_getTextMeshProPointer, GetDetourMethod(nameof(TextMeshProPatch)));
                MelonModLogger.Log(_getTextMeshProPointer + " : Patched TextMeshPro To OwOify");
            }
            catch (Exception e)
            {
                MelonModLogger.LogError("FAIL! : Patched TextMeshPro To OwOify\n" + e.ToString());
            }
        }
        private static IntPtr GetDetourMethod(string name) => typeof(OwO).GetMethod(name, BindingFlags.NonPublic | BindingFlags.Static).MethodHandle.GetFunctionPointer();

        private static void HookOverrideCauseHerpREEEEEE(IntPtr orig, IntPtr reflect)
        {
            typeof(Imports).GetMethod("Hook", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, new object[] { orig, reflect });
        }

        private static IntPtr TextPatch(IntPtr instance)
        {
            return GenericTextPatch(instance, _getTextPointer);
        }

        private static IntPtr TextMeshPatch(IntPtr instance)
        {
            return GenericTextPatch(instance, _getTextMeshPointer);
        }

        private static IntPtr TextMeshProPatch(IntPtr instance)
        {

            IntPtr pointer = IL2CPP.InvokeMethod(_getTextMeshProPointer, instance);
            if (pointer.ToString().Contains("-") || pointer == IntPtr.Zero)
                return pointer;

            MelonLoader.MelonModLogger.Log(ConsoleColor.Red, "IT DONE DID IT TO THIS: " + IL2CPP.IntPtrToString(pointer));

            return GenericTextPatch(instance, _getTextMeshProPointer);
        }

        public static IntPtr GenericTextPatch(IntPtr instance, IntPtr original)
        {
            IntPtr pointer = IL2CPP.InvokeMethod(original, instance);
            if (pointer.ToString().Contains("-") || pointer == IntPtr.Zero)
                return pointer;

            if (isOwOOn)
                return IL2CPP.StringToIntPtr(OwOify(IL2CPP.IntPtrToString(pointer)));
            else
                return pointer;
        }

        private static bool isOwOOn = true;
        private static string[] owoFaces = { "OwO", "Owo", "owO", "ÓwÓ", "ÕwÕ", "@w@", "ØwØ", "øwø", "uwu", "UwU", "☆w☆", "✧w✧", "♥w♥", "゜w゜", "◕w◕", "ᅌwᅌ", "◔w◔", "ʘwʘ", "⓪w⓪", " ︠ʘw ︠ʘ", "(owo)" };
        private static string[] owoStrings = { "OwO *what's this*", "OwO *notices bulge*", "uwu yu so warm~", "owo pounces on you~~" };
        private static Random rnd = new Random();
        public static string OwOify(string text)
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

