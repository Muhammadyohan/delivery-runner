using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfPizza {get; private set;}

    public UnityEvent<PlayerInventory> OnPizzaCollected;

    public void PizzaCollected()
    {
        NumberOfPizza++;
        OnPizzaCollected.Invoke(this);
    }
}
