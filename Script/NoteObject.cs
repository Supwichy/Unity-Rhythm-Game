using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteObject : MonoBehaviour
{
    public KeyCode keyToPress;
    public string noteState;

    public bool canBePress;
    public float noteSpeed;

    public GameObject goodEffect;
    public GameObject perfectEffect;
    public GameObject missEffect;

    PlayerHeath playerHeath;
    
    AudioSource hitSoundUp;
    AudioSource hitSoundDown;
    AudioSource missSound;

    Vector3 buttonPosition;
    float goodOffsetX;
    float perfectOffsetX;
    float missOffsetX;

    float timeToHold;
    float timeElapsed;

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "NoteRecordScene"){
            // Set default value
            hitSoundUp = GameObject.Find("SoundManager/hitUp").GetComponent<AudioSource>();
            hitSoundDown = GameObject.Find("SoundManager/hitDown").GetComponent<AudioSource>();
            missSound = GameObject.Find("SoundManager/miss").GetComponent<AudioSource>();
            playerHeath = GameObject.Find("Player").GetComponent<PlayerHeath>();
        }
        
        canBePress = false;

        buttonPosition = Vector3.zero;
        goodOffsetX = 1.0f;
        perfectOffsetX = 0.2f;
        missOffsetX = 0.19f;

        timeToHold = 1.0f;

        // check for Press or Hold note with String.Contains() Methods
        noteState = this.gameObject.name;
        if (noteState.Contains("Press")){
            noteState = "Press";
        } else if (noteState.Contains("Hold")) {
            noteState = "Hold";
        }
        
    }

    void Update()
    {   
        if (SceneManager.GetActiveScene().name == "NoteRecordScene"){
            transform.position -= new Vector3(noteSpeed * Time.deltaTime, 0, 0);
            return;
        }

        
        if (SoundManager.Instance.isSongPlaying){
            transform.position -= new Vector3(noteSpeed * Time.deltaTime, 0, 0);

            if (canBePress){

                if (noteState == "Press"){

                    if (Input.GetKeyDown(keyToPress)){

                        if(keyToPress == KeyCode.F){
                            hitSoundUp.Play();
                        } else {
                            hitSoundDown.Play();
                        }

                        if (transform.position.x >= (buttonPosition.x + goodOffsetX) ){

                            Debug.Log("Good");
                            goodHit();
                            Hit(100);
                            Instantiate(goodEffect, buttonPosition, goodEffect.transform.rotation);
                            
                            
                            this.gameObject.SetActive(false);

                        } else if (transform.position.x >= (buttonPosition.x + perfectOffsetX) ){

                            Debug.Log("Perfect");
                            perfectHit();
                            Hit(120);
                            Instantiate(perfectEffect, buttonPosition, perfectEffect.transform.rotation);
                            
                            this.gameObject.SetActive(false);
                        }

                    } 
                    // Destroy note when pass Button
                    if ( (transform.position.x <= (buttonPosition.x + missOffsetX) ) && (buttonPosition != Vector3.zero)){
                        
                        Debug.Log("Miss");
                        missHit();
                        Miss();

                        this.gameObject.SetActive(false);
                    }   

                } 
                
                if (noteState == "Hold") {

                    if (Input.GetKey(keyToPress)){
                        Debug.Log("Point UP ! ! !");
                        // float scaleX = transform.localScale.x;
                        // float scaleY = transform.localScale.y;
                        // float scaleZ = transform.localScale.z;
                        // scaleX -= 0.85f * Time.deltaTime;
                        // transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
                        HitHold(5);
                        timeElapsed = 0;

                    } else if (Input.GetKeyUp(keyToPress)){
                        Debug.Log("Fail Hold");
                        this.gameObject.SetActive(false);
                    }

                    if (timeElapsed > timeToHold){
                        Debug.Log("Miss hold");
                        this.gameObject.SetActive(false);
                    }
                }
            }
        }


    }

    void Hit(int score){
        ScoreManager.Instance.addScore(score);
        ScoreManager.Instance.addCombo();
        ScoreManager.Instance.addMultiplier();
        playerHeath.getHeal(4);
    }
        
    void Miss(){
        ScoreManager.Instance.lostCombo();
        ScoreManager.Instance.resetMultiplier();
        playerHeath.takeDamage(8);
        missSound.Play();
        Instantiate(missEffect, buttonPosition, missEffect.transform.rotation);
    }

    void HitHold(int score){
        ScoreManager.Instance.addScore(score);
    }

    void goodHit(){
        GameManager.Instance.addGoodHit();
    }

    void perfectHit(){
        GameManager.Instance.addPerfectHit();
    }

    void missHit(){
        GameManager.Instance.addMissHit();
    }

    void OnTriggerEnter2D(Collider2D target){
        if (target.gameObject.tag == "Button"){
            canBePress = true;
            buttonPosition = target.gameObject.transform.position;
        }
    }

    void OnTriggerStay2D(Collider2D target){
        if (target.gameObject.tag == "Button"){
            timeElapsed += Time.deltaTime;
        }
    }

    void OnTriggerExit2D(Collider2D target){
        if (target.gameObject.tag == "Button"){
            canBePress = false;
            this.gameObject.SetActive(false);
        }
    }

}