using UnityEngine;
using UnityEngine.UI;

public class GalleryImage : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    [SerializeField] private ChangeSceneButton changeScene;

    private void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        GalleryData.Instance.OpenImage(image.sprite);
        changeScene.ChangeScene(2);
    }

    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }    
}
