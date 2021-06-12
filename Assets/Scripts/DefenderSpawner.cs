using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    DefenderBehavior defender;
    GameObject defenderParent;
    const string DEFENDER_STRING = "Defenders";
    private void OnMouseDown()
    {
        AttemptToPlaceDefender(GetSquareClick());
    }

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_STRING);

        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_STRING);
        }
    }


    public void SetSelectedDefender(DefenderBehavior defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private Vector2 GetSquareClick()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }
    private void SpawnDefender(Vector2 worldPos)
    {
        DefenderBehavior newDefender = Instantiate(defender, worldPos, Quaternion.identity);
        newDefender.transform.parent = defenderParent.transform;
    }

    private void AttemptToPlaceDefender(Vector2 gridPos)
    {
        StarDisplay starDisplay = FindObjectOfType<StarDisplay>();
        int costOfDefender = defender.GetStarCost();
        if (starDisplay.HaveEnoughStars(costOfDefender))
        {
            starDisplay.SpendStars(costOfDefender);
            SpawnDefender(gridPos);
        }
    }

}
