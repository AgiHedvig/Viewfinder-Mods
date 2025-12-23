using HarmonyLib;
using HarmonyLib.Tools;
using Il2Cpp;
using Il2CppDreamteck.Splines.Primitives;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Low_Gravity
{
    public class LowGravity : MelonMod
    {
        public override void OnInitializeMelon()
        {
            new HarmonyLib.Harmony("com.agihedvig.viewfinder.trainpatch").PatchAll();
        }
    }

    [HarmonyPatch(typeof(PlayerMovement))]
    [HarmonyPatch("GetVelocity", MethodType.Normal)]
    public static class PlayerMovement_Patch
    {
        static void Postfix(PlayerMovement __instance)
        {
            __instance.Gravity = new Vector3(0, -1, 0);
        }
    }
}