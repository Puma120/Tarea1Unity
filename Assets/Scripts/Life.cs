using UnityEngine;

public class Life : MonoBehaviour
{
    public float amount;
    private void Start()
    {
        if (amount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
