using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplete : MonoBehaviour
{
    public int resourceHP = 100;  //varje objekt med script kan ha unikt v�rde

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (resourceHP < 1)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other) //klick ist�llet
    {
        resourceHP -= 1; //samma v�rde som + i harvest

    }
}
