using UnityEngine;

public class PlaneBound : MonoBehaviour
{
    private float minX, maxX, minY, maxY;

    private void Awake()
    {
        // Get the screen bounds
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // +...f and -...f are used to prevent the plane from touching the edge of the screen
        minX = -screenBounds.x + 0.54f;
        maxX = screenBounds.x - 0.54f;
        minY = -screenBounds.y + 0.4f;
        maxY = screenBounds.y - 1;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the plane's position
        Vector3 viewPos = transform.position;   
        // Clamp the plane's position to the screen bounds to prevent it from going off-screen
        viewPos.x = Mathf.Clamp(viewPos.x, minX, maxX);
        viewPos.y = Mathf.Clamp(viewPos.y, minY, maxY);
        // Set the plane's position
        transform.position = viewPos;
    }
}
