using System;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float planeSpeed;

    private Rigidbody2D myBody;

    private int bulletLevel = 1;

    private GameObject flame;
    private LaserShooter laserShooter;

    private void Awake()
    {
        laserShooter = GetComponent<LaserShooter>();  // Tham chiếu script laser (nếu cần gọi hàm)
        myBody = GetComponent<Rigidbody2D>();

        flame = transform.GetChild(0).gameObject;
        flame.SetActive(false);
    }

    void Update()
    {
        PlaneMovement();
        // Không gọi Shoot() ở đây nữa, để LaserShooter tự xử lý
        laserShooter.Shoot();
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

        myBody.velocity = movement * planeSpeed;
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