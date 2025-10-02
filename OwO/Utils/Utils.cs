using System;
using System.Diagnostics;
using System.Reflection;

namespace OwO_Mod
{
    public static class Utils
    {
        // Create a cache of already changed strings to prevent flickering of owoStrings when the text is getting set many times a second.
        // (And maybe improve performance??? It's probably negligible idk)
        public static Dictionary<string, string> alreadyAppliedOwOs = new Dictionary<string, string>();
        
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

            if (alreadyAppliedOwOs.ContainsKey(text) && alreadyAppliedOwOs[text] != null) {
                return alreadyAppliedOwOs[text];
            }
            
            string oldText = text;
            
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
            
            alreadyAppliedOwOs.Add(oldText, text);
            
            return text;
        }
    }
}
