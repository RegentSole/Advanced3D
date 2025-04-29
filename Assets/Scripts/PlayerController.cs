using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;              // Базовая скорость движения
    public float rotationSpeed = 100f;        // Скорость вращения камеры мышью
    public float jumpForce = 5f;              // Сила прыжка
    public KeyCode jumpKey = KeyCode.Space;   // Кнопка прыжка

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Получаем данные управления движением
        float horizontalMove = Input.GetAxisRaw("Horizontal"); // A/D
        float verticalMove = Input.GetAxisRaw("Vertical");     // W/S

        // Формируем вектор движения с учётом направления персонажа
        Vector3 movementVector = (transform.forward * verticalMove + transform.right * horizontalMove) * moveSpeed;

        // Добавляем физическое воздействие
        rb.AddForce(movementVector, ForceMode.Acceleration);

        // Обработка поворота камеры мышью
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.fixedDeltaTime);

        // Выполняем прыжок
        if (Input.GetKeyDown(jumpKey))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}