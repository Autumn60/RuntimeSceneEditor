using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

namespace RuntimeSceneEditor
{
  [System.Serializable]
  public class SceneObject
  {
    [SerializeField]
    private string objectName;
    [SerializeField]
    private string prefabId;
    [SerializeField]
    private Vector3 position;
    [SerializeField]
    private Quaternion rotation;

    GameObject instance;
    public GameObject Instance => instance;

    public static SceneObject Instantiate(string objectName, string prefabId, Vector3 position, Quaternion rotation)
    {
      var obj = new SceneObject
      {
        objectName = objectName,
        prefabId = prefabId,
        position = position,
        rotation = rotation
      };
      obj.Instantiate();
      SceneManager.Instance.AddObjectToScene(obj);
      return obj;
    }

    ~SceneObject()
    {
      Destroy();
    }

    public void Instantiate()
    {
      var prefab = SceneManager.Instance.PrefabDictionary.Find(prefabId);
      if (prefab == null) return;
      instance = GameObject.Instantiate(prefab, position, rotation);
      instance.name = objectName;
      instance.AddComponent<EditableObject>();
    }

    public void Update()
    {
      if (instance == null)
      {
        Destroy();
        return;
      }
      objectName = instance.name;
      position = instance.transform.position;
      rotation = instance.transform.rotation;
    }

    public void Destroy()
    {
      if (instance != null) GameObject.Destroy(instance);
      SceneManager.Instance.RemoveObjectFromScene(this);
    }
  }
}
