using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

public class SpawnerEnemies : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public float starttime;
    public float endtime;
    public float spawnrate;
    void Start()
    {
        WavesManager.instance.waves.Add(this);
        InvokeRepeating("Spawn", starttime, spawnrate);
        Invoke("EndSpawner", endtime);
    }
    public void NextWave()
    {
        WavesManager.instance.waves.Add(this);
        InvokeRepeating("Spawn", starttime, spawnrate);
        Invoke("EndSpawner", endtime);
    }
    private void Spawn()
    {   int randomIndex = Random.Range(0, enemyPrefabs.Count+1);
        if (randomIndex>enemyPrefabs.Count-1){
            randomIndex = 0;
        }
        GameObject randomEnemy = enemyPrefabs[randomIndex];
        Debug.Log(randomIndex);

        Instantiate(randomEnemy,transform.position + new Vector3(-2,0,6),transform.rotation);
        
    }
    private void EndSpawner()
    {
        WavesManager.instance.waves.Remove(this);
        CancelInvoke();
    }
}


