using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using UnityEngine.UIElements;
using UnityEngine.AI;
using TMPro;
using UnityEngine.Animations;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState {GoToBase, AttackBase, ChasePlayer, AttackPlayer}
    public EnemyState currentState;
    public Transform baseTransform;
    public Sight sightSensor;
    public float baseAttackDistance;
    public float playerAttackDistance;
    NavMeshAgent agent;
    public GameObject prefab;
    public GameObject shootPoint;
    public float fireRate;
    float lastShootTime = 0;

    private void Awake()
    {
        baseTransform = GameObject.Find("Base").transform;
        agent= GetComponentInParent<NavMeshAgent>();
    }
    void Update()
    {
        if (currentState == EnemyState.GoToBase)
        {
            GoToBase();
        }
        else if (currentState == EnemyState.AttackBase)
        {
            AttackBase();
        }
        
        else if (currentState == EnemyState.ChasePlayer)
        {
            ChasePlayer();
        }
        else if (currentState == EnemyState.AttackPlayer)
        {
            AttackPlayer();
        }
    }

    private void ChasePlayer()
    {
        agent.isStopped = false;
        if (sightSensor.detectedObject == null)
        {
            currentState= EnemyState.GoToBase;
            return;
        }
        agent.SetDestination(sightSensor.detectedObject.transform.position);
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToPlayer <= playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
            return;
        }
    }

    private void AttackPlayer()
    {
        agent.isStopped = true;
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        LookTo(sightSensor.detectedObject.transform.position);
        shoot();
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToPlayer > playerAttackDistance*1.1)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }

    private void LookTo(Vector3 position)
    {
        Vector3 directionToPosition= Vector3.Normalize(position - transform.position) ;
        directionToPosition.y = 0f;
        //transform.parent.position = directionToPosition;
        Quaternion targetRotation = Quaternion.LookRotation(directionToPosition);
        transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, targetRotation, Time.deltaTime * 5f);
    }

    private void AttackBase()
    {
        agent.isStopped = true;
        shoot();
    }

    private void GoToBase()
    {
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);
        if(sightSensor.detectedObject != null) 
        {
            currentState = EnemyState.ChasePlayer;
        }
        float distanceToBase = Vector3.Distance(transform.position,baseTransform.position);
        if (distanceToBase <= baseAttackDistance) 
        {
            currentState = EnemyState.AttackBase;        
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);
    }
    private void shoot()
    {
        float timeSinceLastShoot = Time.time-lastShootTime;
        if (timeSinceLastShoot < fireRate)
        {
            return;
        }
        lastShootTime= Time.time;
        GameObject clone = Instantiate(prefab);
        clone.transform.position= shootPoint.transform.position;
        clone.transform.rotation= shootPoint.transform.rotation;
    }
}
