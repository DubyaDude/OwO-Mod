using Harmony;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using VRLoader.Attributes;
using VRLoader.Modules;

namespace Ruby.Main
{
    [ModuleInfo("OwO Module", "vCutie-2.2", "DubyaDude Senpai, Native-kun <3, and Herp Derpinstine")]
    public class OwO : VRModule
    {
        public void Start()
        {
            HarmonyInstance harmonyInstance = HarmonyInstance.Create("OwO");
            harmonyInstance.Patch(typeof(Text).GetProperty("text").GetGetMethod(), null, new HarmonyMethod(typeof(OwO).GetMethod("GetText", BindingFlags.Static | BindingFlags.NonPublic)));
        }

        private static void GetText(ref string __result) { Owoify(ref __result); }

        public static void Owoify(ref string text)
        {
            if (!string.IsNullOrEmpty(text) && !text.Contains("color="))
            {
                string[] owoFaces = { "OwO", "Owo", "owO", "ÓwÓ", "ÕwÕ", "@w@", "ØwØ", "øwø", "uwu", "UwU", "☆w☆", "✧w✧", "♥w♥", "゜w゜", "◕w◕", "ᅌwᅌ", "◔w◔", "ʘwʘ", "⓪w⓪", " ︠ʘw ︠ʘ", "(owo)" };
                string[] owoStrings = { "OwO *what's this*", "OwO *notices bulge*", "uwu yu so warm~", "owo pounces on you~~" };

                text = text.Replace('r', 'w').Replace('l', 'w').Replace('R', 'W').Replace('L', 'W');

                switch (Random.Range(0, 1))
                {
                    case 0:
                        text = text.Replace("n", "ny");
                        break;
                    case 1:
                        text = text.Replace("n", "nya");
                        break;
                }
                switch (Random.Range(0, 1))
                {
                    case 0:
                        text = text.Replace("!", "!");
                        break;
                    case 1:
                        text = text.Replace("!", owoFaces[Random.Range(0, owoFaces.Length)]);
                        break;
                }
                switch (Random.Range(0, 1))
                {
                    case 0:
                        text = text.Replace("?", "?!");
                        break;
                    case 1:
                        text = text.Replace("?", owoFaces[Random.Range(0, owoFaces.Length)]);
                        break;
                }
                switch (Random.Range(0, 30))
                {
                    case 7:
                        text = text += owoStrings[Random.Range(0, owoStrings.Length)];
                        break;
                }
            }
        }
    }
}