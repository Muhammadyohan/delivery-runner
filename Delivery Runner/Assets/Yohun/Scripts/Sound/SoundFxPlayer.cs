using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFxPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource pizzaCollectSFX, speedBoostCollectSFX, scoreBoostCollectSFX,knockDownSFX, boyJumpingSFX, girlJumpingSFX, rollingSFX;

    public void PlayPizzaCollectSFX()
    {
        pizzaCollectSFX.Play();
    }

    public void PlaySpeedBoostCollectSFX()
    {
        speedBoostCollectSFX.Play();
    }

    public void PlayScoreBoostCollectSFX()
    {
        scoreBoostCollectSFX.Play();
    }

    public void PlayKnockDownSFX()
    {
        knockDownSFX.Play();
    }

    public void PlayJumpingSFX()
    {
        if (CharacterSelectionController.characterSelected == 1)
            girlJumpingSFX.Play();
        if (CharacterSelectionController.characterSelected == 2)
            boyJumpingSFX.Play();
    }

    public void PlayRollingSFX()
    {
        rollingSFX.Play();
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
