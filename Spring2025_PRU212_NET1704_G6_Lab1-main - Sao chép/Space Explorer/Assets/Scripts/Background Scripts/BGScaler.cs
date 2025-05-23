using UnityEngine;

public class BGScaler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var height = Camera.main.orthographicSize * 2f;
        //Debug.Log(height);
        var width = height * Screen.width / Screen.height;
        transform.localScale = new Vector3(width, height, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
