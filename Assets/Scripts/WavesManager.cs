using System.Collections.Generic;
using UnityEngine;
public class WavesManager : MonoBehaviour
{
    public static WavesManager instance;
    public List<SpawnerEnemies> waves;
    public int wavesRemaining = 0;
    public SpawnerEnemies spawn1;

    private void Update()
    {
        if (waves.Count == 0 && wavesRemaining > 0)
        {
            spawn1.NextWave();
            wavesRemaining--;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("ya existe el objeto score manager", gameObject);
        }
    }
}

