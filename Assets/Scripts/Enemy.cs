using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        EnemysManager.instance.enemys.Add(this);
    }

    void OnDestroy()
    {
        EnemysManager.instance.enemys.Remove(this);
    }
}

