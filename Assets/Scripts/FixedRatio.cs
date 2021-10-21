using UnityEngine;
public class FixedRatio : MonoBehaviour
{
    public SpriteRenderer targetSize;
    void Awake()
    {
        Application.targetFrameRate = 30;
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = targetSize.bounds.size.x / targetSize.bounds.size.y;
        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = targetSize.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = targetSize.bounds.size.y / 2 * differenceInSize;
        }
    }
}