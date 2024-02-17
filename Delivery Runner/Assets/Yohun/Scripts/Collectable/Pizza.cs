using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    [SerializeField] private SoundFxPlayer soundFxPlayer;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.PizzaCollected();
            playerInventory.PizzaAmountSpeedBoost();
            //soundFxPlayer.PlayPizzaCollectSFX();
            gameObject.SetActive(false);
        }
    }
}
