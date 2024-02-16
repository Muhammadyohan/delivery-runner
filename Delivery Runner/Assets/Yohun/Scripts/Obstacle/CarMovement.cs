using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float carSpeed = 1f;
    [SerializeField] private float checkRadius;

    public LayerMask player;
    private Collider[] colliders;
    void Update()
    {
        colliders = Physics.OverlapSphere(transform.position, checkRadius, player);
        foreach (Collider coll in colliders)
        {
            if (coll.gameObject.tag == "Player")
            {
                transform.Translate(0, 0, carSpeed);
            }
        }
    }
}
