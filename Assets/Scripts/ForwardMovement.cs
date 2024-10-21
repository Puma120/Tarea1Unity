using UnityEngine;

public class ForwarMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddRelativeForce(0, 0, speed * Time.deltaTime);
    }
}
