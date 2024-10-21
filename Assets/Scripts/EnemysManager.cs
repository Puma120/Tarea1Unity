using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class EnemysManager : MonoBehaviour
{
    public static EnemysManager instance;
    public List<Enemy> enemys;
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

