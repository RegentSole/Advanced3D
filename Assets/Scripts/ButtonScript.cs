using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject panel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false);
        }
    }
}