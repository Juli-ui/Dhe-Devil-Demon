using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTurret : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer h;
    public SpriteRenderer e;
    public SpriteRenderer l;
    public SpriteRenderer l2;
    public string[] names = new string[3];
    public float PressTime;
    public float respawnTime;
    public bool respawnear;
    public bool hTrue;
    public bool eTrue;
    public bool lTrue;
    public bool l2True;
    public NewBehaviourScript Torrets;
    public NewBehaviourScript Torrets2;
    public NewBehaviourScript Torrets3;

    private bool lettersShown = false;

    private void Awake()
    {

        h.enabled = false;
        e.enabled = false;
        l.enabled = false;
        l2.enabled = false;
    }
    void Start()
    {
        Torrets = GameObject.Find("Torre").GetComponent<NewBehaviourScript>();
        Torrets2 = GameObject.Find("Torre (1)").GetComponent<NewBehaviourScript>();
        Torrets3 = GameObject.Find("Torre (2)").GetComponent<NewBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (respawnear)
        {
            respawnTime += Time.deltaTime;

            if (respawnTime >= 3)
            {
                if (!lettersShown)
                {
                    //Debug.Log("Se activan letras");
                    h.enabled = true;
                    e.enabled = true;
                    l.enabled = true;
                    l2.enabled = true;

                    lettersShown = true;
                }

                PressTime += Time.deltaTime;
                if (PressTime <= 3)
                {
                    //Debug.Log("Se activan letras");

                    //Poner activas las imagenes de cada letra
                    if (Input.GetKeyDown(KeyCode.H))
                    {
                        h.enabled = false;
                        hTrue = true;
                    }
                    if (Input.GetKeyDown(KeyCode.E) && hTrue)
                    {
                        e.enabled = false;
                        eTrue = true;
                    }
                    if (Input.GetKeyDown(KeyCode.L) && eTrue)
                    {
                        l.enabled = false;
                        lTrue = true;
                    }
                    if (Input.GetKeyDown(KeyCode.L) && lTrue)
                    {
                        l2True = true;
                        l2.enabled = false;
                        //REANIMAR ESA TORRETA
                        if (Torrets.vida <= 0)
                        {
                            Torrets.vida = 5;
                            Torrets.canShoot = true;
                            Collider2D collider = Torrets.GetComponent<Collider2D>();
                            collider.enabled = true;
                            hTrue = false;
                            eTrue = false;
                            lTrue = false;
                            l2True = false;
                            respawnear = false;
                            lettersShown = false;
                            PressTime = 0;
                        }
                        if (Torrets2.vida <= 0)
                        {
                            Torrets2.vida = 5;
                            Torrets2.canShoot = true;
                            Collider2D collider2 = Torrets2.GetComponent<Collider2D>();
                            collider2.enabled = true;
                            hTrue = false;
                            eTrue = false;
                            lTrue = false;
                            l2True = false;
                            respawnear = false;
                            lettersShown = false;
                            PressTime = 0;
                        }
                        if (Torrets3.vida <= 0)
                        {
                            Torrets3.vida = 5;
                            Torrets3.canShoot = true;
                            Collider2D collider3 = Torrets3.GetComponent<Collider2D>();
                            collider3.enabled = true;
                            hTrue = false;
                            eTrue = false;
                            lTrue = false;
                            l2True = false;
                            respawnear = false;
                            lettersShown = false;
                            PressTime = 0;
                        }
                        respawnear = false;
                    }

                }
                else
                {
                    Debug.Log("Se desactivan letras");
                    h.enabled = false;
                    e.enabled = false;
                    l.enabled = false;
                    l2.enabled = false;
                    respawnear = false;
                    lettersShown = false; // Restablecer el estado de las letras
                    PressTime = 0;
                    Revive(true, names); ;
                }
            }
        }
        else
        {
            respawnTime = 0; // Restablecer el tiempo si no se está reanimando
        }

    }

    public void Revive(bool destroyed, string[] name)
    {
        respawnTime = 0;
        Debug.Log("Se llamo revive");

        //int j;
        /*for (j = 0; j<3; j++)
        {
            names[j] = name[j];
        }*/
        //int i = 0;
        //if (destroyed)
        respawnear = true;
            
          

        
    }
        
}
