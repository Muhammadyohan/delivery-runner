using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionController : MonoBehaviour
{
    public static int characterSelected;
    
    [SerializeField] private GameObject girlModel;
    [SerializeField] private GameObject boyModel;

    private void Awake() 
    {
        if (characterSelected == 1)
        {
            boyModel.SetActive(false);
            girlModel.SetActive(true);
        }
        if (characterSelected == 2)
        {
            girlModel.SetActive(false);   
            boyModel.SetActive(true);
        }
    }
}
