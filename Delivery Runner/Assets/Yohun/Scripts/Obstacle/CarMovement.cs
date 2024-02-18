using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float carSpeed = 0.3f;
    [SerializeField] private Vector3 checkRadius;

    private PlayerMovement playerMovement;

    public LayerMask player;
    private Collider[] colliders;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void FixedUpdate()
    {
        colliders = Physics.OverlapBox(transform.position, checkRadius, Quaternion.identity, player);
        foreach (Collider coll in colliders)
        {
            if (coll.gameObject.tag == "Player")
            {
                carSpeed = playerMovement.speedBuffer/20;
                transform.Translate(0, 0, carSpeed);
            }
        }
    }
}
