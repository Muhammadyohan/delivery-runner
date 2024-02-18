using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerInventory : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public int NumberOfPizza {get; private set;}
    public int pizzaAmountScore = 1;
    public UnityEvent<PlayerInventory> OnPizzaCollected;

    public float numberOfPizza = 0;

    public static int hiPizzaScore;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void PizzaCollected()
    {
        NumberOfPizza += pizzaAmountScore;
        numberOfPizza += pizzaAmountScore;
        OnPizzaCollected.Invoke(this);
    }

    public void PizzaAmountSpeedBoost()
    {
        playerMovement.speed += numberOfPizza/10000;
        playerMovement.speedBuffer += numberOfPizza/10000;
    }

    public void SaveHighScore()
    {
        if (NumberOfPizza > hiPizzaScore)
        {
            hiPizzaScore = NumberOfPizza;
            PlayerPrefs.SetInt("HighScore", hiPizzaScore);
        }
    }
}
