using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public bool isSongPlaying;
    public GameObject[] noteList;

    public int songNumber;

    public AudioSource songToPlay;

    public int totalNote;

    void Start()
    {
        Instance = this;
        isSongPlaying = false;

        songNumber = PlayerPrefs.GetInt("SongNumber");
        songToPlay = GameObject.Find($"SoundManager/Song/Song_{songNumber}").GetComponent<AudioSource>();

        songToPlay.Play();
        GameObject Note = Instantiate(noteList[songNumber-1]);
        Note.name = noteList[songNumber-1].name;
        songToPlay.volume = 0.25f;
        
        totalNote = GameObject.FindGameObjectsWithTag("Note").Length;
    }

    void Update()
    {

        if (songToPlay.isPlaying){
            isSongPlaying = true;
        } else {
            isSongPlaying = false;
        }

    }
}
