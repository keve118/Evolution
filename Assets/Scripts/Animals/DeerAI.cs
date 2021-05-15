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

    Animator animator;
    public enum DeerState
    {
        Eating,
        Running, 
        Walking, 
        Dieing
    }
    public DeerState currentState;

    void Start()
    {
        player = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = agent.GetComponent<Animator>();

        randomWaypoint = Random.Range(0, Waypoint.waypoints.Length);
        waypointTarget = Waypoint.waypoints[randomWaypoint];
    }

    void Update()
    {
        //distance to player from agent (deer)
        distance = Vector3.Distance(player.position, transform.position); 

        switch (currentState)
        {
            case DeerState.Eating:
                {
                    agent.speed = 0;
                    if (isWandering == false)
                    {
                        StartCoroutine(Wander());
                    }

                    if (isWalking)
                        currentState = DeerState.Walking;

                    if(isWalking == false)
                    {
                        animator.SetBool("isWalking", false);
                        animator.SetBool("isRunning", false);
                        animator.SetBool("isEating", true);
                    }

                    if (distance <= lookRadius && ToolSwitching.huntingToolEquiped)
                        currentState = DeerState.Running;

                    break;
                }

            case DeerState.Running:
                {
                    RunAway();

                    if (distance > runAwayRadius)
                        currentState = DeerState.Eating;

                    Harvest harvestScript = gameObject.GetComponent<Harvest>();
                    if (harvestScript.health <= 0)
                    {
                        currentState = DeerState.Dieing;
                    }

                    break;
                }

            case DeerState.Walking:
                {
                    //decides the rotation / direction to face
                    if (isRotRight == true)
                    {
                        agent.transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
                    }

                    if (isRotLeft == true)
                    {
                        agent.transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
                    }
                                        
                    animator.SetBool("isRunning", false);
                    animator.SetBool("isEating", false);
                    animator.SetBool("isWalking", true);

                    agent.speed = walkSpeed;
                    agent.transform.position += transform.forward * walkSpeed * Time.deltaTime;

                    //distance = distance between player and the deer
                    if (distance <= lookRadius && ToolSwitching.huntingToolEquiped)
                        currentState = DeerState.Running;

                    if (isWandering == false)
                        currentState = DeerState.Eating;

                    break;
                }

            case DeerState.Dieing:
                {
                    agent.speed = 0;
                    animator.SetBool("isRunning", false);
                    animator.SetBool("isDead", true);

                    break;
                }

        }

    }

    public void RunAway()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isEating", false);
        animator.SetBool("isRunning", true);

        //random speed and run towards the assigned waypoint
        randomSpeed = Random.Range(speedMin, speedMax);
        agent.speed = randomSpeed;

        Vector3 direction = waypointTarget.position - transform.position;
        transform.Translate(direction.normalized * randomSpeed * Time.deltaTime, Space.World);

        //3f = margin from the waypoint position that the deer switch destination to the next waypoint
        if (Vector3.Distance(transform.position, waypointTarget.position) <= 3f)
        {
            GetNextWaypoint();
        }
        agent.SetDestination(waypointTarget.position);

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
        //moves the deer in random directions (not the waypoints)
        int rotTime = Random.Range(1, 2);
        int rotWait = Random.Range(1, 4);
        int rotLeftOrRight = Random.Range(1, 2);
        int walkWait = Random.Range(10, 60);
        int walkTime = Random.Range(10, 20);
        isWandering = true;

        //waits for a random amount of seconds before it starts to walk
        yield return new WaitForSeconds(walkWait);
        isWalking = true;

        //walks for a random amount of seconds before stopping
        yield return new WaitForSeconds(walkTime);
        isWalking = false;

        //waits for a random amount of seconds before rotating
        yield return new WaitForSeconds(rotWait);
        if (rotLeftOrRight == 1)
        {
            //rotates right for a random amount of seconds and then stops
            isRotRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotRight = false;
        }
        if (rotLeftOrRight == 2)
        {
            //rotates left for a random amount of seconds and then stops
            isRotLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotLeft = false;
        }

        isWandering = false;
    }
}
