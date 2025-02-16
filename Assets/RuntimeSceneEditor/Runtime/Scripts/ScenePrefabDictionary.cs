using System;
using UnityEngine;
using UnityEditor;

namespace RuntimeSceneEditor
{
  [CreateAssetMenu(fileName = "ScenePrefabDictionary", menuName = "Runtime Scene Editor/Prefab Dictionary")]
  public class ScenePrefabDictionary : ScriptableObject
  {
    [SerializeField]
    private ScenePrefabData[] prefabs;
    public ScenePrefabData[] Prefabs => prefabs;

    public GameObject Find(string prefabId)
    {
      return Array.Find(prefabs, p => p.Id == prefabId)?.Prefab;
    }
  }
}
