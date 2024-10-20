using UnityEngine;
using System.Collections.Generic;

public class NewSpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public float starttime;
    public float endtime;
    public float spawnrate;

    // Método que inicia el spawner, antes en Start
    public void StartSpawner()
    {
        WavesManager.instance.waves2.Add(this);
        InvokeRepeating("Spawn", starttime, spawnrate);
        Invoke("EndSpawner", endtime);
    }

    private void Spawn()
    {
        int randomIndex = UnityEngine.Random.Range(0, enemyPrefabs.Count + 1);
        if (randomIndex > enemyPrefabs.Count - 1)
        {
            randomIndex = 0;
        }
        GameObject randomEnemy = enemyPrefabs[randomIndex];
        Debug.Log(randomIndex);

        Instantiate(randomEnemy, transform.position + new Vector3(-2, 0, 6), transform.rotation);
    }

    // Método que finaliza el spawner
    public void EndSpawner()
    {
        WavesManager.instance.waves2.Remove(this);
        CancelInvoke();
    }
}
