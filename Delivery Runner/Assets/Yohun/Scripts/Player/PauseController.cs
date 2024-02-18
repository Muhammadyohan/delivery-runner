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
        carMovement = FindObjectsOfType(typeof(CarMovement)) as CarMovement[];
        foreach (CarMovement car in carMovement)
        {
            car.gameObject.GetComponent<CarMovement>().enabled = false;
        }
        Time.timeScale = 0;
        GamePaused.Invoke();
    }

    public void ResumeGame()
    {
        GameResumed.Invoke();
        Time.timeScale = 1;
        carMovement = FindObjectsOfType(typeof(CarMovement)) as CarMovement[];
        foreach (CarMovement car in carMovement)
        {
            car.gameObject.GetComponent<CarMovement>().enabled = true;
        }
    }
}
