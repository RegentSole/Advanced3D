using UnityEngine;
using UnityEngine.SceneManagement;

public class Pendulum : MonoBehaviour
{
    public float swingAngle = 45f;
    public float speed = 1f;

    private Quaternion startRotation;
    private float timeOffset;

    void Start()
    {
        startRotation = transform.rotation;
        timeOffset = Random.Range(0f, 2f * Mathf.PI);
    }

    void Update()
    {
        float angle = swingAngle * Mathf.Sin(Time.time * speed + timeOffset);
        transform.rotation = startRotation * Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}