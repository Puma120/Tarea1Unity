using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int amount;
    void OnDestroy()
    {
        ScoreManager.instance.amount += amount;
    }


    
}
