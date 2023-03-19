using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public KeyCode keyToPress;
    public Color defaultColor;
    public Color pressedColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
    }

    void Update()
    {
        if (Input.GetKey(keyToPress)){
            spriteRenderer.color = pressedColor;
        } else {
            spriteRenderer.color = defaultColor;
        }
    }
}
