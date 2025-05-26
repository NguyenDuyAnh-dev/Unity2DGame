using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Item : MonoBehaviour
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
        myBody.linearVelocity = new Vector2(0f, -itemSpeed);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
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
            Destroy(gameObject);
        }
    }
}
