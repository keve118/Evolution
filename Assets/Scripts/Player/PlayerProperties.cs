using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{

    #region Singleton
    [HideInInspector] public PlayerProperties instance;

    public static double amountWood;
    public static double amountStone;
    public static double amountFood;

    public static double maxAmountWood;
    public static double maxAmountStone;
    public static double maxAmountFood;

    private void Awake()
    {
        instance = this;
        amountWood = 0;
        amountStone = 0;
        amountFood = 0;

        maxAmountWood = 20;
        maxAmountStone = 20;
        maxAmountFood = 20;


    }

    #endregion

    public GameObject player;
    public GameObject rayCastObject;

    [HideInInspector] public static Transform rayCastTransform;
    [HideInInspector] public static Vector3 rayCastOrigin;
    [HideInInspector] public static int resourceLayerID = 3;
    [HideInInspector] public static int resourceMask = 1 << 3;

    private void Update()
    {
        rayCastTransform = rayCastObject.transform;
        rayCastOrigin = rayCastTransform.position;         


        if(amountWood >= maxAmountWood) 
        { 
            
        
        }

    }

}
