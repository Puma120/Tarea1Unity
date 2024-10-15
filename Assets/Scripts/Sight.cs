using UnityEngine;

public class Sight : MonoBehaviour
{
    public float distance;
    public float angle;
    public LayerMask objectsLayers;
    public LayerMask obstaclesLayers;
    public Collider detectedObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,distance,objectsLayers);
        detectedObject = null;
        for (int i = 0; i< colliders.Length; i++)
        {
            Collider collider = colliders[i];
            Vector3 directiontoCollider = Vector3.Normalize(collider.bounds.center - transform.position);
            float angletoCollier = Vector3.Angle(transform.position, directiontoCollider);
            if (angletoCollier < angle)
            {
                if (!Physics.Linecast(transform.position,collider.bounds.center,out RaycastHit hit, obstaclesLayers))
                {
                    Debug.DrawLine(transform.position, collider.bounds.center,Color.green);
                    detectedObject= collider;
                    break;
                }
                else
                {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color= Color.white;
        Vector3 rightDirection = Quaternion.Euler(0,angle,0) * transform.forward;
        Gizmos.DrawRay(transform.position,rightDirection*distance);
        Gizmos.color = Color.white;
        Vector3 leftDirection = Quaternion.Euler(0,-angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, leftDirection * distance);
    }
}
