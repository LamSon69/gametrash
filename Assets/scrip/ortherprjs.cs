using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrtherPrjs : MonoBehaviour
{
    public GameObject[] objectPrefabs; // Danh sách object spawn
    public Transform spawnPoint;       // Điểm spawn (gán từ Inspector)
    public float minDelay = 2f, maxDelay = 4f; // Thời gian spawn ngẫu nhiên
    public float moveSpeed = 3f;       // Tốc độ di chuyển

    private List<GameObject> spawnedObjects = new List<GameObject>();

    void Start()
    {
        if (spawnPoint == null)
        {
            Debug.LogError("❌ Chưa gán SpawnPoint vào script!");
            return;
        }

        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            SpawnRandomObject();
        }
    }

    void SpawnRandomObject()
    {
        if (objectPrefabs.Length == 0) return;

        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject prefab = objectPrefabs[randomIndex];

        // Spawn theo vị trí của SpawnPoint
        Vector3 spawnPosition = spawnPoint.position;

        GameObject obj = GetOrCreateObject(randomIndex, spawnPosition);
        obj.SetActive(true);
    }

    GameObject GetOrCreateObject(int index, Vector3 position)
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (!obj.activeInHierarchy) // Tái sử dụng object ẩn
            {
                obj.transform.position = position;
                return obj;
            }
        }

        GameObject newObj = Instantiate(objectPrefabs[index], position, Quaternion.identity);
        spawnedObjects.Add(newObj);
        return newObj;
    }

    void Update()
    {
        MoveObjects();
    }

    void MoveObjects()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj.activeInHierarchy)
            {
                obj.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                
                if (obj.transform.position.x < Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, 0, 0)).x) // Khi ra khỏi màn hình
                {
                    obj.SetActive(false);
                }
            }
        }
    }
}
