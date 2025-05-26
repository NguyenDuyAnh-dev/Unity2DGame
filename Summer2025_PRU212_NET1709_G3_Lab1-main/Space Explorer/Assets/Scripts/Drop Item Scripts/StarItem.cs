using UnityEngine;

public class StarItem : MonoBehaviour
{
    public float itemSpeed;
    private Rigidbody2D myBody;
    private float minY;
    private AudioManager audioManager;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minY = -screenBounds.y - 1; // Pos item was destroyed
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        myBody.linearVelocity = new Vector2(0f, -itemSpeed);
        if (transform.position.y <= minY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ship1") || collision.CompareTag("Ship2"))
        {
            audioManager.PlaySFX(audioManager.boost);
            Debug.Log("Star collected");
            Destroy(gameObject);
            GameManager.Instance.AddScore(10);
        }
    }
}
