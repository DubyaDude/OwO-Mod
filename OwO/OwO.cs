using System;
using MelonLoader;

namespace OwO_Mod
{
    public class OwO : MelonMod
    {
        public static HarmonyLib.Harmony owoHarmonyInstance;
        public static MelonLogger.Instance owoLogger;

        // Upgrade to new OnInitializeMelon because OnApplicationStart is depreciated.
        public override void OnInitializeMelon()
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

        // Clear cache for more randomness and strings that are not likely to appear outside their own scene.
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            Utils.alreadyAppliedOwOs.Clear();
        }
    }
}


