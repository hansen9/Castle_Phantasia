using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OptionGame(){
        Debug.Log("-OPTION-");
    }
    public void QuitGame(){
        Debug.Log("-QUIT-");
        Application.Quit();
    }
    public void MainMenuButton(){
        SceneManager.LoadScene("MainMenu");
    }
}
