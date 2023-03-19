using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseGame : MonoBehaviour
{
    public static PauseGame Instance;

    public bool isGamePause;

    public GameObject PauseUI;

    void Start()
    {
        Instance = this;
        PauseUI.SetActive(false);
        Time.timeScale = 1;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){

            if (isGamePause){
                UnPause();
            } else {
                Pause();
            }
        }

    }

    public void Pause(){
        isGamePause = true;
        PauseUI.SetActive(true);
        SoundManager.Instance.songToPlay.Pause();
        Time.timeScale = 0;
    }

    public void UnPause(){
        isGamePause = false;
        PauseUI.SetActive(false);
        SoundManager.Instance.songToPlay.UnPause();
        Time.timeScale = 1;
    }
}
