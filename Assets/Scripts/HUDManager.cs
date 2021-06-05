using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{

    [SerializeField] private GameObject InventoryPanel;



    private void Start()
    {
        InventoryPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            InventoryPanel.SetActive(true);

        }
    }
}
