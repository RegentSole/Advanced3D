using UnityEngine;

public class FallButtonScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, -10f, other.gameObject.transform.position.z);
        }
    }
}