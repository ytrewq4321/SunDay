using UnityEngine;
using UnityEngine.UI;

public class FullOpenImage : MonoBehaviour
{
    [SerializeField] private Image image;

    private void Start()
    {
        image.sprite = GalleryData.instance.sprite;
    }
}
