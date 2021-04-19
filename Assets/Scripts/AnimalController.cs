using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float runAwayRadius = 20f;
    Transform player;
    NavMeshAgent agent;
    public float speed = 2f;

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
            agent.speed = speed;
            agent.SetDestination(-player.position); //.normalized
            Animator an = agent.GetComponent<Animator>();
            an.SetBool("isRunning", true);

        }

        if (distance > runAwayRadius)
        {
            agent.speed = 0;
            Animator an = agent.GetComponent<Animator>();
            an.SetBool("isRunning", false);
        }

    }
}
