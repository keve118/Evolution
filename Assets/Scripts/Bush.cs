using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    GameObject thisBush;
    public int bushHealth = 5;
    private bool isFallen = false;

    private void Start()
    {
        thisBush = transform.parent.gameObject;
    }

    private void Update()
    {
        if (bushHealth <= 0 && isFallen == false)
        {
            Rigidbody rb = thisBush.AddComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.AddForce(Vector3.forward, ForceMode.Impulse);
            StartCoroutine(destroyBush());
            isFallen = true;
        }

        IEnumerator destroyBush()
        {
            yield return new WaitForSeconds(5);
            Destroy(thisBush);
        }

    }
}
