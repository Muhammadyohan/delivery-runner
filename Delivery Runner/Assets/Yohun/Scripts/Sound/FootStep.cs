using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    [SerializeField] AudioClip leftFootStepClip, rightFootStepClip; 

    private AudioSource audioSource;

    private void Awake() 
    {
        audioSource = GetComponent<AudioSource>();    
    }

    private void LeftFootStep()
    {
        audioSource.PlayOneShot(leftFootStepClip);
    }

    private void RightFootStep()
    {
        audioSource.PlayOneShot(rightFootStepClip);
    }
}
