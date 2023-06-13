using UnityEngine;

public class SceneOrientation : MonoBehaviour
{
    [SerializeField] private ScreenOrientation sceneOrientation;

    void Start()
    {
        switch(sceneOrientation)
        {
            case ScreenOrientation.Portrait:
                Screen.orientation = ScreenOrientation.Portrait;
                break;
            case ScreenOrientation.AutoRotation:
                Screen.orientation = ScreenOrientation.AutoRotation;
                break;
        }
    }  
}

