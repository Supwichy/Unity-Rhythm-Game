using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordNoteLineControl : MonoBehaviour
{
    public bool isTimeCount;
    public float timeCount;

    bool isButton;

    void Start()
    {
        isTimeCount = true;

        if (this.gameObject.name.Contains("Button_Line")){
            isButton = true;
        } 
    }

    void Update()
    {
        if (!isButton){
            transform.position -= new Vector3(6.0f * Time.deltaTime, 0, 0);

            if (isTimeCount) {
                timeCount += Time.deltaTime;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.tag == "Button"){
            isTimeCount = false;
        }
    }
}
