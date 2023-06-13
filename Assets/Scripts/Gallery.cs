using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Gallery : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private Image prefab;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private float threshold=0.05f;
    [SerializeField] private int totalImageCount = 66;
    [SerializeField] private int imageDownloadCount = 4;

    private string uri = "http://data.ikppbb.com/test-task-unity-data/pics/";
    private bool isLoading;
    private int currentImageCount;

    private void Start()
    {
        var data = GalleryData.instance.loadedImages;

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
        Image image = Instantiate(prefab, content);
        image.sprite = sprite;
        image.GetComponent<Button>().onClick.AddListener(() => GalleryData.instance.sprite = sprite);
    }

    private IEnumerator LoadImages()
    {
        isLoading = true;

        for (int i = 0; i < imageDownloadCount; i++)
        {
            string newUri = uri + $"{currentImageCount + 1}.jpg";
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(newUri))
            {
                Debug.Log(newUri);
                yield return request.SendWebRequest();
                DownloadHandlerTexture downloadHandlerTexture = request.downloadHandler as DownloadHandlerTexture;
                var texture2D = downloadHandlerTexture.texture;
                Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 16f, 0, SpriteMeshType.FullRect);

                GalleryData.instance.loadedImages.Add(sprite);
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
            if (!isLoading && currentImageCount < totalImageCount)
            {
                StartCoroutine(LoadImages());
            }
        }
    }
}
