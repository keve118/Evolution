using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutAble : MonoBehaviour
{
    GameObject thisResource;
    public int woodHealth = 5;
    public int mass = 10;
    public int force = 9;
    public GameObject rest=null;
    public float timeFallen = 5f;
    private bool isFallen = false;

    private void Start()
    {
        if(gameObject.tag=="Stone")
            thisResource = gameObject;
        if(gameObject.tag=="Wood")
            thisResource = transform.parent.gameObject;
    }

    private void Update()
    {
        if (woodHealth <= 0 && isFallen == false)
        {
            Rigidbody rb = thisResource.AddComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.mass = mass;
            rb.AddForce(Vector3.forward*force, ForceMode.Impulse);
            StartCoroutine(destroyBush());

            isFallen = true;
        }

        IEnumerator destroyBush()
        {
           
            yield return new WaitForSeconds(timeFallen);          
            Destroy(thisResource);
            Instantiate(rest, transform.position + new Vector3(0,1,0), transform.rotation);
        }

    }
}
