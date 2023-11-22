using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Waveconfig", fileName="New WaveConfig")] 
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform pathPrefab;
    [SerializeField] List<GameObject> enemyPrefabs;

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }
    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
    public float GetmoveSpeed()
    {
        return moveSpeed;
    }
    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }
    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();  
        foreach(Transform child in pathPrefab)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }
}
