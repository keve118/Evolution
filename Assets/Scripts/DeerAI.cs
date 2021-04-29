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
    public float speedMin = 2f;
    public float speedMax = 7f;
    public float randomSpeed;
    public float walkSpeed = 1f;
    float distance;

    //Waypoint variables
    private Transform waypointTarget;
    private int waypointIndex = 0;
    int randomWaypoint;

    //walking variables
    private bool isWandering = false;
    private bool isWalking = false;
    private bool isRotLeft = false;
    private bool isRotRight = false;
    public float rotSpeed = 100f;

    public enum DeerState
    {
        Eating,
        Running, 
        Walking
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
                    if (isWandering == false)
                    {
                        StartCoroutine(Wander());
                    }

                    if (isWalking)
                        currentState = DeerState.Walking;

                    if(isWalking == false)
                    {
                        Animator an = agent.GetComponent<Animator>();
                        an.SetBool("isWalking", false);
                    }

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

            case DeerState.Walking:
                {
                    if (isRotRight == true)
                    {
                        agent.transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
                    }

                    if (isRotLeft == true)
                    {
                        agent.transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
                    }

                    agent.speed = walkSpeed;
                    agent.transform.position += transform.forward * walkSpeed * Time.deltaTime;
                    Animator an = agent.GetComponent<Animator>();
                    an.SetBool("isWalking", true);
                    
                    if (isWandering == false)
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

    IEnumerator Wander()
    {
        //moves the deer in random directions (not the waypoints), stops for awhile and then walks again depending on the random times
        int rotTime = Random.Range(1, 2);
        int rotWait = Random.Range(1, 4);
        int rotLeftOrRight = Random.Range(1, 20);
        int walkWait = Random.Range(10, 60);
        int walkTime = Random.Range(10, 20);
        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;

        yield return new WaitForSeconds(rotWait);
        if (rotLeftOrRight <= 10)
        {
            isRotRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotRight = false;
        }
        if (rotLeftOrRight >= 11)
        {
            isRotLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotLeft = false;
        }

        isWandering = false;
    }
}
