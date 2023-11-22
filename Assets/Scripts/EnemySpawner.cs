using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;
    void Start()
    {
        SpawnEnemies();
    }
    void SpawnEnemies()
    {
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWayPoint().position,
                Quaternion.identity, transform);
        }
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
