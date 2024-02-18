using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockDownController : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    public bool _isGameOver = false;
    private float timeDelay = 1.5f;
    private float countUpTime = 0;

    private void Update()
    {
        if (_isGameOver)
        {
            countUpTime += Time.unscaledDeltaTime;
            if (countUpTime >= timeDelay)
            {
                EnableGameOverMenu();
            }
        }
    }

    public void KnockDowned()
    {
        _isGameOver = true;
        Time.timeScale = 0;
    }

    private void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
}
