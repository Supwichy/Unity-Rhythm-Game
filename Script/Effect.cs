using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public float timeDestroy;
    
    void Start()
    {
        Destroy(this.gameObject, timeDestroy);
    }
}
