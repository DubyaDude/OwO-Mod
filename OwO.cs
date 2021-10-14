using Harmony;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;

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

