using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeartDisplay : MonoBehaviour
{
    [SerializeField] float baseHealth = 100;
    float playerHealth;
    TextMeshProUGUI healthText;

    void Start()
    {
        playerHealth = baseHealth - (20 * PlayerPrefsController.GetDifficulty());
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
        playerHealth -= damage;
        UpdateDisplay();
        if (playerHealth <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }


    IEnumerator EndGame()
    {
        FindObjectOfType<LevelLoader>().GameOver();
        return new WaitForSecondsRealtime(2);
        
    }

}
