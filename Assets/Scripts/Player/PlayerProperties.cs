using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{

    #region Singleton
    public static PlayerProperties instance;

    public static int amountWood = 0;
    public static int amountStone = 0;
    public static int amountFood = 0;

    private void Awake()
    {
        instance = this;
    }

    public GameObject player;

    #endregion



}
