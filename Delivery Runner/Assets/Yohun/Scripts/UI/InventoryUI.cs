using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI pizzaText;

    void Start()
    {
        pizzaText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdatePizzaText(PlayerInventory playerInventory)
    {
        pizzaText.text = playerInventory.NumberOfPizza.ToString();
    }
}
