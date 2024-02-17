using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    private SoundFxPlayer soundFxPlayer;
    
    private void Awake() 
    {
        soundFxPlayer = FindObjectOfType<SoundFxPlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.PizzaCollected();
            playerInventory.PizzaAmountSpeedBoost();
            soundFxPlayer.PlayPizzaCollectSFX();
            gameObject.SetActive(false);
        }
    }
}
