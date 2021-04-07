using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonHandler : MonoBehaviour
{
    private int indexCurrent = 0;
    private int indexMax;
    private string vertical = "Vertical";
    
    [SerializeField] private int howManyButtonsInScene;
    [SerializeField] private bool keyDown;

    void Start()
    {
        indexMax = howManyButtonsInScene - 1;
    }

    void Update()
    {
        if (Input.GetAxis(vertical) != 0)
        {
            if (!keyDown)
            {
                if (Input.GetAxis(vertical) < 0)
                {
                    HandleUpwardIncrement();
                }
                else if (Input.GetAxis(vertical) > 0)
                {
                    HandleDownwardIncrement();

                }
            }
        }
    }

    private void HandleDownwardIncrement()
    {
        if (indexCurrent > 0)
        {
            indexCurrent--;
        }
        else
        {
            indexCurrent = indexMax;
        }
    }

    private void HandleUpwardIncrement()
    {
        if (indexCurrent < indexMax)
        {
            indexCurrent++;
        }
        else
        {
            indexCurrent = 0;
        }
    }
}
