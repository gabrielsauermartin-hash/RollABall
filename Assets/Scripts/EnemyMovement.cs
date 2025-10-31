using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float visionRadius = 8f;
    public float visionAngle = 45f;
    public LayerMask obstacleMask;
    public Transform[] patrolPoints;
    private int currentPatrolIndex = 0;

    private NavMeshAgent agent;
    private bool playerInVision = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }

    void Update()
    {
        Vector3 dirToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < visionRadius)
        {
            float angle = Vector3.Angle(transform.forward, dirToPlayer);
            if (angle < visionAngle / 2f)
            {
                if (!Physics.Raycast(transform.position, dirToPlayer, distanceToPlayer, obstacleMask))
                {
                    playerInVision = true;
                    agent.SetDestination(player.position);
                }
                else
                {
                    LostPlayer();
                }
            }
            else
            {
                LostPlayer();
            }
        }
        else
        {
            LostPlayer();
        }
    }

    private void LostPlayer()
    {
        if (playerInVision)
        {
            playerInVision = false;
            if(patrolPoints.Length > 0)
                agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja el radio de visión
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);

        // Dibuja el ángulo de visión
        Vector3 leftBoundary = Quaternion.Euler(0, -visionAngle / 2f, 0) * transform.forward * visionRadius;
        Vector3 rightBoundary = Quaternion.Euler(0, visionAngle / 2f, 0) * transform.forward * visionRadius;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }

    
    /*
    public Transform player;
    private NavMeshAgent navMeshAgent; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }
    */
}
