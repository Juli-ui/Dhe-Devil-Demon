using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    int vida = 15;
    public GameObject Managers;
    public AudioSource myAs;
    public ChangeScene change;
    public TMP_Text Textovidas;
    private void Awake()
    {
        myAs = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Textovidas.text = "live: " + vida;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PatronesEnemigo>())
        {
            vida-=1;
            myAs.Play();
            if(vida<=0)
            {
                Destroy(gameObject);
                Debug.Log("Perdiste");
                Managers.GetComponent<PauseMenuManager>().ActivePerderMenu();
                Time.timeScale = 0;
                //change.NewScene("LossMenu");
            }
        }
        if (other.GetComponent<Ghost>())
        {
            vida -= 10;
            myAs.Play();
            Destroy(other);
            if (vida <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Perdiste");
                Managers.GetComponent<PauseMenuManager>().ActivePerderMenu();
                Time.timeScale = 0;
                //change.NewScene("LossMenu");
            }
        }
    }

}
