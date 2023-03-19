using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textSongName, textTotalHit, textGoodHit, textPerfectHit, textMissHit, textMaxCombo, textPercentage, textRank, textFinaleScore;

    public string songName;
    public int totalNote;
    public int totalHit;
    public int goodHit;
    public int perfectHit;
    public int missHit;
    public int maxCombo;
    public char rank;
    public int finaleScore;
    public float percenHit;

    void Start()
    {
        songName = PlayerPrefs.GetString("SongName");
        totalNote = PlayerPrefs.GetInt("TotalNote");
        goodHit = PlayerPrefs.GetInt("GoodHit");
        perfectHit = PlayerPrefs.GetInt("PerfectHit");
        missHit = PlayerPrefs.GetInt("MissHit");
        maxCombo = PlayerPrefs.GetInt("MaxCombo");
        finaleScore = PlayerPrefs.GetInt("FinaleScore");

        totalHit = goodHit + perfectHit;
        percenHit = ((float)totalHit/(float)totalNote) * 100f;
        rank = getRank(percenHit);

        textSongName.text = songName;
        textTotalHit.text = totalHit.ToString();
        textGoodHit.text = goodHit.ToString();
        textPerfectHit.text = perfectHit.ToString();
        textMissHit.text = missHit.ToString();
        textMaxCombo.text = maxCombo.ToString();
        textPercentage.text = percenHit.ToString("F1") + "%";
        textRank.text = rank.ToString();
        textFinaleScore.text = finaleScore.ToString();

    }

    public static char getRank(float percentage = 0.0f){

        char rankValue = 'F';
        if (percentage >= 50){
            rankValue = 'D';
            if (percentage >= 60){
                rankValue = 'C';
                if (percentage >= 70){
                    rankValue = 'B';
                    if (percentage >= 80){
                        rankValue = 'A';
                        if (percentage >= 95){
                            rankValue = 'S';
                        }
                    }
                }
            }
        }
        return rankValue;
    }
}
