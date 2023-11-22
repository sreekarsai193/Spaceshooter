using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfigSO;
    [SerializeField] int currentWayPointIndex=0;
    List<Transform> wayPoints = new List<Transform>();
    float moveSpeed;

    private void Awake()
    {
       enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
        waveConfigSO = enemySpawner.GetCurrentWave();
        wayPoints=waveConfigSO.GetWayPoints();
        moveSpeed=waveConfigSO.GetmoveSpeed();
        transform.position = wayPoints[currentWayPointIndex].position;
        
    }


    void Update()
    {
        FollowPath();
    }
    void FollowPath()
    {
       
        if(currentWayPointIndex<wayPoints.Count)
        {
            
            float delta=moveSpeed*Time.deltaTime;
            Vector3 targetPosition = wayPoints[currentWayPointIndex].position;
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,
                delta);
            if(transform.position==targetPosition)
            {
                
                currentWayPointIndex++;
            }

        }
        else
        {
            
            Destroy(gameObject);
        }
    }
}
