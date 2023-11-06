using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject ganarMenu;
    public GameObject perderMenu;

    public void ActivePauseMenu()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        ganarMenu.SetActive(false);
        perderMenu.SetActive(false);
    }
    public void ActiveOptionsMenu()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
        ganarMenu.SetActive(false);
        perderMenu.SetActive(false);
    }
    public void ActiveGanarMenu()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        ganarMenu.SetActive(true);
        perderMenu.SetActive(false);
    }
    public void ActivePerderMenu()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        ganarMenu.SetActive(false);
        perderMenu.SetActive(true);
    }
}
