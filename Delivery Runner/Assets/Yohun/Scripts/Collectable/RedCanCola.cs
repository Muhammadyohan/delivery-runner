using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCanCola : MonoBehaviour
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
            playerAttributeBooster.StartCoroutine(playerAttributeBooster.CollectBoostController());
            soundFxPlayer.PlayScoreBoostCollectSFX();
            gameObject.SetActive(false);
        }
    }
}
