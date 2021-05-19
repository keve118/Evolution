using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{
    Transform player;
    ParticleSystem rainObject;
    public GameObject rain;
    float countdown = 5f;
    float waitBetweenRain = 10f;

    bool raining = false;

    public enum RainState
    {
        raining, 
        notRaining
    }
    RainState currentState;
    private void Start()
    {
        player = PlayerManager.instance.player.transform;
        rainObject = GetComponent<ParticleSystem>();
        rain = GetComponent<GameObject>();
    }

    void Update()
    {
        switch(currentState)
        {
            case RainState.raining:
                {
                    Rain();
                    //FindObjectOfType<SoundManager>().Play("Rain");
                    if (countdown <= 0)
                    {
                        waitBetweenRain = 10f;
                        currentState = RainState.notRaining;
                    }

                    float distance = Vector3.Distance(player.position, transform.position);
                    if (distance != player.position.x)
                    {
                        Vector3 offset = new Vector3(0,20,0);
                        player.position += offset;
                        rainObject.transform.position = player.position;

                    }
                        
                        
                    break;
                }
            case RainState.notRaining:
                {
                    StopRain();
                    FindObjectOfType<SoundManager>().Stop("Rain");
                    if (waitBetweenRain <= 0)
                    {
                        countdown = 5f;
                        currentState = RainState.raining;
                    }
                    
                    break;
                }

                
        }

        Debug.Log("Count: " + countdown + "    Wait: " + waitBetweenRain);
    }

    void Rain()
    {
        rainObject.Play();
        countdown -= Time.deltaTime;
        //Debug.Log("Count: " + countdown);
    }

    void StopRain()
    {
        rainObject.Stop();
        waitBetweenRain -= Time.deltaTime;
        //Debug.Log("Wait: " + waitBetweenRain);
    }
}
