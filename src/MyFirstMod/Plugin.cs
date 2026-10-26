using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace MyFirstMod {
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin {
        public const string PLUGIN_GUID = "dev.jayo.CUFirstMod";
        public const string PLUGIN_NAME = "MyFirstMod";
        public const string PLUGIN_VERSION = "1.0.0";
        
        internal static ManualLogSource Log;
        
        private void Awake() {
            // Bind the logger instance
            Log = Logger;
            
            var harmony = new Harmony(PLUGIN_GUID);
            
            // Your patch setup logic (e.g., Harmony) goes here
            

            try {
                harmony.PatchAll();
                
                Log.LogInfo($"Plugin {PLUGIN_NAME} patches applied successfully!");
            }
            catch {
                Log.LogInfo($"Plugin {PLUGIN_NAME} done messed up with the patches");
            }
        }
    }
}
