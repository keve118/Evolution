using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{
    private Transform player;
    private ParticleSystem rainObject;
    private float rainCountdown;
    private float notRainingCountDown;
    private AudioSource rainAudioSource;

    [SerializeField] float randomCountMin;
    [SerializeField] float randomCountMax;

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
        rainAudioSource = GetComponent<AudioSource>();

        //start values for the rain and not rain countdowns
        rainCountdown = Random.Range(randomCountMin, randomCountMax);
        notRainingCountDown = Random.Range(randomCountMin, randomCountMax);

        //start with no rain
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
                        notRainingCountDown = Random.Range(randomCountMin, randomCountMax);
                        currentState = RainState.notRaining;
                    }

                    MoveWithPlayer();

                    break;
                }

            case RainState.notRaining:
                {
                    StopRain();

                    if (notRainingCountDown <= 0)
                    {
                        rainCountdown = Random.Range(randomCountMin, randomCountMax);
                        currentState = RainState.raining;
                    }
                    
                    break;
                }
        }
    }

    void Rain()
    {
        rainObject.Play();

        //rain sound
        if (!rainAudioSource.isPlaying)
            rainAudioSource.Play();

        rainCountdown -= Time.deltaTime;
    }

    void StopRain()
    {
        rainObject.Stop();
        rainAudioSource.Stop();
        notRainingCountDown -= Time.deltaTime;
    }

    //the rain particle system moves with the player
    void MoveWithPlayer()
    {
        //distance from player
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance != player.position.x)
        {
            Vector3 offset = new Vector3(0, 20, 0); //offset for the rain, otherwise the particles are created on the ground and not in the "sky"
            player.position += offset;
            rainObject.transform.position = player.position; //new position for the rain, above the player

        }
    }

}
