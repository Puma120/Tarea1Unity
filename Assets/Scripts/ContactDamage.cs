using UnityEngine;

public class ContactDamage : MonoBehaviour
{ public float damage;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Life life = other.GetComponent<Life>();
        if (life != null)
        {
            life.amount -= damage;
        }
    }
}

