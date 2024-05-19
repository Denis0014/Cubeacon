using UnityEngine;

public class ImageScaler : MonoBehaviour
{

    void Start()
    {
        Scale();
    }

    public void Scale()
    {
        transform.localScale = new Vector3(Screen.width, Screen.height, 1);
    }
}

