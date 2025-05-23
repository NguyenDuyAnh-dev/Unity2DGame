using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    public float health;
    public int scoreValue;
    private float minY;
    private Rigidbody2D myBody;

    [SerializeField]
    private GameObject explosionEffect; // Hiệu ứng nổ
    private AudioManager audioManager;
    private int isFollowingPlayer;

    [SerializeField]
    private Plane player;

    public AudioClip blowSound;
    private AudioSource audioSource;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        int currentLevel = GameManager.Instance.GetLevel();

        health = Random.Range(5, 10) + currentLevel * 2; // Máu random
        if (!player)
        {
            player = GameObject.FindAnyObjectByType<Plane>();
        }
        if (isFollowingPlayer == 0)
        {
            isFollowingPlayer = Random.Range(-3, 5);
        }

        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        minY = screenBounds.y;

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        int currentLevel = GameManager.Instance.GetLevel();
        enemySpeed += currentLevel * 0.7f; // Tăng tốc theo level
        myBody.velocity = new Vector2(0f, -enemySpeed);
    }

    void Update()
    {
        if (isFollowingPlayer > 0 && player != null)
        {
            FollowPlayer();
        }
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

    private void FollowPlayer()
    {
        Vector2 direction = player.transform.position - transform.position;
        Vector2 moveDirection = new Vector2(direction.x, -1).normalized;
        Vector2 targetPosition = (Vector2)transform.position + moveDirection * enemySpeed * Time.deltaTime;

        transform.position = targetPosition;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            audioManager.PlaySFX(audioManager.explosion);
            Die();
        }
    }

    void Die()
    {
        if (explosionEffect != null)
        {
            var explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
        }
        Destroy(gameObject);
        GameManager.Instance.AddScore(scoreValue);
    }

    // Bỏ hết các OnTriggerEnter2D hoặc OnTriggerStay2D liên quan đến laser gây sát thương nhé

    void OnGUI()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Label(new Rect(screenPosition.x, Screen.height - screenPosition.y, 50, 20), "HP: " + health.ToString("F1"));
    }
}
