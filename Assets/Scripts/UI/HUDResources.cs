using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDResources : MonoBehaviour
{

    private int woodAmount = PlayerProperties.amountWood;
    private int stoneAmount = PlayerProperties.amountStone;
    private int foodAmount = PlayerProperties.amountFood;

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


