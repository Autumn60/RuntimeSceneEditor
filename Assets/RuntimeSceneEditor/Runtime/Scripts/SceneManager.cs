using System.IO;
using UnityEngine;

namespace RuntimeSceneEditor
{
  public class SceneManager : SingletonMonoBehaviour<SceneManager>
  {
    [SerializeField]
    public ScenePrefabDictionary PrefabDictionary;

    [SerializeField]
    private Scene scene;

    protected override void OnAwaking()
    {
    }

    protected override void OnDestroying()
    {
    }

    public void Update()
    {
      scene?.Update();
    }

    public void LoadSceneFrom(string jsonPath)
    {
      if (!File.Exists(jsonPath)) return;
      var json = File.ReadAllText(jsonPath);
      scene?.Destroy();
      scene = JsonUtility.FromJson<Scene>(json);
      scene?.Instantiate();
    }

    public bool SaveSceneTo(string jsonPath)
    {
      if (scene == null || Path.GetExtension(jsonPath) != ".json" || !Path.IsPathRooted(jsonPath))
      {
        return false;
      }
      var json = JsonUtility.ToJson(scene, true);
      File.WriteAllText(jsonPath, json);
      return true;
    }

    public void AddObjectToScene(SceneObject obj)
    {
      scene?.AddObject(obj);
    }

    public void RemoveObjectFromScene(SceneObject obj)
    {
      scene?.RemoveObject(obj);
    }
  }
}