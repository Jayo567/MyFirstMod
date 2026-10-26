using HarmonyLib;

namespace MyFirstMod {
    [HarmonyPatch(typeof(Body))]
    [HarmonyPatch("Eat")]
    public class BodyPatch {
        [HarmonyPrefix]
        public static void BeforeEat(Body __instance, ref float hungerAmount, ref float weightGain) {
            Plugin.Log.LogInfo("[Eat Prefix] About to eat " + __instance.name);


            if (__instance.limbs != null) {

                foreach (Limb limb in __instance.limbs) {
                    limb.BreakBone();
                    Plugin.Log.LogInfo("[Eat Prefix] Bye bye Limb" + limb.name + "!");
                }
            }
        }
    }
}