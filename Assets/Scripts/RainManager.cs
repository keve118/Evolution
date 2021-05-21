using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{
    Transform player;
    ParticleSystem rainObject;
    float rainCountdown;
    float waitForRain;
    private AudioSource audioSource;

    public float randomCountMin;
    public float randomCountMax;

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
        audioSource = GetComponent<AudioSource>();

        rainCountdown = Random.Range(randomCountMin, randomCountMax);
        waitForRain = Random.Range(randomCountMin, randomCountMax);

        currentState = RainState.notRaining;
    }

    void Update()
    {
        switch(currentState)
        {
            case RainState.raining:
                {
                    Rain();

                    if (rainCountdown <= 0)
                    {
                        waitForRain = Random.Range(randomCountMin, randomCountMax);
                        currentState = RainState.notRaining;
                    }

                    MoveWithPlayer();

                    break;
                }

            case RainState.notRaining:
                {
                    StopRain();

                    if (waitForRain <= 0)
                    {
                        rainCountdown = Random.Range(randomCountMin, randomCountMax);
                        currentState = RainState.raining;
                    }
                    
                    break;
                }

        }

        Debug.Log("Count: " + rainCountdown + "    Wait: " + waitForRain);
    }

    void Rain()
    {
        rainObject.Play();

        //rain sound
        if (!audioSource.isPlaying)
            audioSource.Play();

        rainCountdown -= Time.deltaTime;
    }

    void StopRain()
    {
        rainObject.Stop();
        audioSource.Stop();
        waitForRain -= Time.deltaTime;
    }

    void MoveWithPlayer()
    {
        //distance from player
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance != player.position.x)
        {
            Vector3 offset = new Vector3(0, 20, 0); //offset for the rain
            player.position += offset;
            rainObject.transform.position = player.position; //new position for the rain, above the player, even when player is moving

        }
    }

}
