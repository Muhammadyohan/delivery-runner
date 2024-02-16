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

    public void PizzaCollected()
    {
        NumberOfPizza += pizzaAmountScore;
        numberOfPizza += pizzaAmountScore;
        OnPizzaCollected.Invoke(this);
    }

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void PizzaAmountSpeedBoost()
    {
        playerMovement.speed += numberOfPizza/10000;
    }
}
