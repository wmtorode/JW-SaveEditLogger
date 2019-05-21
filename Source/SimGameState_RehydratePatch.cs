using System;
using Harmony;
using BattleTech;
using BattleTech.Save;

namespace JW_SaveEditLogger
{
    [HarmonyPatch(typeof(SimGameState), "Rehydrate", typeof(GameInstanceSave))]
    class SimGameState_RehydratePatch
    {
        public static void Postfix(SimGameState __instance, GameInstanceSave gameInstanceSave)
        {
            if (__instance.CompanyStats.ContainsStatistic("BtSaveEdit.Version"))
            {
                string value = __instance.CompanyStats.GetValue<string>("BtSaveEdit.Version");
                SimGameState.logger.Log(string.Format("The save for this career/campaign has been edited by Save Editor version: {0}", (object) value));
            }
        }


    }
}
