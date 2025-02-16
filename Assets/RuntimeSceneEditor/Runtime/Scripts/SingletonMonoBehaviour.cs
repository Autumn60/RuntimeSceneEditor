using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace RuntimeSceneEditor
{
  public abstract class SingletonMonoBehaviour<TType> : MonoBehaviour, IDisposable where TType : MonoBehaviour
  {
    private static TType instance;

    public static TType Instance
    {
      get
      {
        Assert.IsNotNull(instance, "There is no object attached " + typeof(TType).Name);
        return instance;
      }
    }

    public static bool IsExist() { return instance != null; }

    private void Awake()
    {
      if (instance != null && instance.gameObject != null)
      {
        Destroy(this.gameObject);
        return;
      }

      instance = this as TType;
      OnAwaking();
    }

    protected virtual void OnAwaking() { }

    private void OnDestroy()
    {
      if (instance != (this as TType)) return;
      OnDestroying();
      Dispose();
    }

    protected virtual void OnDestroying()
    {
    }

    public virtual void Dispose()
    {
      if (IsExist()) instance = null;
    }
  }
}
