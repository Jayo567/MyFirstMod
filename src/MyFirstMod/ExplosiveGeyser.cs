using HarmonyLib;
using UnityEngine;

namespace MyFirstMod {
    [HarmonyPatch(typeof(GeyserScript))]
    [HarmonyPatch("Activate")]
    public class ExplosiveGeyser {
        [HarmonyPrefix]
        public static void Postfix(GeyserScript __instance, ref Vector2 ___origPos) {
            var explosionParams = new ExplosionParams();
            Vector2 position = __instance.transform.position;

            explosionParams.boneBreakChance = 1;
            
            explosionParams.position = ___origPos;
            
            if (WorldGeneration.world) {
                WorldGeneration.CreateExplosion(explosionParams);
            }
        }
    }
}