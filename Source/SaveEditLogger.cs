using System;
using Harmony;
using System.Reflection;

namespace JW_SaveEditLogger
{
    public class SaveEditLogger
    {

        public static void Init(string directory, string settingsJSON)
        {
            var harmony = HarmonyInstance.Create("JWolf.SaveEditLogger");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }


    }
}
