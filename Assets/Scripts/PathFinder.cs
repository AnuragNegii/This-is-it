using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawnner enemySpawnner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;

    int waypointsIndex = 0;

    void Awake() {
        enemySpawnner = FindObjectOfType<EnemySpawnner>();
    }

    void Start()
    {
        waveConfig = enemySpawnner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointsIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath(){
        if(waypointsIndex< waypoints.Count){
            Vector3 targetPosition = waypoints[waypointsIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition){
                waypointsIndex++;
            }
        }else{
            Destroy(gameObject);
        }
    }
}
