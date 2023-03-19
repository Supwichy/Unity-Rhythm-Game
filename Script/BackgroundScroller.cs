using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollerSpeed;
    public float posXToStartInstantiate;
    public float posXToInstantiate;
    public float posXToDestroy;

    string sceneName;
    bool spawnCheck;

    void Start(){
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {   

        if (transform.position.x <= posXToStartInstantiate && !spawnCheck){
            Instantiate(this.gameObject, new Vector3(transform.position.x + posXToInstantiate, transform.position.y, transform.position.z), transform.rotation);
            spawnCheck = true;
        }

        if (transform.position.x <= posXToDestroy){
            Destroy(this.gameObject);
        }

        if (sceneName == "MainScene" || sceneName == "EndScene"){
            transform.position -= new Vector3(scrollerSpeed * Time.deltaTime, 0, 0);
            return;
        }

        if (GameManager.Instance.isGameStart){
            transform.position -= new Vector3(scrollerSpeed * Time.deltaTime, 0, 0);
        }
    }
}
