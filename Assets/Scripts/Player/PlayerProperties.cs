using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{

    #region Singleton
    [HideInInspector] public PlayerProperties instance;

    public static double amountWood = 0;
    public static double amountStone = 0;
    public static double amountFood = 0;
    
    private void Awake()
    {
        instance = this;
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
    }

}
