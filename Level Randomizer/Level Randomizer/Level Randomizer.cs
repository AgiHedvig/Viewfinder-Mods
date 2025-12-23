using HarmonyLib;
using HarmonyLib.Tools;
using Il2CppDreamteck.Splines.Primitives;
using MelonLoader;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level_Randomizer
{
    public class LevelRandomizer : MelonMod
    {
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
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

            int rand1;
            int rand12;
            int rand13;
            int rand2;
            int rand22;
            int rand23;
            int rand3;
            int rand32;
            int rand33;
            int rand4;
            int rand42;
            int rand43;

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

            GameObject teleporter = GameObject.Find("Transporter v2 Powerable");
            GameObject teleporter2 = GameObject.Find("Transporter v2 Powerable Purple");
            GameObject teleporter3 = GameObject.Find("Transporter v2 Captureable");

            bool IsTeleporterOrChild(Transform t)
            {
                if (teleporter != null)
                {
                    if (t == teleporter.transform)
                        return true;

                    if (t.IsChildOf(teleporter.transform))
                        return true;
                }

                if (teleporter2 != null)
                {
                    if (t == teleporter2.transform)
                        return true;

                    if (t.IsChildOf(teleporter2.transform))
                        return true;
                }

                if (teleporter3 != null)
                {
                    if (t == teleporter3.transform)
                        return true;

                    if (t.IsChildOf(teleporter3.transform))
                        return true;
                }

                return false;
            }

            for (int i = 0; i < list1.Count; i++)
            {
                rand1 = UnityEngine.Random.Range(0, 15);
                rand12 = UnityEngine.Random.Range(0, 15);
                rand13 = UnityEngine.Random.Range(0, 15);

                if (!IsTeleporterOrChild(list1[i].transform))
                    list1[i].transform.position = new Vector3(rand1, rand12, rand13);

                rand1 = UnityEngine.Random.Range(0, 45);
                rand12 = UnityEngine.Random.Range(0, 45);
                rand13 = UnityEngine.Random.Range(0, 45);

                if (!IsTeleporterOrChild(list1[i].transform))
                    list1[i].transform.rotation = new Quaternion(rand1, rand12, rand13, 0);
            }

            for (int i = 0; i < list2.Count; i++)
            {
                rand2 = UnityEngine.Random.Range(0, 15);
                rand22 = UnityEngine.Random.Range(0, 15);
                rand23 = UnityEngine.Random.Range(0, 15);

                if (!IsTeleporterOrChild(list2[i].transform))
                    list2[i].transform.position = new Vector3(rand2, rand22, rand23);

                rand2 = UnityEngine.Random.Range(0, 45);
                rand22 = UnityEngine.Random.Range(0, 45);
                rand23 = UnityEngine.Random.Range(0, 45);

                if (!IsTeleporterOrChild(list2[i].transform))
                    list2[i].transform.rotation = new Quaternion(rand2, rand22, rand23, 0);
            }

            for (int i = 0; i < list3.Count; i++)
            {
                rand3 = UnityEngine.Random.Range(0, 18);
                rand32 = UnityEngine.Random.Range(0, 18);
                rand33 = UnityEngine.Random.Range(0, 18);

                if (!IsTeleporterOrChild(list3[i].transform))
                    list3[i].transform.position = new Vector3(rand3, rand32, rand33);

                rand3 = UnityEngine.Random.Range(0, 45);
                rand32 = UnityEngine.Random.Range(0, 45);
                rand33 = UnityEngine.Random.Range(0, 45);

                if (!IsTeleporterOrChild(list3[i].transform))
                    list3[i].transform.rotation = new Quaternion(rand3, rand32, rand33, 0);
            }

            for (int i = 0; i < list4.Count; i++)
            {
                rand4 = UnityEngine.Random.Range(0, 18);
                rand42 = UnityEngine.Random.Range(0, 18);
                rand43 = UnityEngine.Random.Range(0, 18);

                if (!IsTeleporterOrChild(list4[i].transform))
                    list4[i].transform.position = new Vector3(rand4, rand42, rand43);

                rand4 = UnityEngine.Random.Range(0, 45);
                rand42 = UnityEngine.Random.Range(0, 45);
                rand43 = UnityEngine.Random.Range(0, 45);

                if (!IsTeleporterOrChild(list4[i].transform))
                    list4[i].transform.rotation = new Quaternion(rand4, rand42, rand43, 0);
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