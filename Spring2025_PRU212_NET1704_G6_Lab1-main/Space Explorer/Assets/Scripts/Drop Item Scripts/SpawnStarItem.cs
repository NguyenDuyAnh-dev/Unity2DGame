using System.Collections;
using UnityEngine;

public class SpawnStarItem : MonoBehaviour
{
    public float delayTime;
    [SerializeField]
    private GameObject[] items;
    private float minX, maxX, maxY;

    private void Awake()
    {
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minX = -screenBounds.x + 0.54f;
        maxX = screenBounds.x - 0.54f;
        maxY = screenBounds.y + 1;
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
        GameObject item = items[Random.Range(0, items.Length)];
        Instantiate(item, spawnPosition, Quaternion.identity);
        StartCoroutine(DropItem()); // Restart coroutine
    }
}
