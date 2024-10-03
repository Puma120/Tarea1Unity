using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    //Campos serializados para la comunicación que permiten al diseñador de juego cambiar las variables
    [SerializeField]
    private float speed; // Variable de velocidad de movimiento
    public float rotationspeed; // Variable de velocidad de rotación
    private Rigidbody rb; // Instanciar un cuerpo rigido
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible= false; // Ocultar el mouse al darle iniciar el juego
        Cursor.lockState = CursorLockMode.Locked; // Limitar el movimiento del cursor solo a solo dentro de la pantalla de juego
        rb = GetComponent<Rigidbody>(); // Obtiene el componente al que esta asociado el cuerpo rígido
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)) // Detectar si la tecla W o la 
        {
            rb.AddRelativeForce(0, 0, speed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddRelativeForce(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddRelativeForce(-speed * Time.deltaTime, 0,0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddRelativeForce(speed * Time.deltaTime, 0, 0);
        }
        float mousex = Input.GetAxis("Mouse X");
        rb.AddRelativeTorque(0, mousex*rotationspeed*Time.deltaTime, 0);
    }
}
