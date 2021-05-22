using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField] private InputFieldExample input;
    [SerializeField] private Text coinText;
    private int coins = 0;

    private void Start()
    {
        input.AddCoin += Display;
    }

    private void OnDisable()
    {
        input.AddCoin -= Display;
    }

    private void Display()
    {
        coins++;
        coinText.text = coins.ToString();
    }
}
