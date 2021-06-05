using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    public float timePassed = 1f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
      
    }

}
