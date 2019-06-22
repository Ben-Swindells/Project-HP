using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterBuilder : MonoBehaviour
{
    public TMP_InputField playerUsernameInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MaleButton()
    {
        PlayerManager.male = true;
    }
    public void FemaleButton()
    {
        PlayerManager.female = true;
    }
      public void StartGame(string sceneName)
    {
        PlayerManager.playerName = playerUsernameInput.text;
        SceneManager.LoadScene(sceneName);
    }
}
