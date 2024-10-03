using UnityEngine;

public class ContactDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
   
}
