using System;
using System.Diagnostics;
using System.Reflection;

namespace OwO_Mod
{
    public static class Utils
    {
        public static MethodInfo GetMethod(string MethodName, BindingFlags bindingAttributes = BindingFlags.NonPublic | BindingFlags.Static)
        {
            StackTrace stackTrace = new StackTrace();
            Type callingType = stackTrace.GetFrame(1).GetMethod().DeclaringType;
            return callingType.GetMethod(MethodName, bindingAttributes);
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
