using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCanCola : MonoBehaviour
{
    [SerializeField] private SoundFxPlayer soundFxPlayer;
    private void OnTriggerEnter(Collider other)
    {
        PlayerAttributeBooster playerAttributeBooster = other.GetComponent<PlayerAttributeBooster>();

        if (playerAttributeBooster != null)
        {
            playerAttributeBooster.StartCoroutine(playerAttributeBooster.SpeedBoostController());
            soundFxPlayer.PlayBoostCollectSFX();
            gameObject.SetActive(false);
        }
    }
}
