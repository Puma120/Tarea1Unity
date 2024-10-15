using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    public GameObject prefab;
    public float starttime;
    public float endtime;
    public float spawnrate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WavesManager.instance.waves.Add(this);
        InvokeRepeating("Spawn", starttime, spawnrate);
        Invoke("EndSpawner", endtime);
    }
    private void Spawn()
    {
        Instantiate(prefab,transform.position + new Vector3(-2,0,6),transform.rotation);
        
    }
    private void EndSpawner()
    {
        WavesManager.instance.waves.Remove(this);
        CancelInvoke();
    }
}
