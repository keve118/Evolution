using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float runAwayRadius = 10f;
    Transform player;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= lookRadius) //while will crash
        {
            agent.SetDestination(player.position * -1);

        }
        //else
        //    agent.speed = 0;
        //if (distance >= runAwayRadius)
        //{
        //    agent.speed = 0;
        //}
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, runAwayRadius);
    }
}
