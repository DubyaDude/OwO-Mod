using Harmony;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RubyCore.OwO.Utilities
{
    public static class Utils
    {
        private static readonly string[] owoFaces = { "OwO", "Owo", "owO", "ÓwÓ", "ÕwÕ", "@w@", "ØwØ", "øwø", "uwu", "UwU", "☆w☆", "✧w✧", "♥w♥", "゜w゜", "◕w◕", "ᅌwᅌ", "◔w◔", "ʘwʘ", "⓪w⓪", " ︠ʘw ︠ʘ", "(owo)" };
        private static readonly string[] owoStrings = { "OwO *what's this*", "OwO *notices bulge*", "uwu yu so warm~", "owo pounces on you~~" };
        private static readonly Random rnd = new Random();

        public static void PatchGenericGameText(Type type, HarmonyInstance harmonyInstance)
        {
            try
            {
                harmonyInstance.Patch(type.GetProperty("text").GetGetMethod(),
                                      null,
                                      new HarmonyMethod(typeof(Utils).GetMethod(nameof(OwOify), BindingFlags.Public | BindingFlags.Static))
                                     );
            }
            catch (Exception e)
            {
                MelonLogger.LogError($"FAIL! : Couldn't Patch {type.Name} To OwOify\n{e}");
            }
        }

        public static void OwOify(ref string __result)
        {
            if (string.IsNullOrEmpty(__result) || __result.Contains("color="))
                return;

            __result = __result.Replace('r', 'w').Replace('l', 'w').Replace('R', 'W').Replace('L', 'W');

            switch (rnd.Next(2))
            {
                case 0:
                    __result = __result.Replace("n", "ny");
                    break;
                case 1:
                    __result = __result.Replace("n", "nya");
                    break;
            }
            switch (rnd.Next(2))
            {
                case 0:
                    __result = __result.Replace("!", "!");
                    break;
                case 1:
                    __result = __result.Replace("!", $" {owoFaces[rnd.Next(owoFaces.Length)]}");
                    break;
            }
            switch (rnd.Next(2))
            {
                case 0:
                    __result = __result.Replace("?", "?!");
                    break;
                case 1:
                    __result = __result.Replace("?", $" {owoFaces[rnd.Next(owoFaces.Length)]}");
                    break;
            }
            switch (rnd.Next(31))
            {
                case 7:
                    __result += $" {owoStrings[rnd.Next(owoStrings.Length)]}";
                    break;
            }
        }
    }
}
