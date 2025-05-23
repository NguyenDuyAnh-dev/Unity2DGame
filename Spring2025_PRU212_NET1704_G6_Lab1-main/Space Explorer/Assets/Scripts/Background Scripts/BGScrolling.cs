using UnityEngine;

public class BGScrolling : MonoBehaviour
{
    public float scrollSpeed;

    private Material material;

    private Vector3 offset = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = material.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        //offset.x += scrollSpeed * Time.deltaTime;
        offset.y += scrollSpeed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
}
