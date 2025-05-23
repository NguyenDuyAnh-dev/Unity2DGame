using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fireballSpeed;

    private Rigidbody2D myBody;

    private float maxY;
    public float damage;

    // Thêm biến âm thanh
    public AudioClip fireSound;  // Lưu trữ tệp âm thanh khi bắn
    public AudioClip hitSound; //sound khi trung enemy
  
    private AudioSource audioSource; // Component phát âm thanh

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxY = screenBounds.y;

        // Tạo AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // Không phát ngay khi game bắt đầu
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Phát âm thanh khi viên đạn được tạo
        if (fireSound != null)
        {
            audioSource.PlayOneShot(fireSound);
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Move the fireball
        myBody.linearVelocity = new Vector2(0, fireballSpeed);
        OnBecameInvisible();
    }

    private void OnBecameInvisible()
    {
        if (transform.position.y > maxY)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hitSound != null)
        {
            //AudioSource.PlayClipAtPoint(hitSound, transform.position, 20.0f); // Phát âm thanh va chạm
            GameObject tempAudioSource = new GameObject("TempAudio");
            AudioSource audioSource = tempAudioSource.AddComponent<AudioSource>();

            // Thiết lập âm thanh và âm lượng
            audioSource.clip = hitSound;
            audioSource.volume = 2.0f; // Tăng âm lượng gấp 2 lần
            audioSource.Play();
        }

        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
