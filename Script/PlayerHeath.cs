using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHeath : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextHP;

    public static int currentHeath;

    void Start()
    {
        currentHeath = 100;
    }

    
    void Update()
    {
        TextHP.text = $"HP : {currentHeath}";
    }

    public void takeDamage(int damage){
        currentHeath -= damage;
        if (currentHeath < 0){
            currentHeath = 0;
        }
    }

    public void getHeal(int heal){
        currentHeath += heal;
        if (currentHeath > 100){
            currentHeath = 100;
        }
    }

    public int getCurrentHeath(){
        return currentHeath;
    }
}
