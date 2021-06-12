using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderBehavior : MonoBehaviour
{
    [SerializeField] int starCost = 100;


    public void DefenderStarIncrease(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    public int GetStarCost()
    {
        return starCost;
    }

}
