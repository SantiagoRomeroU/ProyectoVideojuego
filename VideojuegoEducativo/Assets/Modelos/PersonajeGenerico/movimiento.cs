using UnityEngine;
using UnityEngine.InputSystem;

public class ControlesMovimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float rotacion = 200f;

    private Rigidbody rb;

    private float moverZ;
    private float rotarX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Reiniciar valores
        moverZ = 0f;
        rotarX = 0f;

        // W o flecha arriba = avanzar
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            moverZ = 1f;
        }
        // S o flecha abajo = retroceder
        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            moverZ = -1f;
        }

        // D o flecha derecha = girar derecha
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            rotarX = 1f;
        }
        // A o flecha izquierda = girar izquierda
        else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            rotarX = -1f;
        }
    }

    void FixedUpdate()
    {
        // Movimiento
        Vector3 movimiento =
            transform.forward * moverZ * velocidad * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movimiento);

        // Rotación
        Quaternion rotacionNueva =
            rb.rotation *
            Quaternion.Euler(
                0f,
                rotarX * rotacion * Time.fixedDeltaTime,
                0f
            );

        rb.MoveRotation(rotacionNueva);
    }
}