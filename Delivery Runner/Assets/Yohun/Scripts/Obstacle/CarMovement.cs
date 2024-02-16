using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float carSpeed = 1f;

    void Update()
    {
        transform.Translate(0, 0, carSpeed);
    }
}
