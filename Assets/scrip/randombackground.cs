using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBackground : MonoBehaviour
{
    public GameObject[] backgroundPrefabs; 
    public Transform spawnPoint; 
    void Start()
    {
        SpawnRandomBackground();
    }

    void SpawnRandomBackground()
    {
        
        int randomIndex = Random.Range(0, backgroundPrefabs.Length);
        GameObject randomBackground = backgroundPrefabs[randomIndex];

        Instantiate(randomBackground, spawnPoint.position, spawnPoint.rotation);
    }
}
