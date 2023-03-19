using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectSong : MonoBehaviour
{
    public string[] songList;

    public int selected;

    [SerializeField] TextMeshProUGUI textSongName;

    void Start()
    {
        selected = 1;
    }

    
    void Update()
    {
        textSongName.text = songList[selected-1].ToString();
        PlayerPrefs.SetInt("SongNumber", selected);
        PlayerPrefs.SetString("SongName", songList[selected-1]);
    }

    public void goLeft(){
        selected--;
        if(selected < 1){
            selected = songList.Length;
        }
    }

    public void goRight(){
        selected++;
        if (selected > songList.Length){
            selected = 1;
        }
    }
}
