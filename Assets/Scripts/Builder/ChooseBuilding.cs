using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBuilding : MonoBehaviour
{
   public Transform positionObject; 
   public GameObject primitiveHut;

   public void PrimitiveHut() 
   {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = positionObject.position;
        //this.transform.parent=GameObject
   }

    private void OnMouseDown()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;


    }
   
}
