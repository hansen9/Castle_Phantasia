using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageMenu : MonoBehaviour
{
    public void PlayTutorial(){
        // SceneManager.LoadScene("Tutorial"); bisa seperti ini juga
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayStage1(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void PlayStage2(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
}
