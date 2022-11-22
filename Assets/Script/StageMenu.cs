using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageMenu : MonoBehaviour
{
    public void PlayTutorial(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayStage1(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
