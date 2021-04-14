using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandToolAnimation : MonoBehaviour
{
    private Animator animator;
    private bool isAnimating = false;
    public float timePassed = 1f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) ) 
        {
            animator.SetBool("isCutting", true);
            StartCoroutine(ResetAnimation());
        }
    }
    IEnumerator ResetAnimation()
    {
        yield return new WaitForSeconds(timePassed);
        animator.SetBool("isCutting", false);
    }


}
