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

                if (__instance.CompanyStats.ContainsStatistic("BtSaveEdit.LogCount"))
                {
                    int logCount = __instance.CompanyStats.GetValue<int>("BtSaveEdit.LogCount");
                    if (logCount > 0)
                    {
                        SimGameState.logger.Log("Most recent save edits:");
                        for (int i = 0; i < logCount; i++)
                        {
                            if (__instance.CompanyStats.ContainsStatistic(string.Format("BtSaveEdit.LogItem{0}", (object) i)))
                            {
                                string log = __instance.CompanyStats.GetValue<string>(string.Format("BtSaveEdit.LogItem{0}", (object)i));
                                SimGameState.logger.Log(string.Format("{0}: {1}", (object)i, (object) log));
                            }
                        }
                    }
                }
            }
        }


    }
}
