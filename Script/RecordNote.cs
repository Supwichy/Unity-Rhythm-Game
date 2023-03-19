using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordNote : MonoBehaviour
{
    public KeyCode noteUpKey;
    public GameObject noteUpPref;
    public KeyCode noteDownKey;
    public GameObject noteDownPref;

    public GameObject linePerf;

    public int noteCount;

    public float delayStartTime;

    Vector3 noteUpPos;
    Quaternion noteUpRot;
    Vector3 noteDownPos;
    Quaternion noteDownRot;

    void Start()
    {
        noteCount = 1;

        float x = this.transform.position.x;
        float y = this.transform.position.y;
        float z = this.transform.position.z;

        noteUpPos = new Vector3(x, noteUpPref.transform.position.y, z);
        noteDownPos = new Vector3(x, noteDownPref.transform.position.y, z);

        noteUpRot = noteUpPref.transform.rotation;
        noteDownRot = noteDownPref.transform.rotation;

        // create line at start song
        Instantiate(linePerf, new Vector3(-6 ,y ,z), linePerf.transform.rotation, this.transform).name = "Start_Song";
        // create line at start note
        Instantiate(linePerf, new Vector3(14, y ,z), linePerf.transform.rotation, this.transform).name = "Start_Note";
        // create line hit button
        Instantiate(linePerf, new Vector3(-6 ,y ,z), linePerf.transform.rotation, this.transform).name = "Button_Line";
    }

    void Update()
    {
        if (delayStartTime > 3.2){

            if(Input.GetKeyDown(noteDownKey)){
                var Note = Instantiate(noteDownPref, noteDownPos, noteDownRot, this.transform);
                Note.name = $"{noteDownPref.name}_{noteCount}";
                noteCount++;
            }

            if(Input.GetKeyDown(noteUpKey)){
                var Note = Instantiate(noteUpPref, noteUpPos, noteUpRot, this.transform);
                Note.name = $"{noteUpPref.name}_{noteCount}";
                noteCount++;
            }

        } else {
            delayStartTime += Time.deltaTime;
        }
    }
}