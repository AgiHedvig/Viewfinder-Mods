using HarmonyLib;
using HarmonyLib.Tools;
using Il2Cpp;
using Il2CppDreamteck.Splines.Primitives;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bullet_Train
{
    public class BulletTrain : MelonMod
    {
        public override void OnInitializeMelon()
        {
            new HarmonyLib.Harmony("com.agihedvig.viewfinder.trainpatch").PatchAll();
        }
    }

    [HarmonyPatch(typeof(TrainMover))]
    [HarmonyPatch("ApplyMotion", MethodType.Normal)]
    public static class TrainMover_ApplyMotion_Patch1
    {
        static void Prefix(TrainMover __instance)
        {
                __instance.maxSpeed = 50;
        }
    }

    [HarmonyPatch(typeof(TrainMover))]
    [HarmonyPatch("ApplyMotion", MethodType.Normal)]
    public static class TrainMover_ApplyMotion_Patch2
    {
        static void Prefix(TrainMover __instance)
        {
                __instance.acceleration = 50;
        }
    }
}