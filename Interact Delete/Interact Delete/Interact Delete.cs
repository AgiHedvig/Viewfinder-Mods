using HarmonyLib;
using HarmonyLib.Tools;
using Il2CppDreamteck.Splines.Primitives;
using MelonLoader;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Interact_Delete
{
    public class InteractDelete : MelonMod
    {
        public override void OnUpdate()
        {
            GameObject environment1 = GameObject.Find("Unreferenced Capturable Environment");
            GameObject environment2 = GameObject.Find("Captureable Environment");
            GameObject environment3 = GameObject.Find("Non Captureable Environment");
            GameObject environment4 = GameObject.Find("Captureable Environment (1)");

            Transform environment1T = null;
            Transform environment2T = null;
            Transform environment3T = null;
            Transform environment4T = null;

            List<GameObject> list1 = new List<GameObject>();
            List<GameObject> list2 = new List<GameObject>();
            List<GameObject> list3 = new List<GameObject>();
            List<GameObject> list4 = new List<GameObject>();

            int rand;
            int rand2;
            int rand3;
            int rand4;

            if (environment1 != null)
                environment1T = environment1.transform;
            else
                MelonLogger.Warning("Unreferenced Capturable Environment not found");

            if (environment2 != null)
                environment2T = environment2.transform;
            else
                MelonLogger.Warning("Captureable Environment not found");

            if (environment3 != null)
                environment3T = environment3.transform;
            else
                MelonLogger.Warning("Non Captureable Environment not found");

            if (environment4 != null)
                environment4T = environment4.transform;
            else
                MelonLogger.Warning("Captureable Environment (1) not found");

            if (environment1T != null)
                AddChildren(environment1T, list1);

            if (environment2T != null)
                AddChildren(environment2T, list2);

            if (environment3T != null)
                AddChildren(environment3T, list3);

            if (environment4T != null)
                AddChildren(environment4T, list4);

            if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            {
                if (list1.Count > 0)
                {
                    for(int i = 0; i < 3; i++)
                    {
                        rand = UnityEngine.Random.Range(0, list1.Count);
                        UnityEngine.Object.Destroy(list1[rand]);
                        list1.RemoveAt(0);
                    }
                }

                if (list2.Count > 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        rand2 = UnityEngine.Random.Range(0, list2.Count);
                        UnityEngine.Object.Destroy(list2[rand2]);
                        list2.RemoveAt(0);
                    }
                }

                if (list3.Count > 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        rand3 = UnityEngine.Random.Range(0, list3.Count);
                        UnityEngine.Object.Destroy(list3[rand3]);
                        list3.RemoveAt(0);
                    }
                }

                if (list4.Count > 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        rand4 = UnityEngine.Random.Range(0, list4.Count);
                        UnityEngine.Object.Destroy(list4[rand4]);
                        list4.RemoveAt(0);
                    }
                }
            }
        }

        private void AddChildren(Transform parent, List<GameObject> list)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                list.Add(child.gameObject);
                AddChildren(child, list);
            }
        }
    }
}