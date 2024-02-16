using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockDownController : MonoBehaviour
{
    private void Update() 
    {
        
    }

    public void KnockDowned()
    {
        Time.timeScale = 0;
    }
}
