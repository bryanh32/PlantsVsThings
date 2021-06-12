using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DefenderButton : MonoBehaviour
{

    [SerializeField] DefenderBehavior defenderPrefab;


    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        TextMeshProUGUI costText = GetComponentInChildren<TextMeshProUGUI>();
        if (!costText)
        {
            Debug.Log(name + " has no cost text.");
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();

        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(46,46,46,255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
