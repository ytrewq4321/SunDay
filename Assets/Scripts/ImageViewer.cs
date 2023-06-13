using UnityEngine;
using UnityEngine.UI;

public class ImageViewer : MonoBehaviour
{
    [SerializeField] private Image image;

    private void Start()
    {
        image.sprite = GalleryData.Instance.sprite;
    }
}
