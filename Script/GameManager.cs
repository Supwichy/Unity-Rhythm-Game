using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public bool isGameStart;

    public GameObject gameStateUI;

    int totalNote, goodHit, perfectHit, missHit, maxCombo, finaleScore;

    PlayerHeath playerHeath;

    float endSceneDelay;

    void Start()
    {
        Instance = this;

        isGameStart = true;

        playerHeath = GameObject.Find("Player").GetComponent<PlayerHeath>();

        gameStateUI.SetActive(false);

        goodHit = 0;
        perfectHit = 0;
        missHit = 0;
        
    }

    void Update()
    {
        
        if (!isGameStart){
            gameStateUI.SetActive(true);
            return;
        }

        if (playerHeath.getCurrentHeath() <= 0){
            isGameStart = false;
            SoundManager.Instance.songToPlay.Stop();
        }

        if (!SoundManager.Instance.isSongPlaying){

            if (endSceneDelay > 1.5f){
                finaleScore = ScoreManager.Instance.currentScore;
                maxCombo = ScoreManager.Instance.maxCombo;
                totalNote = SoundManager.Instance.totalNote;

                PlayerPrefs.SetInt("TotalNote", totalNote);
                PlayerPrefs.SetInt("GoodHit", goodHit);
                PlayerPrefs.SetInt("PerfectHit", perfectHit);
                PlayerPrefs.SetInt("MissHit", missHit);
                PlayerPrefs.SetInt("MaxCombo", maxCombo);
                PlayerPrefs.SetInt("FinaleScore", finaleScore);
                
                SceneController.Instance.gotoEnd();

            } else {
                endSceneDelay += Time.deltaTime;
            }
        
        }

    }

    public void addGoodHit(){
        goodHit++;
    }

    public void addPerfectHit(){
        perfectHit++;
    }

    public void addMissHit(){
        missHit++;
    }
}
