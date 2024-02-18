using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float carSpeed = 1f;
    [SerializeField] private Vector3 checkRadius;

    private PlayerMovement playerMovement;

    public LayerMask player;
    private Collider[] colliders;

    void Start() 
    {
        
    }

    void Update()
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
