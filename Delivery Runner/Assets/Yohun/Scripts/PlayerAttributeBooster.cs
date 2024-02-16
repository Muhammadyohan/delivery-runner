using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerAttributeBooster : MonoBehaviour
{
    [SerializeField] float speedBoostNumber = 5;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public IEnumerator SpeedBoostController()
    {
        playerMovement.speed = playerMovement.speed + speedBoostNumber;
        yield return new WaitForSeconds(2.5f);
        playerMovement.speed = playerMovement.speed - speedBoostNumber;
    }
}
