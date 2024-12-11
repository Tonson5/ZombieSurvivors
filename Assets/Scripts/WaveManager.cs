using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject zombie;
    public int wave;
    public GameObject[] spawnPoints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SpawnZombies();
        }
    }
    public void SpawnZombies()
    {
        Instantiate(zombie, transform.position, transform.rotation);
        for (int i = 0; i < wave/2; i++)
        {
            transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            Instantiate(zombie, transform.position, transform.rotation);
        }
        wave += 1;
        if (wave > 25)
        {
            wave = 25;
        }
        
    }
}
