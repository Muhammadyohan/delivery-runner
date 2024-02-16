using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCanCola : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerAttributeBooster playerAttributeBooster = other.GetComponent<PlayerAttributeBooster>();

        if (playerAttributeBooster != null)
        {
            playerAttributeBooster.StartCoroutine(playerAttributeBooster.SpeedBoostController());
            gameObject.SetActive(false);
        }
    }
}
