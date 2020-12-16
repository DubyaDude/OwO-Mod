using Harmony;
using MelonLoader;
using RubyCore.OwO.Config;
using RubyCore.OwO.Texts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;

namespace RubyCore.OwO
{
    public class OwO : MelonMod
    {
        private static List<OwOTextBase> OwOTexts = new List<OwOTextBase>();
        private static List<OwOMonoTextBase> OwOMonoTexts = new List<OwOMonoTextBase>();

        public override void OnApplicationStart()
        {
            ConfigFile.Init();

            IEnumerable<Type> types = typeof(OwOTextBase).Assembly.GetTypes()
                .Where(y => y.IsSubclassOf(typeof(OwOTextBase)) && y.Name != typeof(OwOMonoTextBase).Name);


            foreach(Type type in types)
            {
                try
                {
                    if (ConfigFile.GetValue(type.Name))
                    {
                        var owoObj = (Activator.CreateInstance(type) as OwOTextBase);
                        owoObj.Patch();

                        if (type.IsSubclassOf(typeof(OwOMonoTextBase)))
                            OwOMonoTexts.Add((owoObj as OwOMonoTextBase));
                        else
                            OwOTexts.Add(owoObj);

                        MelonLogger.Log("Patched: " + type.Name);
                    }
                    else
                    {
                        MelonLogger.Log("Skipped: " + type.Name);
                    }
                }
                catch(Exception e)
                {
                    MelonLogger.Log("Failed: " + type.Name + "\n" + e);
                }
            }
        }

        public override void OnLevelWasLoaded(int level)
        {
            OwOMonoTexts.ForEach(x => x.OnLevelWasLoaded(level));
        }
    }
}

