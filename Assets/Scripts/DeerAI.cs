using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace UnityStandardAssets.Characters.ThirdPerson 
{

}
public class DeerAI : MonoBehaviour
{
    public float lookRadius = 10f;
    public float runAwayRadius = 40f;
    Transform player;
    NavMeshAgent agent;
    public float speedMin = 4f;
    public float speedMax = 10f;
    public float randomSpeed;
    float distance;

    //Waypoint variables
    private Transform waypointTarget;
    private int waypointIndex = 0;
    int randomWaypoint;

    public enum DeerState
    {
        Eating,
        Running
    }
    public DeerState currentState;

    void Start()
    {
        player = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        randomWaypoint = Random.Range(0, Waypoint.waypoints.Length);
        waypointTarget = Waypoint.waypoints[randomWaypoint];
    }

    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position); //distance to player from agent (deer)
        switch (currentState)
        {
            case DeerState.Eating:
                {
                    StandStill();

                    if (distance <= lookRadius && ResourceCutter.huntingToolEquiped)
                        currentState = DeerState.Running;

                    break;
                }

            case DeerState.Running:
                {
                    RunAway();

                    if (distance > runAwayRadius)
                        currentState = DeerState.Eating;

                    break;
                }
        }

    }

    public void RunAway()
    {
        //random speed and run towards the assigned waypoint + animation
        randomSpeed = Random.Range(speedMin, speedMax);
        agent.speed = randomSpeed;

        Vector3 direction = waypointTarget.position - transform.position;
        transform.Translate(direction.normalized * randomSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, waypointTarget.position) <= 2f)
        {
            GetNextWaypoint();
        }
        agent.SetDestination(waypointTarget.position);

        Animator an = agent.GetComponent<Animator>();
        an.SetBool("isRunning", true);

    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoint.waypoints.Length - 1)
        {
            waypointIndex = 0;
        }

        waypointIndex++;
        waypointTarget = Waypoint.waypoints[waypointIndex];
    }

    public void StandStill()
    {
        agent.speed = 0;
        Animator an = agent.GetComponent<Animator>();
        an.SetBool("isRunning", false);

    }

    public void WalkAround()
    {
        //agent.speed = speedMin;
        //agent.SetDestination();

        Animator an = agent.GetComponent<Animator>();
        an.SetBool("isWalking", true);
    }
}
