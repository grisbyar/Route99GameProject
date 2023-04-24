using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints;
    public float waypointReachedThreshold = 0.5f;
    public bool loop = true;
    public float detectionRange = 10f;
    public float shootingRange = 5f;
    public float updateFrequency = 0.5f;
    public float fireRate = 1f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public string playerTag = "Player";

    private NavMeshAgent navMeshAgent;
    private int currentWaypointIndex;
    private Transform player;
    private float nextUpdateTime;
    private float nextFireTime;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag(playerTag)?.transform;
        nextUpdateTime = Time.time;

        if (waypoints.Length > 0)
        {
            SetNextWaypoint();
        }
        else
        {
            Debug.LogError("No waypoints assigned. Please assign waypoints for the enemy to patrol.");
        }
    }

    private void Update()
    {
        if (player == null || waypoints.Length == 0) return;

        if (Time.time >= nextUpdateTime)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRange)
            {
                navMeshAgent.SetDestination(player.position);

                if (distanceToPlayer <= shootingRange)
                {
                    FireAtPlayer();
                }
            }
            else
            {
                Patrol();
            }

            nextUpdateTime = Time.time + updateFrequency;
        }
    }

    private void Patrol()
    {
        if (navMeshAgent.remainingDistance < waypointReachedThreshold)
        {
            SetNextWaypoint();
        }
    }

    private void SetNextWaypoint()
    {
        navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        currentWaypointIndex = (currentWaypointIndex + 1) % (loop ? waypoints.Length : Mathf.Min(currentWaypointIndex + 1, waypoints.Length));
    }

    private void FireAtPlayer()
    {
        if (Time.time >= nextFireTime)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
}
