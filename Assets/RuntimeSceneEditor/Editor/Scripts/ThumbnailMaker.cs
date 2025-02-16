using UnityEngine;
using UnityEditor;
using System.IO;

namespace RuntimeSceneEditor
{
  public class ThumbnailMaker : EditorWindow
  {
    [MenuItem("Assets/Create/ThumbnailFromObject")]
    public static void CreateThumbnail()
    {
      GameObject obj = Selection.activeGameObject;
      if (obj == null)
      {
        Debug.LogError("No object selected");
        return;
      }

      Texture2D thumbnail = AssetPreview.GetAssetPreview(obj);
      Texture2D tex = new Texture2D(thumbnail.width, thumbnail.height, thumbnail.format, false);
      Graphics.CopyTexture(thumbnail, tex);
      string path = Path.GetDirectoryName(AssetDatabase.GetAssetPath(obj)) + "/" + obj.name + "_thumbnail.png";
      File.WriteAllBytes(path, tex.EncodeToPNG());
      AssetDatabase.ImportAsset(path);
    }
  }
}
