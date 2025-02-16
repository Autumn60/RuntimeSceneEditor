using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RuntimeSceneEditor
{
  public class PrefabUI : MonoBehaviour
  {
    [SerializeField]
    private RawImage thumbnailImage;
    [SerializeField]
    private TextMeshProUGUI prefabIdText;

    private string prefabId;

    public void Initialize(ScenePrefabData data)
    {
      thumbnailImage.texture = data.Thumbnail;
      prefabIdText.text = data.Id;
      prefabId = data.Id;
    }

    public void OnClick()
    {
      SceneEditor.Instance.InstantiatePrefab(prefabId);
    }
  }
}
