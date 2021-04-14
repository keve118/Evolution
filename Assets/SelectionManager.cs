using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    
    [SerializeField] private string selectableTag = "Wood";
    [SerializeField] public Material highLightMaterialWood;
    [SerializeField] private Material defaultMaterial;
    private Transform selection1;

    private void Start()
    {
   
    }




    private void Update()
    {      
        if (selection1 != null) 
        {
            var selectionRenderer = selection1.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            selection1 = null;       
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(ray, out hit,10))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag)) 
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highLightMaterialWood;
                }
                selection1 = selection;
            }                   
        }
    }
}
