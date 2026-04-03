using UnityEngine;
using System.Collections.Generic;

public class RepairSpawner : MonoBehaviour
{
    [Header("Factory Settings")]
    public GameObject itemPrefab;

    public List<ItemDataObject> possibleItems;

    [Header("Spawn Settings")]
    public int totalItemsToSpawn = 10;

    public Vector2 spawnAreaSize = new Vector2(10, 5);

    void Start()
    {
        SpawnAllItems();
    }

    void SpawnAllItems()
    {
        if (itemPrefab == null)
        {
            Debug.LogError("Item Prefab belum diassign!");
            return;
        }

        if (possibleItems == null || possibleItems.Count == 0)
        {
            Debug.LogError("Possible items kosong!");
            return;
        }

        for (int i = 0; i < totalItemsToSpawn; i++)
        {
            SpawnSingleItem();
        }
    }

    void SpawnSingleItem()
    {
        Vector2 randomPos = new Vector2(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
        );

        Vector2 finalPos = (Vector2)transform.position + randomPos;

        GameObject newItem = Instantiate(itemPrefab, finalPos, Quaternion.identity, transform);

        InteractiveItem script = newItem.GetComponent<InteractiveItem>();

        if (script == null)
        {
            Debug.LogError("Prefab tidak memiliki InteractiveItem!");
            return;
        }

        int randomIndex = Random.Range(0, possibleItems.Count);

        ItemDataObject randomData = possibleItems[randomIndex];

        script.Configure(randomData);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireCube(
            transform.position,
            new Vector3(spawnAreaSize.x, spawnAreaSize.y, 0)
        );
    }
}