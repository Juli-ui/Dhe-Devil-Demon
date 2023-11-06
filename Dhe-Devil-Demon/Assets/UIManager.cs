using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Slider playerHealthBar;
    public Slider playerHealthBar2;
    public Slider playerHealthBar3;
    GameManager gm;
    public TMP_Text timer;
    public GameObject Managers;
    public AudioSource myAs;
    int paraAtras=120;
    public ChangeScene change;
    float count;

    private void Awake()
    {
        gm = GetComponent<GameManager>();
        playerHealthBar.maxValue = gm.player.maxLife;
        gm = GetComponent<GameManager>();
        playerHealthBar2.maxValue = gm.player2.maxLife;
        gm = GetComponent<GameManager>();
        playerHealthBar3.maxValue = gm.player3.maxLife;

        playerHealthBar.value = gm.player.maxLife;
        playerHealthBar2.value = gm.player2.maxLife;
        playerHealthBar3.value = gm.player3.maxLife;
        myAs = GetComponent<AudioSource>();
    }

    private void Update()
    {
        count += Time.deltaTime;
        
        if(paraAtras<=0)
        {
            //Debug.Log("Ganaste");
            timer.text = "Timer: 0";
            Managers.GetComponent<PauseMenuManager>().ActiveGanarMenu();
            Time.timeScale = 0;
            //change.NewScene("WinMenu");
            myAs.Play();
        }else if(count>=1)
        {
            paraAtras-=1;
            timer.text = "Timer: " + paraAtras;
            count=0;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            count = 2;
        }
    }

    public void UpdatePlayerBar()
    {
        playerHealthBar.value = gm.player.vida;
        playerHealthBar2.value = gm.player2.vida;
        playerHealthBar3.value = gm.player3.vida;
    }
}
