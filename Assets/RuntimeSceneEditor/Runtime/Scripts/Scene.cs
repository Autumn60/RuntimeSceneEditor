using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace RuntimeSceneEditor
{
  [Serializable]
  public class Scene
  {
    [SerializeField]
    private List<SceneObject> Objects;

    public void AddObject(SceneObject obj)
    {
      Objects.Add(obj);
    }

    public void RemoveObject(SceneObject obj)
    {
      if (!Objects.Contains(obj)) return;
      Objects.Remove(obj);
    }

    public void Instantiate()
    {
      SceneObject[] objects = Objects.ToArray();
      foreach (var obj in objects)
      {
        obj.Instantiate();
      }
    }

    public void Update()
    {
      SceneObject[] objects = Objects.ToArray();
      foreach (var obj in objects)
      {
        obj.Update();
      }
    }

    public void Destroy()
    {
      SceneObject[] objects = Objects.ToArray();
      foreach (var obj in objects)
      {
        obj.Destroy();
      }
    }
  }
}
