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
        private static new HarmonyInstance harmonyInstance;

        public override void OnApplicationStart()
        {
            harmonyInstance = HarmonyInstance.Create("RubyMemes.OwO");
            PatchIt(typeof(Text));
            PatchIt(typeof(TextMesh));
            //Causes Crashes (at least in VRChat)
            //PatchIt(typeof(TMP_Text));

            foreach (MethodInfo method in typeof(MelonLogger).GetMethods(BindingFlags.Public | BindingFlags.Static))
            {
                try
                {
                    switch (method.Name)
                    {
                        case "Log":
                            ParameterInfo[] parameters = method.GetParameters();

                            if (parameters[0].ParameterType == typeof(object))
                            {
                                harmonyInstance.Patch(method, new HarmonyMethod(typeof(OwO).GetMethod(nameof(LogObjectFirstParam), BindingFlags.NonPublic | BindingFlags.Static)));
                                break;
                            }
                            else if (parameters[0].ParameterType == typeof(ConsoleColor))
                            {
                                if (parameters[1].ParameterType == typeof(string))
                                {
                                    harmonyInstance.Patch(method, new HarmonyMethod(typeof(OwO).GetMethod(nameof(LogStringSecondParam), BindingFlags.NonPublic | BindingFlags.Static)));
                                }
                                else
                                {
                                    harmonyInstance.Patch(method, new HarmonyMethod(typeof(OwO).GetMethod(nameof(LogObjectSecondParam), BindingFlags.NonPublic | BindingFlags.Static)));
                                }
                                break;
                            }
                            goto case "LogError";
                        case "LogWarning":
                        case "LogError":
                            harmonyInstance.Patch(method, new HarmonyMethod(typeof(OwO).GetMethod(nameof(LogStringFirstParam), BindingFlags.NonPublic | BindingFlags.Static)));
                            break;
                    }
                    MelonLogger.Log($"Patched {method.Name} To OwOify");
                }
                catch
                {
                    MelonLogger.Log($"FAIL! : Patched {method.Name} To OwOify");
                }
            }
        }

        private static void PatchIt(Type type)
        {
            try
            {
                harmonyInstance.Patch(type.GetProperty("text").GetGetMethod(),
                                      null,
                                      new HarmonyMethod(typeof(OwO).GetMethod(nameof(OwOify), BindingFlags.NonPublic | BindingFlags.Static))
                                     );
                MelonLogger.Log($"Patched {type.Name} To OwOify");
            }
            catch(Exception e)
            {
                MelonLogger.LogError($"FAIL! : Patched {type.Name} To OwOify\n{e}");
            }
        }

        private static readonly string[] owoFaces = { "OwO", "Owo", "owO", "ÓwÓ", "ÕwÕ", "@w@", "ØwØ", "øwø", "uwu", "UwU", "☆w☆", "✧w✧", "♥w♥", "゜w゜", "◕w◕", "ᅌwᅌ", "◔w◔", "ʘwʘ", "⓪w⓪", " ︠ʘw ︠ʘ", "(owo)" };
        private static readonly string[] owoStrings = { "OwO *what's this*", "OwO *notices bulge*", "uwu yu so warm~", "owo pounces on you~~" };
        private static readonly Random rnd = new Random();

        private static void LogObjectFirstParam(ref object __0)
        {
            string rep = __0.ToString();
            OwOify(ref rep);
            __0 = rep;
        }

        private static void LogStringSecondParam(ref string __1)
        {
            OwOify(ref __1);
        }

        private static void LogObjectSecondParam(ref object __1)
        {
            string rep = __1.ToString();
            OwOify(ref rep);
            __1 = rep;
        }

        private static void LogStringFirstParam(ref string __0)
        {
            OwOify(ref __0);
        }

        private static void OwOify(ref string __result)
        {
            if (!isOwOing)
                return;

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

