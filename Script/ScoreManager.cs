using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] TextMeshProUGUI scoreText, comboText, multiplierText;

    public int currentScore;
    public int currentCombo;
    public int maxCombo;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierLevel = new int[2];

    void Start()
    {
        Instance = this;

        currentScore = 0;
        currentCombo = 0;
        maxCombo = currentCombo;

        currentMultiplier = 1;
        multiplierTracker = 0;
        multiplierLevel = new int[] {5, 10, 20};
    }

    void Update()
    {
        if (currentMultiplier-1 < multiplierLevel.Length) {
            if (multiplierTracker >= multiplierLevel[currentMultiplier-1]){
                currentMultiplier++;
                multiplierTracker = 0;
            }
        }

        if (maxCombo < currentCombo){
            maxCombo = currentCombo;
        }

        scoreText.text = $"Score : {currentScore}";
        comboText.text = $"Combo : {currentCombo}";
        multiplierText.text = $"Multiplier : {currentMultiplier}x";

    }

    public void addScore(int score = 100){
        currentScore += score * currentMultiplier;
    }

    public void addHoldScore(int holdScore = 5){
        currentScore += holdScore;
    }

    public void addCombo(int combo = 1){
        currentCombo += combo;
    }

    public void lostCombo(){
        currentCombo = 0;
    }

    public void addMultiplier(int multiplier = 1){
        multiplierTracker += multiplier;
    }

    public void resetMultiplier(){
        currentMultiplier = 1;
        multiplierTracker = 0;
    }

}
