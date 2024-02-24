using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed; 

    void Start()
    {
        componentLinks();
        PickPatrolPoints();
    }


    private void componentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        if(!_isPlayerNoticed)
        {
            if(_navMeshAgent.remainingDistance == 0)
            {
                PickPatrolPoints();
            }
        }   
    }


    private void PickPatrolPoints()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }


    private void PatrolUpdate()
    {
        if(_navMeshAgent.remainingDistance == 0)
        {
            PickPatrolPoints();
        }
    }

    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        RaycastHit hit;
        if(Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            if(Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if(hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }
    private void ChaseUpdate()
    {
        if(_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
}
