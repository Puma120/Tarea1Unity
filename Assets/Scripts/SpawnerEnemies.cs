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
        InvokeRepeating("Spawn", starttime, spawnrate);
    }
    private void Spawn()
    {
        Instantiate(prefab,transform.position,transform.rotation);
        Invoke("CancelInvoke", endtime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
