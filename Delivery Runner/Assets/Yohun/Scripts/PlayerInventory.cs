using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerInventory : MonoBehaviour
{


    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {  

    }

    private void SpeedBoostHandler()
    {
        // if (isSpeedBoost)
        // {
        //     // transform.Translate(0, 0, speedBoostForSpeedBooster);
        //     // playerCollider.enabled = false;
        //     // rbody.isKinematic = true;
        // }
        // else
        // {
        //     // playerCollider.enabled = true;
        //     // rbody.isKinematic = false;
        // }
    }

    IEnumerator SpeedBoostController()
    {
        // isSpeedBoost = true;
        yield return new WaitForSeconds(3);
        // isSpeedBoost = false;
    }
    private void OnTriggerEnter(Collider other) 
    {
        // if (other.gameObject.tag == "Speed Booster")
        // {
        //     Destroy(other.gameObject);
        //     StartCoroutine(SpeedBoostController());
        // }

        // if (other.gameObject.tag == "Pizza")
        // {
        //     Destroy(other.gameObject);
        //     score += 1;
        // }
    }
}
