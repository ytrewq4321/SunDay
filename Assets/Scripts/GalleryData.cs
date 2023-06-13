using System.Collections.Generic;
using UnityEngine;

public class GalleryData : MonoBehaviour
{
    public static GalleryData instance;

    public List<Sprite> loadedImages = new List<Sprite>();
    public int ImageIndex;
    public Sprite sprite;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
