using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovingObject : MonoBehaviour
{
    private NavMeshAgent agent;
    private float timer;
    [SerializeField] private float moveTimer;
    [SerializeField] private float moveRadius;


    void OnEnable(){
        agent = GetComponent<NavMeshAgent> ();
        timer = moveTimer;
    }

    void Update(){
        timer += Time.deltaTime;

        if(timer >= moveTimer) {
            Vector3 newPos = RandomMovement(transform.position, moveRadius);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public Vector3 RandomMovement(Vector3 origin, float distance) {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;

        UnityEngine.AI.NavMeshHit navHit;
        UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out navHit, distance, -1);

        return navHit.position;
    }
}
