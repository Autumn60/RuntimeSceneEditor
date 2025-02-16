using UnityEngine;

#if ENABLE_LEGACY_INPUT_MANAGER
#else
using UnityEngine.InputSystem;
#endif

namespace RuntimeSceneEditor.Utils
{
  public static class MouseInput
  {
    public static bool GetMouseLeftClick()
    {
#if ENABLE_LEGACY_INPUT_MANAGER
      return Input.GetMouseButtonDown(0);
#else
      return Mouse.current.leftButton.wasPressedThisFrame;
#endif
    }

    public static bool GetMouseRightHold()
    {
#if ENABLE_LEGACY_INPUT_MANAGER
      return Input.GetMouseButton(1);
#else
      return Mouse.current.rightButton.isPressed;
#endif
    }

    public static bool GetMouseMiddleHold()
    {
#if ENABLE_LEGACY_INPUT_MANAGER
      return Input.GetMouseButton(2);
#else
      return Mouse.current.middleButton.isPressed;
#endif
    }

    public static float GetMouseScroll()
    {
#if ENABLE_LEGACY_INPUT_MANAGER
      return Input.mouseScrollDelta.y;
#else
      return Mouse.current.scroll.ReadValue().y;
#endif
    }

    public static float GetMouseX()
    {
#if ENABLE_LEGACY_INPUT_MANAGER
      return Input.GetAxis("Mouse X");
#else
      return Mouse.current.delta.x.ReadValue();
#endif
    }

    public static float GetMouseY()
    {
#if ENABLE_LEGACY_INPUT_MANAGER
      return Input.GetAxis("Mouse Y");
#else
      return Mouse.current.delta.y.ReadValue();
#endif
    }
  }
}