using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubyCore.OwO.Config
{
    public static class ConfigFile
    {
        private static readonly string[] defaultlyFalse = new string[] { "TextMeshProText" };
        private static List<ConfigObject> configObjects = new List<ConfigObject>();
        private const string configFileName = "Mods\\OwO_Mod.txt";

        public static void Init()
        {
            Load();
            Save();
        }

        public static bool GetValue(string className)
        {
            bool? value = GetValueInternal(className);
            if (value.HasValue)
            {
                return value.Value;
            }
            else
            {
                AddNewValue(className);
                return GetValueInternal(className).Value;
            }
        }

        private static bool? GetValueInternal(string className)
        {
            try
            {
                return configObjects.Where(x => x.ClassName == className).First().Value;
            }
            catch
            {
                return null;
            }
        }

        private static void AddNewValue(string className)
        {
            configObjects.Add(new ConfigObject(className, (!defaultlyFalse.Contains(className)).ToString()));
            Save();
        }

        private static void Save()
        {
            File.WriteAllLines(configFileName, configObjects.Select(x => x.ToString()));
        }

        private static void Load()
        {
            if (File.Exists(configFileName))
            {
                string[] lines = File.ReadAllLines(configFileName);
                foreach (string line in lines)
                {
                    if (line.Contains(":"))
                    {
                        var splitted = line.Split(':');
                        if (splitted.Length == 2)
                        {
                            configObjects.Add(new ConfigObject(splitted[0], splitted[1]));
                        }
                    }
                }
            }
        }

        private class ConfigObject
        {
            public string ClassName;
            public bool Value;


            public ConfigObject(string className, string value)
            {
                ClassName = className;
                Value = value.ToLower().StartsWith("t");
            }

            public override string ToString()
            {
                return ClassName + ":" + Value;
            }
        }

    }

}
