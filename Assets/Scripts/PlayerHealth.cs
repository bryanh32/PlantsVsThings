using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 100;
    TextMeshProUGUI healthText;

    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    // Update is called once per frame
    void UpdateDisplay()
    {
        healthText.text = playerHealth.ToString();
    }
    public float GetHealth()
    {
        return playerHealth;
    }

    public void TakeHealthDamage(float damage)
    {
        playerHealth += damage;
        UpdateDisplay();
        if (playerHealth <= 0)
        {
            StartCoroutine(EndGame());
        }
    }


    IEnumerator EndGame()
    {
        return new WaitForSecondsRealtime(2);
        FindObjectOfType<LevelLoader>().GameOver();
    }



}
