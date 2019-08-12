using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using VRLoader.Attributes;
using VRLoader.Modules;

namespace Ruby.Main
{
    [ModuleInfo("OwO Module", "vCutie-1.0", "DubyaDude Senpai and Native-kun <3")]

    public class OwO : VRModule
    {
        public static bool isOwOifyOn = true;

        public void Update()
        {
            if (isOwOifyOn)
            {
                Text[] texts = MonoBehaviour.FindObjectsOfType<Text>();

                foreach (Text text in texts)
                {
                    string textString = text.text;

                    //Filters out the text that has already been converted as well as those with special colors 
                    //(changes color to cowow)
                    if (!textString.Contains("⛧⛧⛧⛧⛧⛧⛧⛧⛧⛧⛧⛧⛧⛧⛧⛧⛧") && !textString.Contains("color="))
                    {
                        textString = Owoify(textString);

                        //⛧ is an invisible character in VRChat, therefore I used this as a 'tag' 
                        //to see if something was already converted or not.
                        text.text = textString + "⛧⛧⛧⛧⛧⛧⛧⛧⛧⛧⛧⛧⛧⛧⛧⛧⛧";
                    }
                }
            }
        }

        //The actual OwO-ify filter provided by Native
        public static System.Random randomizer = new System.Random();
        public static string Owoify(string text)
        {
            string[] owoFaces = { "OwO", "Owo", "owO", "ÓwÓ", "ÕwÕ", "@w@", "ØwØ", "øwø", "uwu", "UwU", "☆w☆", "✧w✧", "♥w♥", "゜w゜", "◕w◕", "ᅌwᅌ", "◔w◔", "ʘwʘ", "⓪w⓪", " ︠ʘw ︠ʘ", "(owo)" };
            string[] owoStrings = { "OwO *what's this*", "OwO *notices bulge*", "uwu yu so warm~", "owo pounces on you~~" };

            string owoified = text;
            owoified = owoified.Replace('r', 'w');
            owoified = owoified.Replace('l', 'w');
            owoified = owoified.Replace('R', 'W');
            owoified = owoified.Replace('L', 'W');

            switch (randomizer.Next(0, 1))
            {
                case 0:
                    owoified = owoified.Replace("n", "ny");
                    break;
                case 1:
                    owoified = owoified.Replace("n", "nya");
                    break;
            }
            switch (randomizer.Next(0, 1))
            {
                case 0:
                    owoified = owoified.Replace("!", "!");
                    break;
                case 1:
                    owoified = owoified.Replace("!", $" {owoFaces[randomizer.Next(0, owoFaces.Length)]}");
                    break;
            }
            switch (randomizer.Next(0, 1))
            {
                case 0:
                    owoified = owoified.Replace("?", "?!");
                    break;
                case 1:
                    owoified = owoified.Replace("?", $" {owoFaces[randomizer.Next(0, owoFaces.Length)]}");
                    break;
            }
            switch (randomizer.Next(0, 9))
            {
                case 7:
                    owoified = owoified += $" {owoStrings[randomizer.Next(0, owoStrings.Length)]}";
                    break;
            }

            return owoified;
        }
    }
}

