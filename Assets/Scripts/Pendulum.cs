using UnityEngine;
using UnityEngine.SceneManagement;

public class PendulumScript : MonoBehaviour
{
    public float swingSpeed = 1f;
    public float swingAngle = 45f;

    void Update()
    {
        transform.Rotate(new Vector3(0, swingSpeed * Time.deltaTime, 0), Space.World);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}