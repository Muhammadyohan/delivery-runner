using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseController : MonoBehaviour
{
    public UnityEvent GamePaused;
    public UnityEvent GameResumed;

    private KnockDownController knockDownController;
    private CarMovement[]? carMovement;

    public bool _isPaused;

    void Start()
    {
        knockDownController = GetComponent<KnockDownController>();
    }

    void Update()
    {
        if (!knockDownController._isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _isPaused = !_isPaused;

                if (_isPaused)
                {
                    PauseGame();
                }
                else
                {
                    ResumeGame();
                }
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        carMovement = FindObjectsOfType(typeof(CarMovement)) as CarMovement[];
        foreach (CarMovement car in carMovement)
        {
            car.gameObject.GetComponent<CarMovement>().enabled = false;
        }
        GamePaused.Invoke();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        GameResumed.Invoke();
        carMovement = FindObjectsOfType(typeof(CarMovement)) as CarMovement[];
        foreach (CarMovement car in carMovement)
        {
            car.gameObject.GetComponent<CarMovement>().enabled = true;
        }
    }
}
