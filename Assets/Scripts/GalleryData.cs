using System.Collections.Generic;
using UnityEngine;

public class GalleryData : MonoBehaviour
{
    public static GalleryData Instance;

    public List<Sprite> LoadedImages = new List<Sprite>();
    public Sprite sprite;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OpenImage(Sprite sprite)
    {
        this.sprite = sprite;
    }
}
