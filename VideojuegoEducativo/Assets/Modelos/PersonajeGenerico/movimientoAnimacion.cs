using UnityEngine;
using UnityEngine.InputSystem;

public class movimientoAnimacion : MonoBehaviour
{
    public float velocidad = 5f;
    public float rotacion = 200f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moverZ = 0f;
        float rotarX = 0f;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) moverZ = 1f;
        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) moverZ = -1f;

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) rotarX = 1f;
        else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) rotarX = -1f;

        transform.Translate(Vector3.forward * moverZ * velocidad * Time.deltaTime);
        transform.Rotate(Vector3.up * rotarX * rotacion * Time.deltaTime);

        // EVALUACIÓN DE MOVIMIENTO:
        // Evaluamos si hay entrada en W/S (caminar) o en A/D (girar).
        // Si prefieres que NO camine al girar sobre su propio eje, cambia esto a: bool personajeSeMueve = (moverZ != 0f);
        bool personajeSeMueve = (moverZ != 0f);

        // OPTIMIZACIÓN: Solo actualiza el Animator si el estado real cambió.
        // Esto evita que la animación se reinicie o se trabe en cada fotograma.
        if (animator.GetBool("EstaMoviendose") != personajeSeMueve)
        {
            animator.SetBool("EstaMoviendose", personajeSeMueve);
        }
    }
}
