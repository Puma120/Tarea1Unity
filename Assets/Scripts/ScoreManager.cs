using UnityEngine;

public class ScoreManager : MonoBehaviour
{   public static ScoreManager instance;
    public int amount;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("ya existe el objeto score manager",gameObject);
        }
    }

}

