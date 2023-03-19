using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    void Start() {
        Instance = this;
    }

    public void gotoGame(){
        SceneManager.LoadScene("GameScene");
    }

    public void gotoEnd(){
        SceneManager.LoadScene("EndScene");
    }

    public void gotoMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }

    public void quit(){
        Application.Quit();
    }
}
