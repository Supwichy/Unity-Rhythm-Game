using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Animator anim;
    CharacterController characterController;
    
    float timeFall;

    public Vector3 posHitUp;
    public Vector3 posHitDown;

    public float gravity;
    public float timeToFall;
    public bool isGround;


    void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        transform.position = new Vector3(-8, -3, 0);
        posHitUp = new Vector3(transform.position.x, 2.0f, transform.position.z);
        posHitDown = new Vector3(transform.position.x, -2.0f, transform.position.z);
    }

    
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainScene"){
            transform.position = new Vector3(-4, -3, 0);
            return;
        }

        if (GameManager.Instance.isGameStart){

            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.J)){
                
                anim.Play("Attack");

                if (Input.GetKeyDown(KeyCode.F)){
                    transform.position = posHitUp;
                    isGround = false;
                    timeFall = 0;
                }

                if (Input.GetKeyDown(KeyCode.J)){
                    transform.position = posHitDown;
                }
            } 
            
            if (!isGround && timeFall > timeToFall){
                transform.position -= new Vector3(0, gravity * Time.deltaTime, 0);
            } else {
                timeFall += Time.deltaTime;
            }

        } else {
            anim.SetTrigger("Death");
        } 
    }

    void OnCollisionEnter2D (Collision2D target){
        if (target.gameObject.tag == "Ground"){
            transform.position = posHitDown;
            isGround = true;
        }

    }
}
