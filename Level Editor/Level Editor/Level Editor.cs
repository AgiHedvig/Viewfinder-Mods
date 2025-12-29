using HarmonyLib;
using HarmonyLib.Tools;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Globalization;
using Il2Cpp;
using Unity.VisualScripting;

namespace Level_Editor
{
    public class LevelEditor : MelonMod
    {
        private bool inEditor;
        private float amount = 0.5f;
        private char mode;
        private string activeScene;
        private static GameObject lastHitObject;
        private List<GameObject> gameObjects = new List<GameObject>();
        private List<GameObject> undoList = new List<GameObject>();
        private GameObject spawn;
        private GameObject spawn2;
        private GameObject player;
        private char spawnChar;

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            activeScene = sceneName;
            MelonLogger.Msg(sceneName);
        }

        public override void OnUpdate()
        {
            player = GameObject.FindGameObjectWithTag("Player");

            if (Input.GetKeyDown(KeyCode.F9))
            {
                amount -= 0.05f;
                MelonLogger.Msg(amount);
            }

            if (Input.GetKeyDown(KeyCode.F10))
            {
                amount += 0.05f;
                MelonLogger.Msg(amount);
            }

            if (Input.GetKeyDown(KeyCode.F11))
            {
                amount = 0.5f;
                MelonLogger.Msg(amount);
            }

            if (Input.GetKeyDown(KeyCode.F1))
            {
                inEditor = true;
                mode = 'm';
                MelonLogger.Msg("In Editor: Move Mode");
            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                inEditor = true;
                mode = 'r';
                MelonLogger.Msg("In Editor: Rotate Mode");
            }

            if (Input.GetKeyDown(KeyCode.F3))
            {
                inEditor = true;
                mode = 's';
                MelonLogger.Msg("In Editor: Scale Mode");
            }

            if (Input.GetKeyDown(KeyCode.F4))
            {
                inEditor = false;
                MelonLogger.Msg("Out of Editor");
            }

            if (inEditor == true)
            {
                if (Input.GetKeyDown(KeyCode.F6))
                {
                    spawn = GameObject.Find("Default Player Spawn");

                    if (spawn == null)
                    {
                        spawnChar = 'f';
                        spawn2 = GameObject.Find("Spawn: Default");
                        spawn2.transform.position = player.transform.position;
                    }
                    else
                    {
                        spawnChar = 't';
                        spawn.transform.position = player.transform.position;
                    }
                }

                if (Input.GetKeyDown(KeyCode.F5))
                {
                    if (lastHitObject != null && !gameObjects.Contains(lastHitObject))
                    {
                        gameObjects.Add(lastHitObject);
                    }

                    SaveLevel();
                }

                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (lastHitObject != null && !gameObjects.Contains(lastHitObject))
                        {
                            gameObjects.Add(lastHitObject);
                        }

                        lastHitObject = hit.collider.gameObject;
                        MelonLogger.Msg("Selected: " + lastHitObject.name);
                    }
                }

                if(Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if(lastHitObject != null)
                    {
                        if(mode == 'm')
                        {
                            lastHitObject.transform.position = lastHitObject.transform.position + new Vector3(0, 0, amount);
                        }

                        if (mode == 'r')
                        {
                            lastHitObject.transform.Rotate(0, 0, amount);
                        }

                        if (mode == 's')
                        {
                            lastHitObject.transform.localScale = lastHitObject.transform.localScale + new Vector3(0, 0, amount);
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (lastHitObject != null)
                    {
                        if (mode == 'm')
                        {
                            lastHitObject.transform.position = lastHitObject.transform.position + new Vector3(0, 0, -amount);
                        }

                        if (mode == 'r')
                        {
                            lastHitObject.transform.Rotate(0, 0, -amount);
                        }

                        if (mode == 's')
                        {
                            lastHitObject.transform.localScale = lastHitObject.transform.localScale + new Vector3(0, 0, -amount);
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (lastHitObject != null)
                    {
                        if (mode == 'm')
                        {
                            lastHitObject.transform.position = lastHitObject.transform.position + new Vector3(amount, 0, 0);
                        }

                        if (mode == 'r')
                        {
                            lastHitObject.transform.Rotate(amount, 0, 0);
                        }

                        if (mode == 's')
                        {
                            lastHitObject.transform.localScale = lastHitObject.transform.localScale + new Vector3(amount, 0, 0);
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (lastHitObject != null)
                    {
                        if (mode == 'm')
                        {
                            lastHitObject.transform.position = lastHitObject.transform.position + new Vector3(-amount, 0, 0);
                        }

                        if (mode == 'r')
                        {
                            lastHitObject.transform.Rotate(-amount, 0, 0);
                        }

                        if (mode == 's')
                        {
                            lastHitObject.transform.localScale = lastHitObject.transform.localScale + new Vector3(-amount, 0, 0);
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.T))
                {
                    if (lastHitObject != null)
                    {
                        if (mode == 'm')
                        {
                            lastHitObject.transform.position = lastHitObject.transform.position + new Vector3(0, amount, 0);
                        }

                        if (mode == 'r')
                        {
                            lastHitObject.transform.Rotate(0, amount, 0);
                        }

                        if (mode == 's')
                        {
                            lastHitObject.transform.localScale = lastHitObject.transform.localScale + new Vector3(0, amount, 0);
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.G))
                {
                    if (lastHitObject != null)
                    {
                        if (mode == 'm')
                        {
                            lastHitObject.transform.position = lastHitObject.transform.position + new Vector3(0, -amount, 0);
                        }

                        if (mode == 'r')
                        {
                            lastHitObject.transform.Rotate(0, -amount, 0);
                        }

                        if (mode == 's')
                        {
                            lastHitObject.transform.localScale = lastHitObject.transform.localScale + new Vector3(0, -amount, 0);
                        }
                    }
                }

                if(lastHitObject != null)
                {
                    if (Input.GetKeyDown(KeyCode.Backspace))
                    {
                        undoList.Add(lastHitObject);
                        undoList[undoList.Count - 1].SetActive(false);
                    }
                }

                if(undoList.Count > 0)
                {
                    if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
                    {
                        undoList[undoList.Count - 1].SetActive(true);
                        undoList.Remove(undoList[undoList.Count - 1]);
                    }
                }
            }
        }

        string GetFullPath(GameObject go)
        {
            return go.transform.parent == null
                ? go.name
                : GetFullPath(go.transform.parent.gameObject) + "/" + go.name;
        }

        public void SaveLevel()
        {
            string filePath = Path.Combine("Mods", "CustomLevel.cs");

            int index = 0;

            string body = "";

            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObject obj = gameObjects[i];
                Vector3 pos = obj.transform.position;
                Vector3 sca = obj.transform.localScale;
                Quaternion rot = obj.transform.rotation;

                Vector3 playerPos = player.transform.position;

                string fx = pos.x.ToString(CultureInfo.InvariantCulture);
                string fy = pos.y.ToString(CultureInfo.InvariantCulture);
                string fz = pos.z.ToString(CultureInfo.InvariantCulture);

                string sx = sca.x.ToString(CultureInfo.InvariantCulture);
                string sy = sca.y.ToString(CultureInfo.InvariantCulture);
                string sz = sca.z.ToString(CultureInfo.InvariantCulture);

                string rx = rot.x.ToString(CultureInfo.InvariantCulture);
                string ry = rot.y.ToString(CultureInfo.InvariantCulture);
                string rz = rot.z.ToString(CultureInfo.InvariantCulture);
                string rw = rot.w.ToString(CultureInfo.InvariantCulture);

                string px = playerPos.x.ToString(CultureInfo.InvariantCulture);
                string py = playerPos.y.ToString(CultureInfo.InvariantCulture);
                string pz = playerPos.z.ToString(CultureInfo.InvariantCulture);

                string path = GetFullPath(obj);
                body += $"Transform t{i} = GameObject.Find(\"{path}\")?.transform;\n";
                body += $"if (t{i} != null) t{i}.position = new Vector3({fx}f, {fy}f, {fz}f);\n\n";
                body += $"if (t{i} != null) t{i}.rotation = new Quaternion({rx}f, {ry}f, {rz}f, {rw}f);\n\n";
                body += $"if (t{i} != null) t{i}.localScale = new Vector3({sx}f, {sy}f, {sz}f);\n\n";

                if (spawnChar == 't')
                {
                    body += $"Transform s{i} = GameObject.Find(\"Default Player Spawn\")?.transform;\n";
                    body += $"if (s{i} != null) s{i}.position = new Vector3({px}f, {py}f, {pz}f);\n\n";
                    spawnChar = 'n';
                }

                if (spawnChar == 'f')
                {
                    body += $"Transform s{i} = GameObject.Find(\"Spawn: Default\")?.transform;\n";
                    body += $"if (s{i} != null) s{i}.position = new Vector3({px}f, {py}f, {pz}f);\n\n";
                    spawnChar = 'n';
                }
            }

            if (undoList.Count > 0)
            {
                for (int i = 0; i < undoList.Count; i++)
                {
                    GameObject destroyObj = undoList[i];
                    string destroyPath = GetFullPath(destroyObj);

                    body += $"GameObject o{i} = GameObject.Find(\"{destroyPath}\")?.gameObject;\n";
                    body += $"if (o{i} != null) o{i}.SetActive(false);\n\n";
                }
            }

            string codeText = $@"
using HarmonyLib;
using HarmonyLib.Tools;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Custom_Level
{{
public class CustomLevel : MelonMod
{{
    public override void OnUpdate()
    {{
        if (SceneManager.GetActiveScene().name == ""{activeScene}"")
            {{
{body}
            }}}}
}}
}}
";

            File.WriteAllText(filePath, codeText);
        }
    }
}