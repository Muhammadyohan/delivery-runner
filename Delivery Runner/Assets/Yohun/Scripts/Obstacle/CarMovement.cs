using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float carSpeed = 0.2f;
    [SerializeField] private Vector3 checkRadius;

    public LayerMask player;
    private Collider[] colliders;

    void FixedUpdate()
    {
        colliders = Physics.OverlapBox(transform.position, checkRadius, Quaternion.identity, player);
        foreach (Collider coll in colliders)
        {
            if (coll.gameObject.tag == "Player")
            {
                transform.Translate(0, 0, carSpeed);
            }
        }
    }
}
