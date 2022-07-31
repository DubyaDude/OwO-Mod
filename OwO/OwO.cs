using MelonLoader;
using System;

namespace OwO_Mod
{
    public class OwO : MelonMod
    {
        public static HarmonyLib.Harmony owoHarmonyInstance;
        public static MelonLogger.Instance owoLogger;

        public override void OnApplicationStart()
        {
            owoHarmonyInstance = this.HarmonyInstance;
            owoLogger = LoggerInstance;

            try
            {
                TextOwO.Init();
            }
            catch (Exception e)
            {
                MelonLogger.Warning("Error at Text: " + Environment.NewLine + e);
            }
            try
            {
                TextMeshOwO.Init();
            }
            catch (Exception e)
            {
                MelonLogger.Warning("Error at TextMesh: " + Environment.NewLine + e);
            }
            try
            {
                TMPOwO.Init();
            }
            catch (Exception e)
            {
                MelonLogger.Warning("Error at TextMeshPro: " + Environment.NewLine + e);
            }
        }
    }
}

