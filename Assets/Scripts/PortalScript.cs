using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject panel;
    public Vector3 teleportPosition;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = teleportPosition;
            panel.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.anyKeyDown && panel.activeInHierarchy)
        {
            panel.SetActive(false);
        }
    }
}