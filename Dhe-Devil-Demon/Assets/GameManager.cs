using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public NewBehaviourScript player;
    public NewBehaviourScript player2;
    public NewBehaviourScript player3;
    public GameObject generalCanvas;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public UIManager uiManager;
    public bool gameIsPaused;
    private void Awake()
    {
        uiManager = GetComponent<UIManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        //Debug.Log("Entro");
        gameIsPaused = !gameIsPaused;
        generalCanvas.SetActive(gameIsPaused);
        if(!gameIsPaused)
            Time.timeScale = 1;
        else
        {
            pauseMenu.SetActive(true);
            optionsMenu.SetActive(false);
            Time.timeScale = 0;
        }
            
    }
}
