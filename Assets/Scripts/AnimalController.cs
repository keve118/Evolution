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
    public float speedMin = 2f;
    public float speedMax = 10f;
    float randomSpeed;

    float currentTime = 0f;
    float startingTime = 5f;

    void Start()
    {
        player = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        randomSpeed = Random.Range(speedMin, speedMax);
        currentTime = startingTime;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= lookRadius && ResourceCutter.huntingToolEquiped) 
        {
            RunAway();
        }

        if (distance > runAwayRadius)
        {
            //currentTime -= 1 * Time.deltaTime;
            //if(currentTime <= 0f)
            //{
            //    WalkAround();
            //}
            //else
                StandStill();
        }

        Debug.Log(currentTime);

    }

    void RunAway()
    {
        agent.speed = randomSpeed;
        agent.SetDestination(-player.position);
        Animator an = agent.GetComponent<Animator>();
        an.SetBool("isRunning", true);
    }

    void StandStill()
    {
        agent.speed = 0;
        Animator an = agent.GetComponent<Animator>();
        an.SetBool("isRunning", false);
    }

    void WalkAround()
    {
        agent.speed = speedMin;
        agent.SetDestination(player.position);
        Animator an = agent.GetComponent<Animator>();
        an.SetBool("isWalking", true);
    }

}
