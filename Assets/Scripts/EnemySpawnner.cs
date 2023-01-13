using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{

    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweeenWaves = 0f;
    [SerializeField] bool isLooping;

    WaveConfigSO currentWave;

    public WaveConfigSO GetCurrentWave(){
        return currentWave;
    }
    void Start()
    {
       StartCoroutine (SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {   
       do{ 
        foreach(WaveConfigSO waves in waveConfigs){
            currentWave = waves;
            for(int i = 0; i < currentWave.GetEnemyCount(); i++){
                Instantiate(currentWave.GetEnemyPrefab(0), 
                            currentWave.GetStartingWAypoint().position,
                            Quaternion.Euler(0,0,180),
                            transform);
            yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
        } yield return new WaitForSeconds(timeBetweeenWaves);
        }    
       }while(isLooping);
    }
    
}
