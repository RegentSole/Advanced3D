using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class DangerZoneScript : MonoBehaviour
{
    public GameObject fallingObject;
    public float fallDelay = 2f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FallObject());
        }
    }

    IEnumerator FallObject()
    {
        yield return new WaitForSeconds(fallDelay);
        fallingObject.SetActive(true);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}