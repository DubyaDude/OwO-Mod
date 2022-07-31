using MelonLoader;
using System;

namespace OwO_Mod
{
    public class OwO : MelonMod
    {
        public override void OnApplicationStart()
        {
            try
            {
                TextOwO.Init();
            }
            catch(Exception e)
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

