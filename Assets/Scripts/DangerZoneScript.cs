using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingTrap : MonoBehaviour
{
    [Header("Trap Settings")]
    public float fallDelay = 0.2f;
    public float resetTime = 3f;

    private Rigidbody rb;
    private Vector3 initialPosition;
    private bool isFalling;
    private bool playerInZone;

    void Start()
    {
        // Получаем Rigidbody текущего объекта
        rb = GetComponent<Rigidbody>();

        // Сохраняем начальную позицию
        initialPosition = transform.position;

        // Настраиваем физику
        SetupPhysics();
    }

    private void SetupPhysics()
    {
        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing! Adding one...");
            rb = gameObject.AddComponent<Rigidbody>();
        }

        // Начальные настройки
        rb.useGravity = false;
        rb.isKinematic = true;
        isFalling = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFalling)
        {
            playerInZone = true;
            Invoke(nameof(ReleaseObject), fallDelay);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }

    private void ReleaseObject()
    {
        if (!playerInZone) return;

        isFalling = true;
        rb.isKinematic = false;
        rb.useGravity = true;
        Invoke(nameof(ResetObject), resetTime);
    }

    private void ResetObject()
    {
        // Возвращаем объект в исходное состояние
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;
        rb.isKinematic = true;

        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;
        isFalling = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем столкновение с игроком
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}