using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Bala myBala;
    public Bala myBalaExplosiva;
    public GameManager myGM; 
    public AudioSource myAs;
    public float vida;
    public float maxLife = 10;
    float delayDisparoSnipper;
    float delayDisparo;
    public bool esSniper;
    bool SnipperPuedeDisparar;
    bool PuedeDisparar;
    public Animator anim;
    public float delayShoots;

    [Header("Clips")]
    public AudioClip HitTorreta;
    public AudioClip bolaDeFuego;

    //
    public bool TorretDestroy=false;
    public string[] TorretDestroyed = new string[3];
    public RespawnTurret respawnTurret;
    public bool canShoot = true;
    bool charging = false;
    public float cargaTiempo = 0;
    public int tiempoMinimoCarga = 2;
    public Slider cargaSlider;

    private void Awake()
    {
        myAs = GetComponent<AudioSource>();
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        vida = maxLife;
        vida = 10;
        delayShoots = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
                myGM.PauseGame();
        if (!myGM.gameIsPaused)
        {
            if(esSniper)
                SniperShoot();
            else
                Shoot();
            
        }
        myGM.uiManager.UpdatePlayerBar();
    }
    void Shoot()
    {
        if(canShoot)
        {
            delayDisparo += Time.deltaTime;
            if (delayDisparo >= delayShoots)
            {
                PuedeDisparar = true;
                if (PuedeDisparar)
                {
                    Vector3 shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    shootDirection.z = 0;
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Bala bullet = Instantiate(myBala, transform.position, transform.rotation);
                        bullet.transform.up = shootDirection - transform.position;
                        PlayAudio(bolaDeFuego);
                        anim.SetBool("Disparo", true);
                        PuedeDisparar = false;
                        delayDisparo = 0;
                    }
                    else
                    {
                        anim.SetBool("Disparo", false);
                    }
                    if (Input.GetMouseButton(1))
                    {
                        if (!charging)
                        {
                            charging = true;
                            cargaTiempo = 0;
                        }
                        else
                        {
                            cargaTiempo += Time.deltaTime;
                            float cargaNormalizada = Mathf.Clamp01(cargaTiempo / tiempoMinimoCarga); 
                            cargaSlider.value = cargaNormalizada; 
                            if (cargaTiempo >= tiempoMinimoCarga)
                            {
                                Bala bullet = Instantiate(myBalaExplosiva, transform.position, transform.rotation);
                                bullet.transform.up = shootDirection - transform.position;
                                PlayAudio(bolaDeFuego);
                                anim.SetBool("Disparo", true);
                                PuedeDisparar = false;
                                delayDisparo = 0;
                                cargaTiempo = 0;
                                cargaSlider.value = 0f;
                            }
                        }

                    }
                    else
                    {
                        anim.SetBool("Disparo", false);
                        charging = false;
                        cargaTiempo = 0;
                        cargaSlider.value = 0f;
                    }
                }
            }
        }  
    }
    void SniperShoot()
    {
        if (canShoot)
        {
            delayDisparoSnipper += Time.deltaTime;
            if (delayDisparoSnipper >= 1.5f)
            {
                SnipperPuedeDisparar = true;
                if (SnipperPuedeDisparar)
                {
                    Vector3 shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    shootDirection.z = 0;
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Bala bullet = Instantiate(myBala, transform.position, transform.rotation);
                        bullet.transform.up = shootDirection - transform.position;
                        PlayAudio(bolaDeFuego);
                        anim.SetBool("Disparo", true);
                        SnipperPuedeDisparar = false;
                        delayDisparoSnipper = 0;
                    }
                    else
                    {
                        anim.SetBool("Disparo", false);
                    }
                    if (Input.GetMouseButton(1))
                    {
                        if (!charging)
                        {
                            charging = true;
                            cargaTiempo = 0;
                        }
                        else
                        {
                            cargaTiempo += Time.deltaTime;
                            float cargaNormalizada = Mathf.Clamp01(cargaTiempo / tiempoMinimoCarga); 
                            cargaSlider.value = cargaNormalizada; 
                            if (cargaTiempo >= tiempoMinimoCarga)
                            {
                                Bala bullet = Instantiate(myBalaExplosiva, transform.position, transform.rotation);
                                bullet.transform.up = shootDirection - transform.position;
                                PlayAudio(bolaDeFuego);
                                anim.SetBool("Disparo", true);
                                PuedeDisparar = false;
                                delayDisparo = 0;
                                cargaTiempo = 0;
                                cargaSlider.value = 0f;
                                
                                
                            }
                        }
                        
                    }
                    else
                    {
                        anim.SetBool("Disparo", false);
                        charging = false;
                        cargaTiempo = 0;
                        cargaSlider.value = 0f;
                        
                        

                    }
                }
            }
        }
    }

    public void PlayAudio(AudioClip audio)
    {
        myAs.Stop();
        myAs.clip = audio;
        myAs.Play();
    }

    public void ReceiveDamage(int dmg)
    {
        vida -= dmg;
        PlayAudio(HitTorreta);
        if(vida <= 0)
        {
            //Destroy(gameObject);
            //PONER ANIMACION DE QUE SE MURIO
            Revivir();
            canShoot = false;
            Collider2D collider = GetComponent<Collider2D>();
            collider.enabled = false;
            //Debug.Log("Se rompio una torreta");
        }
        myGM.uiManager.UpdatePlayerBar();
    }
    public void Revivir()
    {
        TorretDestroy = true;
        for (int i = 0; i < TorretDestroyed.Length; i++)
        {
            if (TorretDestroyed[i] == null)
            {
                TorretDestroyed[i] = this.name.ToString();
                break; // Si quieres que solo se actualice una vez y luego se detenga el bucle.
            }
        }
        respawnTurret.Revive(TorretDestroy, TorretDestroyed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "BalaEnemy")
        {
            int daño =1;
            ReceiveDamage(daño);
            Destroy(other.gameObject);
        }
    }
    
}
