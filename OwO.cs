using Harmony;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RubyMemes.OwO
{
    public class OwO : MelonMod
    {
        private static bool isOwOing = true;
        private static HarmonyInstance harmonyInstance;

        public override void OnApplicationStart()
        {
            harmonyInstance = HarmonyInstance.Create("RubyMemes.OwO");
            try
            {
                harmonyInstance.Patch(typeof(Text).GetProperty("text").GetGetMethod(), null, GetDetourMethod(nameof(GenericTextPatch)));
                //_getTextPointer = NET_SDK.SDK.GetAssembly("UnityEngine.UI").GetClass("Text", "UnityEngine.UI").GetProperty("text").GetGetMethod().Ptr;
               
                MelonModLogger.Log("Patched Text To OwOify");
            }
            catch (Exception e)
            {
                MelonModLogger.LogError("FAIL! : Patched Text To OwOify\n" + e.ToString());
            }

            try
            {
                harmonyInstance.Patch(typeof(TextMesh).GetProperty("text").GetGetMethod(), null, GetDetourMethod(nameof(GenericTextPatch)));
                //_getTextMeshPointer = NET_SDK.SDK.GetAssembly("UnityEngine.TextRenderingModule").GetClass("TextMesh", "UnityEngine").GetProperty("text").GetGetMethod().Ptr;
                
                MelonModLogger.Log("Patched TextMesh To OwOify");
            }
            catch (Exception e)
            {
                MelonModLogger.LogError("FAIL! : Patched TextMesh To OwOify\n" + e.ToString());
            }


            try
            {
                harmonyInstance.Patch(typeof(TMP_Text).GetProperty("text").GetGetMethod(), null, GetDetourMethod(nameof(GenericTextPatch)));
                //_getTextMeshProPointer = NET_SDK.SDK.GetAssemblies().First(x => x.Name.Contains("TextMeshPro")).GetClass("TMP_Text", "TMPro").GetProperty("text").GetGetMethod().Ptr;
               
                MelonModLogger.Log("Patched TextMeshPro To OwOify");
            }
            catch (Exception e)
            {
                MelonModLogger.LogError("FAIL! : Patched TextMeshPro To OwOify\n" + e.ToString());
            }
        }
        private static HarmonyMethod GetDetourMethod(string name) => new HarmonyMethod(typeof(OwO).GetMethod(name, BindingFlags.NonPublic | BindingFlags.Static));


        private static void GenericTextPatch(ref string __result)
        {
            if (isOwOing)
                __result = OwOify(__result);
        }

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

