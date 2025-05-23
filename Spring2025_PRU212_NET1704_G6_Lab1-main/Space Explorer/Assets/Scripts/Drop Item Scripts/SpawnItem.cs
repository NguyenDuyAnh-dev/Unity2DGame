using System.Collections;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public float delayTime;
    [SerializeField]
    private GameObject[] items;
    private float minX, maxX, maxY;

    private PlaneSwitcher planeSwitcher;

    private void Awake()
    {
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minX = -screenBounds.x + 0.54f;
        maxX = screenBounds.x - 0.54f;
        maxY = screenBounds.y + 1;

        planeSwitcher = FindAnyObjectByType<PlaneSwitcher>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DropItem());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DropItem()
    {
        yield return new WaitForSeconds(delayTime);
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), maxY, 0);

        // Pick a random enemy from the array
        GameObject itemBlue = items[0];
        GameObject itemRed = items[1];

        if (planeSwitcher)
        {
            if (planeSwitcher.GetCurrentShipTag().Equals("Ship1"))
            {
                Instantiate(itemRed, spawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(itemBlue, spawnPosition, Quaternion.identity);
            }
        }
        StartCoroutine(DropItem()); // Restart coroutine
    }
}
