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
    private Vector3 laserStart;
    private Vector3 laserEnd;

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
        if (Input.GetMouseButton(0))
        {
            isFiring = true;
            ShowLaser();

            if (Time.time >= nextFireTime)
            {
                nextFireTime = Time.time + fireRate;
                DamageEnemy();
            }

            laserLine.enabled = true;
        }
        else
        {
            isFiring = false;
            laserLine.enabled = false;
        }
    }

    private void ShowLaser()
    {
        laserStart = transform.position;
        Vector3 direction = -transform.up;

        RaycastHit2D hit = Physics2D.Raycast(laserStart, direction, laserLength, enemyLayer);

        if (hit.collider != null)
        {
            laserEnd = hit.point;
        }
        else
        {
            laserEnd = laserStart + direction * laserLength;
        }

        laserLine.SetPosition(0, laserStart);
        laserLine.SetPosition(1, laserEnd);
    }

    private void DamageEnemy()
    {
        Vector3 direction = (laserEnd - laserStart).normalized;
        float distance = Vector3.Distance(laserStart, laserEnd);

        RaycastHit2D hit = Physics2D.Raycast(laserStart, direction, distance, enemyLayer);

        if (hit.collider != null)
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(1f);
            }
        }
    }
}
