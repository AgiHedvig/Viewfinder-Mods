using HarmonyLib;
using HarmonyLib.Tools;
using Il2CppDreamteck.Splines.Primitives;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rotating_Levels
{
    public class RotatingLevels : MelonMod
    {
        public override void OnUpdate()
        {
            GameObject environment;

            environment = GameObject.Find("Unreferenced Capturable Environment");
            environment.transform.Rotate(new Vector3(0, 0, 0.02f));

            environment = GameObject.Find("Captureable Environment");
            environment.transform.Rotate(new Vector3(0, 0, 0.02f));

            environment = GameObject.Find("Non Captureable Environment");
            environment.transform.Rotate(new Vector3(0, 0, 0.02f));
        }
    }
}