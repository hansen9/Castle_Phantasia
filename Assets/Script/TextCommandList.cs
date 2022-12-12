using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCommandList : MonoBehaviour
{
    public GameObject Message;
    
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player")
        {
            Message.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player")
        {
            Message.SetActive(false);
        }
    }
}
