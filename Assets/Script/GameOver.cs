using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour{
    public TMP_Text gameOverText;
    void Start()
    {
        gameOverText = GetComponent<TextMeshProUGUI>();
    }

    public void setUp(string msg)
    {
        gameOverText = GetComponent<TextMeshProUGUI>();
        // gameObject.SetActive(true);
        gameOverText.text = "Haha";
    }
}