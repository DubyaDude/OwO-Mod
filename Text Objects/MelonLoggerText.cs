using Harmony;
using MelonLoader;
using RubyCore.OwO.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RubyCore.OwO.Texts
{
    public class MelonLoggerText : OwOTextBase
    {
        public override void Patch()
        {
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
                                harmonyInstance.Patch(method, new HarmonyMethod(typeof(MelonLoggerText).GetMethod(nameof(LogObjectFirstParam), BindingFlags.NonPublic | BindingFlags.Static)));
                                break;
                            }
                            else if (parameters[0].ParameterType == typeof(ConsoleColor))
                            {
                                if (parameters[1].ParameterType == typeof(string))
                                {
                                    harmonyInstance.Patch(method, new HarmonyMethod(typeof(MelonLoggerText).GetMethod(nameof(LogStringSecondParam), BindingFlags.NonPublic | BindingFlags.Static)));
                                }
                                else
                                {
                                    harmonyInstance.Patch(method, new HarmonyMethod(typeof(MelonLoggerText).GetMethod(nameof(LogObjectSecondParam), BindingFlags.NonPublic | BindingFlags.Static)));
                                }
                                break;
                            }
                            goto case "LogError";
                        case "LogWarning":
                        case "LogError":
                            harmonyInstance.Patch(method, new HarmonyMethod(typeof(MelonLoggerText).GetMethod(nameof(LogStringFirstParam), BindingFlags.NonPublic | BindingFlags.Static)));
                            break;
                    }
                }
                catch
                {
                    MelonLogger.Log($"FAIL! : Patched MelonLogger.{method.Name} To OwOify");
                }
            }
        }

        private static void LogObjectFirstParam(ref object __0)
        {
            string rep = __0.ToString();
            Utils.OwOify(ref rep);
            __0 = rep;
        }

        private static void LogStringSecondParam(ref string __1)
        {
            Utils.OwOify(ref __1);
        }

        private static void LogObjectSecondParam(ref object __1)
        {
            string rep = __1.ToString();
            Utils.OwOify(ref rep);
            __1 = rep;
        }

        private static void LogStringFirstParam(ref string __0)
        {
            Utils.OwOify(ref __0);
        }
    }
}
