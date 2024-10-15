using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemysManager.instance.enemys.Add(this);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        EnemysManager.instance.enemys.Remove(this);
    }
}
