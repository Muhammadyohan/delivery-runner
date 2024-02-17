using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCanCola : MonoBehaviour
{
    private SoundFxPlayer soundFxPlayer;

    private void Awake() 
    {
        soundFxPlayer = FindObjectOfType<SoundFxPlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerAttributeBooster playerAttributeBooster = other.GetComponent<PlayerAttributeBooster>();

        if (playerAttributeBooster != null)
        {
            playerAttributeBooster.StartCoroutine(playerAttributeBooster.SpeedBoostController());
            soundFxPlayer.PlaySpeedBoostCollectSFX();
            gameObject.SetActive(false);
        }
    }
}
