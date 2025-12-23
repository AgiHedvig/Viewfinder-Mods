using HarmonyLib;
using HarmonyLib.Tools;
using Il2CppDreamteck.Splines.Primitives;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Small_Player
{
    public class SmallPlayer : MelonMod
    {
        public override void OnUpdate()
        {
            GameObject playerObject;

            playerObject = GameObject.FindGameObjectWithTag("Player");
            playerObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
    }
}