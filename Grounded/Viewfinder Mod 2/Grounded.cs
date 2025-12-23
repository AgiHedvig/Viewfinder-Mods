using HarmonyLib;
using HarmonyLib.Tools;
using Il2Cpp;
using Il2CppDreamteck.Splines.Primitives;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Grounded_Mod
{
    public class Grounded : MelonMod
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
            __instance.JumpUpSpeed = 0;
        }
    }
}