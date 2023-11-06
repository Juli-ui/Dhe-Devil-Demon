using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronesEnemigo : MonoBehaviour
{
    /*Vector3 PosInicial;
    Vector3 nuevaPosi;
    public int speed;
    public int myMovementRange = 7;
    public int myMovementRangeY;
    bool MoverEnXoY = false;
    bool Llego = false;*/
    public int vida = 10;
    public int vidaEnemigo = 1;
    public float speed;
    public Transform[] puntosDeMovimiento;
    public float distanciaMinima;
    public int puntoSiguiente=0;
    public bool esRegenerativo = false;
    public bool esSaltador = false;
    float tiempoRegenerar =0;
    public Explosion explosion;

    // Start is called before the first frame update
    void Start()
    {
       puntoSiguiente=0;


        /*PosInicial = transform.position;
        Vector3 nuevaPosi = transform.position;*/

        
        /*myMovementRange = 6;
        myMovementRangeY = 3;*/
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position = Vector3.MoveTowards(transform.position, puntosDeMovimiento[puntoSiguiente].position,2 * Time.deltaTime);
        if(Vector3.Distance(transform.position, puntosDeMovimiento[puntoSiguiente].position) < distanciaMinima)
        {
            puntoSiguiente++;
            if(puntoSiguiente >= puntosDeMovimiento.Length)
            {
                
                vida--;
                //Debug.Log("Perdiste 1 de vida");
                Destroy(gameObject);
                if(vida == 0)
                {
                    Debug.Log("Perdiste");
                    //perdio
                }
            }
            
            
        }
        if(esRegenerativo)
        {
            tiempoRegenerar += Time.deltaTime;
            if(vidaEnemigo < 4)
            {
                if(tiempoRegenerar >=1.5)
                {
                    vidaEnemigo+=1;
                    tiempoRegenerar=0;
                }  
            }
        }
        if(esSaltador)
        {
            if(puntoSiguiente==2)
            {
                puntoSiguiente=3;
            }
            if(puntoSiguiente==6)
            {
                puntoSiguiente=7;
            }
        }
        
            



        /*transform.position += new Vector3(2,0,0) * speed * Time.deltaTime;
        if(transform.position.x >= myMovementRange)
            vida--;*/



        /*if(MoverEnXoY == false)
        {
            nuevaPosi = transform.position;
            transform.position += new Vector3(1,0,0) * speed * Time.deltaTime;
            
        }
        if(MoverEnXoY)
        {
            transform.position += new Vector3(0,1,0) * speed * Time.deltaTime;
            nuevaPosi = transform.position;
        }
        if(transform.position.x == nuevaPosi.x + 3)
            {
                MoverEnXoY = true;
            }
        if(transform.position.y == transform.position.y + 2)
            {
                MoverEnXoY = false;
            }
        if(transform.position.x == transform.position.x + 3)
            {
                MoverEnXoY = true;
            }
        if(transform.position.y == transform.position.y - 2)
            {
                MoverEnXoY = false;
            }
        if(transform.position.x == transform.position.x + 4)
            {
                MoverEnXoY = true;
            }
        if(transform.position.y == transform.position.y + 4)
            {
                MoverEnXoY = false;
            }
        if(transform.position.x == transform.position.x + 10)
            {
                MoverEnXoY = true;
            }*/

        /*if(transform.position.x == (-7.4))
        {
            MoverEnXoY = true;
        }
        if(transform.position.y == (-0.4))
        {
            MoverEnXoY = false;
        }
        if(transform.position.x == (-4.4))
        {
            MoverEnXoY = true;
        }
        if(transform.position.y == (-2.4))
        {
            MoverEnXoY = false;
        }
        if(transform.position.x == 0.4)
        {
            MoverEnXoY = true;
        }
        if(transform.position.y == 1.4)
        {
            MoverEnXoY = false;
        }
        if(transform.position.x == 10.4)
        {
            MoverEnXoY = true;
        }*/
        
        
        
        
        /*if(MoverEnXoY == false)
        {
            transform.position += new Vector3(2,0,0) * speed * Time.deltaTime;
        }
        if(MoverEnXoY)
        {
            transform.position += new Vector3(0,1,0) * speed * Time.deltaTime;
        }
        if(transform.position.x >= myMovementRange)
        {
            MoverEnXoY = true;
        }
        if(transform.position.y >= myMovementRangeY)
        {
            MoverEnXoY = false;
        }*/
                
            
        //Movimiento();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bala")
        {
            vidaEnemigo-=1;
            if(vidaEnemigo<=0)
            {
                Destroy(gameObject);
                //Debug.Log("MurioElEnemigo");
            }
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "BalaSnipper")
            {
                vidaEnemigo-=3;
                if(vidaEnemigo<=0)
                {
                    Destroy(gameObject);
                    //Debug.Log("MurioElEnemigo");
                }
                Destroy(other.gameObject);
            }
        if (other.gameObject.tag == "BalaExplosiva")
        {
            
            vidaEnemigo -= 10;
            Instantiate(explosion, transform.position, Quaternion.identity);
            if (vidaEnemigo <= 0)
            {
                Destroy(gameObject);
                //Debug.Log("MurioElEnemigo");
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Explosion")
        {
            vidaEnemigo -= 10;
            if (vidaEnemigo <= 0)
            {
                Destroy(gameObject);
                //Debug.Log("MurioElEnemigo");
            }
            Destroy(other.gameObject);
        }
    }
    /*void Movimiento()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if(h != 0 || v != 0)
        transform.position += new Vector3(h,v,0)* speed * Time.deltaTime;
    }*/
}
