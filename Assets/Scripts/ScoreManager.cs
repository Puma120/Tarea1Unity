using UnityEngine;

public class ScoreManager : MonoBehaviour
{   public static ScoreManager instance;
    public int amount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    // Update is called once per frame
}
