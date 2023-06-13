using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class Gallery : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private GalleryImage prefab;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private float threshold=0.05f;
    [SerializeField] private int totalImageCount = 66;
    [SerializeField] private int countForDownload = 4;

    private string uri = "http://data.ikppbb.com/test-task-unity-data/pics/";
    private bool isLoading;
    private int currentImageCount;

    public event Action ImagePicked;

    private void Start()
    {
        var data = GalleryData.Instance.LoadedImages;

        if (data != null && data.Count>0)
        {
            currentImageCount = data.Count;
            foreach (var sprite in data)
            {
                CreateImage(sprite);
            }
        }
    }

    private void CreateImage(Sprite sprite)
    {
        GalleryImage image = Instantiate(prefab, content);
        image.SetSprite(sprite);
    }

    private IEnumerator LoadImages()
    {
        isLoading = true;

        for (int i = 0; i < countForDownload; i++)
        {
            if(currentImageCount == totalImageCount)
            {
                yield break;
            }
            string newUri = uri + $"{currentImageCount + 1}.jpg";
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(newUri))
            {
                yield return request.SendWebRequest();
                DownloadHandlerTexture downloadHandlerTexture = request.downloadHandler as DownloadHandlerTexture;
                var texture2D = downloadHandlerTexture.texture;
                Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 16f, 0, SpriteMeshType.FullRect);

                GalleryData.Instance.LoadedImages.Add(sprite);
                CreateImage(sprite);
                currentImageCount++;
            }
        }
        
        isLoading = false;
    }

    private void Update()
    {
        if (scrollRect.verticalNormalizedPosition <= threshold)
        {
            if (!isLoading)
            {
                StartCoroutine(LoadImages());
            }
        }
    }
}
