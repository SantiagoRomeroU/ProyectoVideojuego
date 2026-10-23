using UnityEngine;
using UnityEngine.InputSystem;

public class movimientoAnimacion : MonoBehaviour
{
    public float velocidad = 5f; // Nota: Al usar físicas, un valor entre 5 y 10 suele ser suficiente. 50f podría ser demasiado rápido.
    public float rotacion = 200f;

    private Animator animator;
    private Rigidbody rb;
    private float moverZ = 0f;
    private float rotarX = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        // OPCIONAL: Esto asegura por código que el personaje no se tropiece o caiga de lado al chocar.
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        moverZ = 0f;
        rotarX = 0f;

        // 1. CAPTURA DE ENTRADAS (Igual a tu código original)
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) moverZ = 1f;
        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) moverZ = -1f;

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) rotarX = 1f;
        else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) rotarX = -1f;

        // 2. ROTACIÓN (Se puede mantener en Update porque rotar sobre el eje Y no rompe las colisiones frontales)
        transform.Rotate(Vector3.up * rotarX * rotacion * Time.deltaTime);

        // 3. ANIMACIÓN
        bool personajeSeMueve = (moverZ != 0f);
        if (animator.GetBool("EstaMoviendose") != personajeSeMueve)
        {
            animator.SetBool("EstaMoviendose", personajeSeMueve);
        }
    }

    // 4. MOVIMIENTO POR FÍSICAS (Ocurre en sincronía con el motor de colisiones)
    void FixedUpdate()
    {
        // Calculamos la dirección hacia adelante relativa a la rotación actual del personaje
        Vector3 direccionAvance = transform.forward * moverZ * velocidad;

        // Aplicamos la velocidad en X y Z, pero DEJAMOS intacta la velocidad en Y (rb.velocity.y).
        // Esto es crucial para que la gravedad siga haciendo caer al personaje si está en el aire.
        rb.linearVelocity = new Vector3(direccionAvance.x, rb.linearVelocity.y, direccionAvance.z);
    }
}
