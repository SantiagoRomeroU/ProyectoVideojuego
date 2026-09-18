using UnityEngine;
// 1. IMPORTANTE: Hay que añadir esta línea arriba
using UnityEngine.InputSystem; 

public class ControlesMovimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float rotacion = 200f;

    void Update()
    {
        // 2. Así se leen las teclas en el Nuevo Input System de forma directa
        float moverZ = 0f;
        float rotarX = 0f;

        // Leer W/S o flechas arriba/abajo
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) moverZ = 1f;
        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) moverZ = -1f;

        // Leer A/D o flechas izquierda/derecha
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) rotarX = 1f;
        else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) rotarX = -1f;

        // El resto del movimiento se queda exactamente igual
        transform.Translate(Vector3.forward * moverZ * velocidad * Time.deltaTime);
        transform.Rotate(Vector3.up * rotarX * rotacion * Time.deltaTime);
    }
}
