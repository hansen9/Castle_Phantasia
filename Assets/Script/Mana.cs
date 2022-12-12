using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mana : MonoBehaviour
{
    public float maxMana = 50f;
    public float currentMana;
    public Manabar manaBar;
    private float manaRegen = 5f;
    // Start is called before the first frame update
    void Start()
    {
        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
    }
    // Update is called once per frame
    void Update()
    {
        currentMana += manaRegen * Time.deltaTime;
        currentMana = Mathf.Clamp(currentMana, 0f, maxMana);
        manaBar.SetMana(currentMana);
    }
    public void TakeMana(int cost)
    {
        currentMana -= cost;
        manaBar.SetMana(currentMana);
    }
}