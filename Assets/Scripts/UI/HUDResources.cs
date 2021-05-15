using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDResources : MonoBehaviour
{

    private double woodAmount = PlayerProperties.amountWood;
    private double stoneAmount = PlayerProperties.amountStone;
    private double foodAmount = PlayerProperties.amountFood;

    public Text woodText;
    public Text stoneText;
    public Text foodText;

    private void Update()
    {
        woodText.text = " " + woodAmount;
        stoneText.text = " " + stoneAmount;
        foodText.text = " " + foodAmount;

        woodAmount = PlayerProperties.amountWood;
        stoneAmount = PlayerProperties.amountStone;
        foodAmount = PlayerProperties.amountFood; 
    }


}


