using UnityEngine;
public class ChangeSceneButton : MonoBehaviour
{
    public void ChangeScene(int scene)
    {
        SceneLoader.Instance.LoadScene(scene);
    }
}
