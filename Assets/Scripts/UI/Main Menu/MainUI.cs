using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    [Header("Main Canvas Menus")]
    public GameObject mainMenu;
    public GameObject characterMenu;
    public GameObject settingsMenu;


    // Start is called before the first frame update
    void Start()
    {
        characterMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewGame()
    {
        characterMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void Back()
    {
        mainMenu.SetActive(true);
        characterMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }
    public void SettingsButton()
    {
        settingsMenu.SetActive(true);
        characterMenu.SetActive(false);
        mainMenu.SetActive(false);
    }
    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
}
