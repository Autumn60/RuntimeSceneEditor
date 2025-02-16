using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using RuntimeTransformHandle;
using RuntimeSceneEditor.Utils;

namespace RuntimeSceneEditor
{
  using Object = UnityEngine.Object;

  public class SceneEditor : SingletonMonoBehaviour<SceneEditor>
  {
    [SerializeField]
    private TransformHandle handle;

    public float translationSensitivity = 0.2f;
    public float zoomSensitiviy = 10;

    public float rotationSensitiviry = 2;
    new Camera camera;
    Transform cameraTransform;

    private void Start()
    {
      camera = Camera.main;
      cameraTransform = camera.transform;
    }

    private void OnDisable()
    {
      handle.Target = null;
    }

    private void Update()
    {
      UpdateCamera();

      if (MouseInput.GetMouseLeftClick())
      {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
          EditableObject[] objects = hit.transform.gameObject.GetComponentsInParent<EditableObject>();
          if (objects.Length > 0)
          {
            if (handle.Target == objects[0].transform)
            {
              handle.HandleType = handle.HandleType == HandleType.Position ? HandleType.Rotation : HandleType.Position;
            }
            else
            {
              handle.Target = objects[0].transform;
              handle.HandleType = HandleType.Position;
            }
          }
        }
      }

      if (Input.GetKeyDown(KeyCode.Delete))
      {
        if (handle.Target)
        {
          Destroy(handle.Target.gameObject);
        }
      }
    }

    private void UpdateCamera()
    {
      float translateX = 0;
      float translateY = 0;

      if (MouseInput.GetMouseMiddleHold())
      {
        translateY = MouseInput.GetMouseY() * translationSensitivity;
        translateX = MouseInput.GetMouseX() * translationSensitivity;
      }


      float zoom = MouseInput.GetMouseScroll() * zoomSensitiviy;

      cameraTransform.Translate(-translateX, -translateY, zoom);

      float rotationX = 0;
      float rotationY = 0;

      if (MouseInput.GetMouseRightHold())
      {
        rotationX = MouseInput.GetMouseY() * rotationSensitiviry;
        rotationY = MouseInput.GetMouseX() * rotationSensitiviry;
      }

      cameraTransform.Rotate(0, rotationY, 0, Space.World);
      cameraTransform.Rotate(-rotationX, 0, 0);
    }

    public void InstantiatePrefab(string prefabId)
    {
      Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
      if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
      {
        SceneObject obj = SceneObject.Instantiate(prefabId, prefabId, hit.point, Quaternion.identity);
        handle.Target = obj.Instance.transform;
        handle.HandleType = HandleType.Position;
      }
    }
  }
}