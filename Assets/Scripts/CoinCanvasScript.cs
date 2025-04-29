using UnityEngine;
using TMPro;

public class CoinCanvasScript : MonoBehaviour
{
    public TMP_Text coinText;
    public int coins = 0;

    void Start()
    {
        coinText.text = "Coins: " + coins;
    }

    public void AddCoins(int value)
    {
        coins += value;
        coinText.text = "Coins: " + coins;
    }
}