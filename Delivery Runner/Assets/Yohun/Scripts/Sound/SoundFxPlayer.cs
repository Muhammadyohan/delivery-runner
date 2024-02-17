using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFxPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource pizzaCollectSFX, boostCollectSFX, knockDownSFX, jumpingSFX, rollingSFX, runningSound;

    public void PlayPizzaCollectSFX()
    {
        pizzaCollectSFX.Play();
    }

    public void PlayBoostCollectSFX()
    {
        boostCollectSFX.Play();
    }

    public void PlayKnockDownSFX()
    {
        knockDownSFX.Play();
    }

    public void PlayJumpingSFX()
    {
        jumpingSFX.Play();
    }

    public void PlayRollingSFX()
    {
        rollingSFX.Play();
    }

    public void PlayRunningSound()
    {
        runningSound.Play();
    }

    public void StopRunningSound()
    {
        runningSound.Stop();
    }

    // public void PlaySlashSFX()
    // {
    //     slashSFX.Play();
    // }

    // public void PlayLogEnemyDedSFX()
    // {
    //     logEnemyDedSFX.Play();
    // }
}
