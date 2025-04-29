using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int value = 1;
    public GameObject coinCanvas;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinCanvas.GetComponent<CoinCanvasScript>().AddCoins(value);
            Destroy(gameObject);
        }
    }
}