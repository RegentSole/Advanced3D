using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Portal : MonoBehaviour
{
    public Transform destination;
    public GameObject messagePanel;
    public TMP_Text messageText;
    public string message = "Портал активирован!";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = destination.position;
            ShowMessage();
        }
    }

    private void ShowMessage()
    {
        messageText.text = message;
        messagePanel.SetActive(true);
    }

    private void Update()
    {
        if (messagePanel.activeSelf && Input.anyKeyDown)
        {
            messagePanel.SetActive(false);
        }
    }
}