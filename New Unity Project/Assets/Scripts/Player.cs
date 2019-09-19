using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D PlayerRgdbdy;
    float moveX = 5f, moveY= 3;
    bool avanzar = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                    Movement();
        }
        

    }

    public void Movement()
    {
        PlayerRgdbdy.velocity = new Vector2(moveX, moveY); // velocity es una propiedad de la clase Rigidbody que permite modificar la posicion del transform
    }




    /*
     el jugador debe subir automaticamente un valor aleatorio de escalas
     El valor aleatorio de escalas subidas las determina la cantidad de escalas que se instancian automaticamente 
     se generan son 3 bloques de escalas para empezar, y siempre qeu se sube un boque se crea otro
     por cada bloque de escalas que se sube se deben generar nuevos enemigos prefab (al final de cada bloque debe haber como una referencia a que ahi debe aparecer el enemigo)
     se dispara en un rango de accion que se va moviendo continuamente en arco
     al disparar el jugador se pasa al turno de disparar del enemigo (deberia ser al azar tambien)


         */
}
