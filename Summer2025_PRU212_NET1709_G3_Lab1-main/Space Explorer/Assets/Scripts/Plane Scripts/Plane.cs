using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plane : MonoBehaviour
{
    public float planeSpeed;

    private Rigidbody2D myBody;
    private int bulletLevel = 1;

    private GameObject flame;
    private LaserShooter laserShooter;

    private void Awake()
    {
        laserShooter = GetComponent<LaserShooter>();
        myBody = GetComponent<Rigidbody2D>();

        flame = transform.GetChild(0).gameObject;
        flame.SetActive(false);
    }

    void Update()
    {
        PlaneMovement();
        // Không gọi Shoot(), LaserShooter tự xử lý
    }

    private void PlaneMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (moveVertical > 0)
        {
            ToggleFlame(true);
        }
        else
        {
            ToggleFlame(false);
        }

        if (moveHorizontal != 0)
        {
            ToggleFlame(true);
            transform.rotation = Quaternion.Euler(0, 0, 180 + -moveHorizontal * 30);
        }

        myBody.linearVelocity = movement * planeSpeed;
    }

    private void ToggleFlame(bool isActive)
    {
        if (flame.activeSelf != isActive)
        {
            flame.SetActive(isActive);
        }
    }

    private void UpgradeBullet()
    {
        bulletLevel++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Upgrade Bullet Item"))
        {
            UpgradeBullet();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void Die()
    {
        // Reload scene khi máy bay chết
        Debug.Log("Plane died!");
        int currentScore = GameManager.Instance.GetScore();

        // Ghi điểm mới (kể cả là 0)
        PlayerPrefs.SetInt("PlayerScore", currentScore);
        PlayerPrefs.Save(); // BẮT BUỘC để đảm bảo điểm được ghi vào ổ cứng
        SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
    }

    public int GetBulletLevel()
    {
        return bulletLevel;
    }

    public void SetBulletLevel(int level)
    {
        bulletLevel = level;
    }
}
