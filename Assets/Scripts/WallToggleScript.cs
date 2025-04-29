using UnityEngine;

public class WallToggleScript : MonoBehaviour
{
    public GameObject wall;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wall.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wall.SetActive(true);
        }
    }
}