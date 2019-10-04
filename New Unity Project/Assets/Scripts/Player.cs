using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D PlayerRgdbdy;
    public Animator animator; 
    private float constantVel = -2f, highJumpMultiplier= 2f, lowJumpMultper = 2.5f;
    public float impulseStrength = 5;


    private void Awake()
    {
        PlayerRgdbdy = GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("Jump"); // se ejecuta la animación
            Invoke("RebindAnim",1); // despues de ejecutarse se espera un segundo (para eso es la función invoke de monobhviour) y se llama a ejecución a la función propia RebindAnim
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.Play("JumpRigth"); // se ejecuta la animación
            Invoke("RebindAnim", 1); // despues de ejecutarse se espera un segundo (para eso es la función invoke de monobhviour) y se llama a ejecución a la función propia RebindAnim
        }

        if (Input.GetKey("left"))
        {
            PlayerRgdbdy.velocity = new Vector2(constantVel, 0);
            print("presionas izq");
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerRgdbdy.velocity = new Vector2(constantVel* -1, 0);
            print("presionas Rigth");
        }
    }

    void RebindAnim()
    {
        this.transform.parent.transform.position = this.transform.position; //se accede a la posición del transform del padre (que funge como mundo para el jugador) del transform en el que estamos trabjando (el del jugador), y le igualamos su valor (osea le igualamos el valor de la posición al padre) con el de el jugador    
        animator.Rebind(); // después del proceso anterior usamos la función rebindd de la clase animator, que sirve para reiniciar una animación.

    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            PlayerRgdbdy.velocity = Vector2.up * impulseStrength;
            print("presionas espacio");
        }

        MovementFix();
    }

    public void MovementFix()
    {
        // PlayerRgdbdy.AddForce(new Vector2 (-1, 2) * impulseStrength, ForceMode2D.Impulse); // velocity es una propiedad de la clase Rigidbody que permite modificar la posicion del transform
        if (PlayerRgdbdy.velocity.y < 0)
        {
            PlayerRgdbdy.velocity += Vector2.up * Physics2D.gravity.y * (highJumpMultiplier - 1) * Time.deltaTime;
        }

        else if (PlayerRgdbdy.velocity.y > 0 && !Input.GetKey("space"))
        {
            PlayerRgdbdy.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultper - 1) * Time.deltaTime;
        }

    }




    /*
     el jugador debe subir automaticamente un valor aleatorio de escalas
     El valor aleatorio de escalas subidas las determina la cantidad de escalas que se instancian automaticamente 
     se generan son 3 bloques de escalas para empezar, y siempre qeu se sube un boque se crea otro
     por cada bloque de escalas que se sube se deben generar nuevos enemigos prefab (al final de cada bloque debe haber como una referencia a que ahi debe aparecer el enemigo)
     se dispara en un rango de accion que se va moviendo continuamente en arco
     al disparar el jugador se pasa al turno de disparar del enemigo (deberia ser al azar tambien)

    un cuadrado que se monta sobre el otro yy se desplaza en x hacia la der o izq segun corresponda
    un rayo que salga por detras del personaje y detecte colisiones chocara con las escalas y sabra cuando parar cuando no coque con algo cercano 
    hacer qeu el colider no se active hasta tocar a la persona o que no se reacione sino a los coliders del y en el que esta

         */
}
