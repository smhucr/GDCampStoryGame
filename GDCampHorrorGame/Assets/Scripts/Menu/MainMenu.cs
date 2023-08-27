using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenu : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject settingsbutton;
    public GameObject settingspanel;
    public GameObject creditspanel;
    public GameObject creditsbutton;
    public void PlayButton()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void openClose()
    {
        settingspanel.gameObject.SetActive(true);
        settingsbutton.gameObject.SetActive(false);
        mainmenu.SetActive(false);
    }
    public void openClose2()
    {
        creditspanel.gameObject.SetActive(true);
        creditsbutton.SetActive(false);
        mainmenu.SetActive(false);

    }



}

