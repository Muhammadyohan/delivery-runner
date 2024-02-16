using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerAttributeBooster : MonoBehaviour
{
    [SerializeField] float speedBoostPercentNumber = 20;
    [SerializeField] int pizzaScoreBoostMultiple = 1;

    private PlayerMovement playerMovement;
    private PlayerInventory playerInventory;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInventory = GetComponent<PlayerInventory>();
    }

    public IEnumerator CollectBoostController()
    {
        playerInventory.pizzaAmountScore += pizzaScoreBoostMultiple;
        yield return new WaitForSeconds(2.5f);
        playerInventory.pizzaAmountScore -= pizzaScoreBoostMultiple;
    }

    public IEnumerator SpeedBoostController()
    {
        float speedBoostAdder;
        speedBoostAdder = speedBoostPercentNumber/100 * playerMovement.speedBuffer;
        playerMovement.speed += speedBoostAdder;
        yield return new WaitForSeconds(2.5f);
        playerMovement.speed -= speedBoostAdder;
    }
}
