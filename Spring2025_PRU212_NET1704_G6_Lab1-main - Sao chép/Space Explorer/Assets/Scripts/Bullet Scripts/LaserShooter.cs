using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserShooter : MonoBehaviour
{
    public float laserLength = 10f;
    public LayerMask enemyLayer;
    public float fireRate = 0.2f;
    public Material laserMaterial;

    private float nextFireTime = 0f;
    private LineRenderer laserLine;

    public bool isFiring { get; private set; } = false;

    private void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.material = laserMaterial;
        laserLine.positionCount = 2;
        laserLine.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            isFiring = true;
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
        else if (!Input.GetMouseButton(0))
        {
            isFiring = false;
            laserLine.enabled = false;
        }
    }

    public void Shoot()
    {
        laserLine.enabled = true;

        Vector3 start = transform.position;
        Vector3 direction = -transform.up; // Hý?ng laser (có th? ch?nh theo object)

        RaycastHit2D hit = Physics2D.Raycast(start, direction, laserLength, enemyLayer);

        if (hit.collider != null)
        {
            Vector3 hitPoint = hit.point;
            laserLine.SetPosition(0, start);
            laserLine.SetPosition(1, hitPoint);

            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(1f);  // Gây damage ngay lúc trúng
            }
        }
        else
        {
            // N?u không trúng g? th? v? laser dài max
            laserLine.SetPosition(0, start);
            laserLine.SetPosition(1, start + direction * laserLength);
        }
    }
}
