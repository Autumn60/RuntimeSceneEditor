using UnityEngine;

namespace RuntimeSceneEditor
{
  public class SceneEditorUI : MonoBehaviour
  {
    [SerializeField]
    private ScenePrefabDictionary prefabDictionary;

    [SerializeField]
    private GameObject prefabUI;
    [SerializeField]
    private Transform prefabListParent;

    private void Start()
    {
      foreach (var prefab in prefabDictionary.Prefabs)
      {
        var prefabUIInstance = Instantiate(prefabUI, prefabListParent);
        prefabUIInstance.GetComponent<PrefabUI>().Initialize(prefab);
      }
    }
  }
}
